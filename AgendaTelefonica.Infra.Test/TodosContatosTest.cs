using AgendaTelefonica.Domain;
using AutoFixture;
using NUnit.Framework;
using System.Linq;

namespace AgendaTelefonica.Infra.Test
{
    [TestFixture]
    class TodosContatosTest : DataBaseTest
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
        public void ObterTodosContatosTest()
        {
            const int doisItens = 2;
            var primeiroContato = _fixture.Create<Contato>();
            var segundoContato = _fixture.Create<Contato>();

            _todasAgendaTelefonica.Incluir(primeiroContato);
            _todasAgendaTelefonica.Incluir(segundoContato);

            var listContato = _todasAgendaTelefonica.ObterTodos();
            var contatoSalvo = listContato.Where(x => x.Id == primeiroContato.Id).FirstOrDefault();

            Assert.AreEqual(doisItens, listContato.Count());
            Assert.AreEqual(primeiroContato.Id, contatoSalvo.Id);
            Assert.AreEqual(primeiroContato.Nome, contatoSalvo.Nome);
        }

        [TearDown]
        public void TearDown()
        {
            _todasAgendaTelefonica = null;
            _fixture = null;
        }
    }
}
