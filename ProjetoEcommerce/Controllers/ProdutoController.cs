using Microsoft.AspNetCore.Mvc;
using ProjetoEcommerce.Context;
using ProjetoEcommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                return Ok(ctx.Produtos.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult getPeloId(int id)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                Produto localidade = ctx.Produtos.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (localidade == null)
                    return NotFound();

                return Ok(localidade);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delte(int id)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                Produto localidade = ctx.Produtos.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (localidade == null)
                    return NotFound();

                ctx.Produtos.Remove(localidade);
                ctx.SaveChanges();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(Produto localidade)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                ctx.Produtos.Add(localidade);
                ctx.SaveChanges();
            }
            return Ok(localidade);
        }

        [HttpPut]
        public ActionResult Put(Produto localidade)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                ctx.Produtos.Update(localidade);
                ctx.SaveChanges();
            }
            return Ok(localidade);
        }
    }
}
