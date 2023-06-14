using AgendaTelefonica.Domain;
using AutoFixture;
using System;

namespace AgendaTelefonica.Repos.Test
{
    public class TelefoneContrutor : BaseContrutor<ITelefone>
    {
        protected TelefoneContrutor() : base() { }

        public TelefoneContrutor Padrao()
        {
            _mock.SetupGet(o => o.Id).Returns(_fixture.Create<Guid>());
            _mock.SetupGet(o => o.Numero).Returns(_fixture.Create<string>());
            _mock.SetupGet(o => o.Contato).Returns(_fixture.Create<Guid>());

            return this;
        }

        public static TelefoneContrutor LinhaUm()
        {
            return new TelefoneContrutor();
        }

        public TelefoneContrutor ComId(Guid id)
        {
            _mock.SetupGet(o => o.Id).Returns(id);
            return this;
        }

        public TelefoneContrutor ComNumero(string numero)
        {
            _mock.SetupGet(o => o.Numero).Returns(numero);
            return this;
        }
        public TelefoneContrutor ComContatoId(Guid contatoId)
        {
            _mock.SetupGet(o => o.Contato).Returns(contatoId);
            return this;
        }
    }
}
