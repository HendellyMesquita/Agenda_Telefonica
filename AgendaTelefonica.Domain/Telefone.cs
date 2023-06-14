using System;

namespace AgendaTelefonica.Domain
{
    public class Telefone
    {
        public Guid Id { get; set; }
        public string Numero { get; set; }
        public Guid Contato { get; set; }
    }
}
