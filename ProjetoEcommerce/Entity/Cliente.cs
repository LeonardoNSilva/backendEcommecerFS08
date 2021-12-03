using System;

namespace ProjetoEcommerce.Entity
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Perfil Perfil { get; set; }
        public EnderecoCliente Endereco { get; set; }
    }
}
