using Microsoft.AspNetCore.Mvc;
using Projetomecanica.Api.Models;
using Projetomecanica.Data;

namespace Projetomecanica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult Login(User usuario)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Usuario == usuario.Usuario && u.Senha == usuario.Senha);
            if (user == null)
            {
                return BadRequest("senha ou login incorreto");
            }
            return Ok(new { nome = user.Nome });
        }
    }
}