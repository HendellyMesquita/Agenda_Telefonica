//using AgendaTelefonica.Infra.Test;
//using AutoFixture;
//using NUnit.Framework;

//namespace AgendaTelefonica.Domain.Test
//{
//    [TestFixture]
//    public class ServicoAgendaTelefonicaTest : DataBaseTest
//    {
//        ServicoAgendaTelefonica _servicoAgendaTelefonica;
//        Fixture _fixture;

//        [SetUp]
//        public void SerUp()
//        {
//            _servicoAgendaTelefonica = new ServicoAgendaTelefonica();
//            _fixture = new Fixture();
//        }

//        [Test]
//        public void ChamarFuncaoIncluirTest()
//        {
//            var contato = _fixture.Create<Contato>();

//            _servicoAgendaTelefonica.Incluir(contato);

//            Assert.IsTrue(true);
//        }

//        [Test]
//        public void ObterContatoTest()
//        {
//            var contato = _fixture.Create<Contato>();

//            _servicoAgendaTelefonica.Incluir(contato);
//            var contatoSalvo = _servicoAgendaTelefonica.Obter(contato.Id);

//            Assert.AreEqual(contato.Id, contatoSalvo.Id);
//            Assert.AreEqual(contato.Nome, contatoSalvo.Nome);
//        }

//        [TearDown]
//        public void TearDown()
//        {

//        }
//    }
//}
