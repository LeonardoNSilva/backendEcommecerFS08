using Microsoft.AspNetCore.Mvc;
using ProjetoEcommerce.Context;
using ProjetoEcommerce.Entity;
using System.Linq;

namespace ProjetoEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                return Ok(ctx.Categorias.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetPeloId(int id)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                Categoria categoria = ctx.Categorias.Where(c => c.Id.Equals(id)).FirstOrDefault();

                if (categoria == null)
                    return NotFound();

                return Ok(categoria);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                Categoria categoria = ctx.Categorias.Where(c => c.Id.Equals(id)).FirstOrDefault();

                if (categoria == null)
                    return NotFound();

                ctx.Categorias.Remove(categoria);
                ctx.SaveChanges();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                ctx.Categorias.Add(categoria);
                ctx.SaveChanges();
            }
            return Ok(categoria);
        }

        [HttpPut]
        public ActionResult Put(Categoria categoria)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                ctx.Categorias.Update(categoria);
                ctx.SaveChanges();
            }
            return Ok(categoria);
        }
    }
}
