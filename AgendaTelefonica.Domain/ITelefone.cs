using System;

namespace AgendaTelefonica.Domain
{
    public interface ITelefone
    {
        Guid Id { get; set; }
        string Numero { get; set; }
        Guid Contato { get; set; }
    }
}
