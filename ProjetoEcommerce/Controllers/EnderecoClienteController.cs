using Microsoft.AspNetCore.Mvc;
using ProjetoEcommerce.Context;
using ProjetoEcommerce.Entity;
using System.Linq;

namespace ProjetoEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoClienteController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                return Ok(ctx.Enderecos.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult getPeloId(int id)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                EnderecoCliente endereco = ctx.Enderecos.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (endereco == null)
                    return NotFound();

                return Ok(endereco);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delte(int id)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                EnderecoCliente endereco = ctx.Enderecos.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (endereco == null)
                    return NotFound();

                ctx.Enderecos.Remove(endereco);
                ctx.SaveChanges();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(EnderecoCliente endereco)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                ctx.Enderecos.Add(endereco);
                ctx.SaveChanges();
            }
            return Ok(endereco);
        }

        [HttpPut]
        public ActionResult Put(EnderecoCliente endereco)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                ctx.Enderecos.Update(endereco);
                ctx.SaveChanges();
            }
            return Ok(endereco);
        }
    }
}
