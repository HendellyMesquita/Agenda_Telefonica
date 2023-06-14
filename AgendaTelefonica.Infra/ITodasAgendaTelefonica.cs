using AgendaTelefonica.Domain;
using System;

namespace AgendaTelefonica.Infra
{
    public interface ITodasAgendaTelefonica
    {
       IContato Obter(Guid id);
    }
}
