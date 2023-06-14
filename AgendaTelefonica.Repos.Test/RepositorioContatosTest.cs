using AgendaTelefonica.Domain;
using AgendaTelefonica.Infra;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AgendaTelefonica.Repos.Test
{
    [TestFixture]
    public class RepositorioContatosTest
    {
        Mock<ITodasAgendaTelefonica> _todasAgendaTelefonica;
        Mock<ITodosOsTelefones> _todosOsTelefones;
        RepositorioContatos _repositorioContatos;

        [SetUp]
        public void SetUp()
        {
            _todasAgendaTelefonica = new Mock<ITodasAgendaTelefonica>();
            _todosOsTelefones = new Mock<ITodosOsTelefones>();
            _repositorioContatos = new RepositorioContatos(_todasAgendaTelefonica.Object, _todosOsTelefones.Object);
        }

        [Test]
        public void ObterContatosComListaDeTelefone()
        {
            var telefoneId = Guid.NewGuid();
            var contatoId = Guid.NewGuid();
            var lstTelefone = new List<ITelefone>();
            var mContato = ContatoContrutor.LinhaUm().ComId(contatoId).ComNome("João").Obter();

            mContato.SetupSet(o => o.Telefones = It.IsAny<List<ITelefone>>())
                .Callback<List<ITelefone>>(p => lstTelefone = p);

            _todasAgendaTelefonica.Setup(o => o.Obter(contatoId)).Returns(mContato.Object);

            var mTelefone = TelefoneContrutor.LinhaUm().Padrao().ComId(telefoneId).ComContatoId(contatoId).ConverterEmObjeto();

            _todosOsTelefones.Setup(o => o.ObterTodosOsTelefonesDoContato(contatoId)).Returns(new List<ITelefone> { mTelefone });

            var contatoSalvo = _repositorioContatos.ObterPor(contatoId);
            mContato.SetupGet(o => o.Telefones).Returns(lstTelefone);

            Assert.AreEqual(mContato.Object.Id, contatoSalvo.Id);
            Assert.AreEqual(mContato.Object.Nome, contatoSalvo.Nome);
            Assert.AreEqual(1, contatoSalvo.Telefones.Count);
            Assert.AreEqual(mTelefone.Id, contatoSalvo.Telefones[0].Id);
            Assert.AreEqual(mTelefone.Numero, contatoSalvo.Telefones[0].Numero);
            Assert.AreEqual(mContato.Object.Id, contatoSalvo.Telefones[0].Contato);
        }
        [TearDown]
        public void TearDown()
        {
            _todasAgendaTelefonica = null;
            _todosOsTelefones = null;
            _repositorioContatos = null;
        }
    }
}
