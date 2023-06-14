using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using AgendaTelefonica.Domain;
using Dapper;

namespace AgendaTelefonica.Infra
{
    public class TodasAgendaTelefonica 
    {
       private readonly string _strCon;

        public TodasAgendaTelefonica()
        {
            _strCon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        }

        public void Incluir(Contato contato)
        {
            using (var con = new SqlConnection(_strCon))
            {
                con.Execute("Insert into Contato (Id, Nome) values (@Id, @Nome)", contato);
            }
        }

        public Contato Obter(Guid id)
        {
            Contato contato;

            using (var con = new SqlConnection(_strCon))
            {
                contato = con.QueryFirst<Contato>("Select Id, Nome From Contato Where Id = @Id", new { Id = id });
            }
            return contato;
        }

        public List<Contato> ObterTodos()
        {
            var contatos = new List<Contato>();

            using (var con = new SqlConnection(_strCon))
            {
                contatos = con.Query<Contato>("Select * From Contato").ToList();
            }

            return contatos;
        }

        public void Excluir(Guid id)
        {
            using (var con = new SqlConnection(_strCon))
            {
                con.Execute("Delete From Contato Where Id = @Id", new { Id = id });
            }
        }

    }
}
