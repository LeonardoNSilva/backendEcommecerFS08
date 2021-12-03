using Microsoft.AspNetCore.Mvc;
using ProjetoEcommerce.Context;
using ProjetoEcommerce.Entity;
using System.Linq;

namespace ProjetoEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                return Ok(ctx.Administradores.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult getPeloId(int id)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                Administrador usuarioMaster = ctx.Administradores.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (usuarioMaster == null)
                    return NotFound();

                return Ok(usuarioMaster);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delte(int id)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                Administrador usuarioMaster = ctx.Administradores.Where(e => e.Id.Equals(id)).FirstOrDefault();

                if (usuarioMaster == null)
                    return NotFound();

                ctx.Administradores.Remove(usuarioMaster);
                ctx.SaveChanges();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(Administrador usuarioMaster)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                ctx.Administradores.Add(usuarioMaster);
                ctx.SaveChanges();
            }
            return Ok(usuarioMaster);
        }

        [HttpPut]
        public ActionResult Put(Administrador adm)
        {
            using (EcommerceContext ctx = new EcommerceContext())
            {
                ctx.Administradores.Update(adm);
                ctx.SaveChanges();
            }
            return Ok(adm);
        }
    }
}
