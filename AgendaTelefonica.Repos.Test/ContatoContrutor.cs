using AgendaTelefonica.Domain;
using System;

namespace AgendaTelefonica.Repos.Test
{
    public class ContatoContrutor : BaseContrutor<IContato>
    {
        protected ContatoContrutor() : base() { }

        public static ContatoContrutor LinhaUm()
        {
            return new ContatoContrutor();
        }

        public ContatoContrutor ComId(Guid id)
        {
            _mock.SetupGet(o => o.Id).Returns(id);
            return this;
        }

        public ContatoContrutor ComNome(string nome)
        {
            _mock.SetupGet(o => o.Nome).Returns(nome);
            return this;
        }

    }
}
