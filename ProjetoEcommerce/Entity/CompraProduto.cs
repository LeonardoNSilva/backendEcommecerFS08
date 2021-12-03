using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEcommerce.Entity
{
    public class CompraProduto
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime Data { get; set; }
    }
}
