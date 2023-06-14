using AgendaTelefonica.Domain;
using AgendaTelefonica.Infra;
using System;
using System.Collections.Generic;

namespace AgendaTelefonica.Repos
{
    public class RepositorioContatos
    {
        private readonly ITodasAgendaTelefonica _todasAgendaTelefonica;
        private readonly ITodosOsTelefones _todosOsTelefones;

        public RepositorioContatos(ITodasAgendaTelefonica todasAgendaTelefonica, ITodosOsTelefones tdosOsTelefones)
        {
            _todasAgendaTelefonica = todasAgendaTelefonica;
            _todosOsTelefones = tdosOsTelefones;
        }

        public IContato ObterPor(Guid id)
        {
            IContato contato = _todasAgendaTelefonica.Obter(id);
            List<ITelefone> lstTelefone = _todosOsTelefones.ObterTodosOsTelefonesDoContato(id);
            contato.Telefones = lstTelefone;

            return contato;
        }
    }
}
