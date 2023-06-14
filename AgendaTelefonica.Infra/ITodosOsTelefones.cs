using AgendaTelefonica.Domain;
using System;
using System.Collections.Generic;

namespace AgendaTelefonica.Infra
{
    public interface ITodosOsTelefones
    {
        List<ITelefone> ObterTodosOsTelefonesDoContato(Guid ContatoId);
    }
}
