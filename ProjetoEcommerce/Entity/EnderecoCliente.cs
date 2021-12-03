using System;

namespace ProjetoEcommerce.Entity
{
    public class EnderecoCliente
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public Int64 Cep { get; set; }
    }
}
