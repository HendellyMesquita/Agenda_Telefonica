using NUnit.Framework;
using AgendaTelefonica.Domain;
using AutoFixture;
using System.Linq;

namespace AgendaTelefonica.Infra.Test
{
    [TestFixture]
    public class TodasAgendaTelefonicaTest : DataBaseTest
    {
        TodasAgendaTelefonica _todasAgendaTelefonica;
        Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _todasAgendaTelefonica = new TodasAgendaTelefonica();
            _fixture = new Fixture();

        }

        [Test]
        public void IncluirContatoTest()
        {
            var contato = _fixture.Create<Contato>();

            _todasAgendaTelefonica.Incluir(contato);

            Assert.IsTrue(true);
        }

        [Test]
        public void ObterContatoTest()
        {
            var contato = _fixture.Create<Contato>();

            _todasAgendaTelefonica.Incluir(contato);
            var contatoSalvo = _todasAgendaTelefonica.Obter(contato.Id);

            Assert.AreEqual(contato.Id, contatoSalvo.Id);
            Assert.AreEqual(contato.Nome, contatoSalvo.Nome);
        }

        [Test]
        public void ExcluirContatoPorIdTest()
        {

            var primeiroContato = _fixture.Create<Contato>();
            var segundoContato = _fixture.Create<Contato>();

            _todasAgendaTelefonica.Incluir(primeiroContato);
            _todasAgendaTelefonica.Incluir(segundoContato);
            _todasAgendaTelefonica.Excluir(primeiroContato.Id);

            var contatos = _todasAgendaTelefonica.ObterTodos().Select(o => o.Id).ToList();
            var contemContato = contatos.Contains(primeiroContato.Id);

            Assert.IsFalse(contemContato);
            Assert.AreEqual(decimal.One, contatos.Count());

        }

        [TearDown]
        public void TearDown()
        {
            _todasAgendaTelefonica = null;
            _fixture = null;
        }
    }
}
