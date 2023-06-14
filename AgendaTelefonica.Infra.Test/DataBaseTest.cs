using NUnit.Framework;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace AgendaTelefonica.Infra.Test
{
    [TestFixture]
    public class DataBaseTest
    {
        private string _script;
        private string _con;
        private string _catalogTest;
        public DataBaseTest()
        {
            _script = @"DBContato_Create.sql";
            _con = ConfigurationManager.ConnectionStrings["conSetUpTest"].ConnectionString;
            _catalogTest = ConfigurationManager.ConnectionStrings["conSetUpTest"].ProviderName;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            CriateDBTest();
        }


        private void CriateDBTest()
        {
            using (var con = new SqlConnection(_con))
            {
                con.Open();
                var scriptSql = File
                    .ReadAllText($@"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\{_script}")
                    .Replace("$(DefaultDataPath)", $@"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}")
                    .Replace("$(DefaultLogPath", $@"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}")
                    .Replace("$(DefaultFilePrefix)", _catalogTest)
                    .Replace("$(DatabaseName)", _catalogTest)
                    .Replace("WITH (DATA_COMPRESSION = PAGE)", string.Empty)
                    .Replace("SET NOEXEC ON", string.Empty)
                    .Replace("GO\r\n", "|");

                ExecuteScriptSql(con, scriptSql);
            }
        }

        private void ExecuteScriptSql(SqlConnection con, string scriptSql)
        {
            using (var cmd = con.CreateCommand())
            {
                foreach (var sql in scriptSql.Split('|'))
                {
                    cmd.CommandText = sql;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(sql);
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DeleteDBTest();
        }

        private void DeleteDBTest()
        {
            using (var con = new SqlConnection(_con))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = $@"USE [master];
                                         DECLARE @kill varchar(8000) = '';
                                         SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';'
                                         FROM sys.dm_exec_sessions
                                         WHERE database_id = db_id('{_catalogTest}')
                                         EXEC(@kill);";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $"DROP DATABASE {_catalogTest}";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
