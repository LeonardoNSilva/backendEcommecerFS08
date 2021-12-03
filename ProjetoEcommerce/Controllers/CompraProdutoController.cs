using Microsoft.AspNetCore.Mvc;
using ProjetoEcommerce.Context;
using ProjetoEcommerce.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraProdutoController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                return Ok(ctx.CompraProdutos.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult getPeloId(int id)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                CompraProduto compraProduto = ctx.CompraProdutos.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (compraProduto == null)
                    return NotFound();

                return Ok(compraProduto);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delte(int id)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                CompraProduto compraProduto = ctx.CompraProdutos.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (compraProduto == null)
                    return NotFound();

                ctx.CompraProdutos.Remove(compraProduto);
                ctx.SaveChanges();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(CompraProduto compraProduto)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                ctx.CompraProdutos.Add(compraProduto);
                ctx.SaveChanges();
            }
            return Ok(compraProduto);
        }

        [HttpPost("Carrinho")]
        public ActionResult PostCarrinho([FromBody] List<CompraProduto> compras)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                for (int i = 0; i < compras.Count(); i++)
                {
                    compras[i].Cliente = ctx.Clientes.Where(c => c.Id.Equals(compras[i].Cliente.Id)).FirstOrDefault();
                    compras[i].Produto = ctx.Produtos.Where(c => c.Id.Equals(compras[i].Produto.Id)).FirstOrDefault();

                    ctx.CompraProdutos.Add(compras[i]);
                }
                ctx.SaveChanges();
            }
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(CompraProduto compraProduto)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                ctx.CompraProdutos.Update(compraProduto);
                ctx.SaveChanges();
            }
            return Ok(compraProduto);
        }
    }
}
