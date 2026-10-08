using Projetomecanica.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projetomecanica.Data;
using System.Text;

namespace Projetomecanica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            return await _context.Veiculo.ToListAsync();
        }

       
        [HttpPost]
        public async Task<ActionResult<Veiculo>> PostVeiculo(Veiculo veiculo)
        {
            _context.Veiculo.Add(veiculo);
            await _context.SaveChangesAsync();

            return Ok("Veículo salvo com sucesso");
        }

    
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeiculo(
            int id,
            Veiculo veiculo)
        {
            var veiculoExistente = await _context.Veiculo.FindAsync(id);

            if (veiculoExistente == null)
            {
                return NotFound("Veículo não encontrado");
            }

            veiculoExistente.modelo = veiculo.modelo;
            veiculoExistente.placa = veiculo.placa;
            veiculoExistente.cor = veiculo.cor;
            veiculoExistente.clienteid = veiculo.clienteid;

            await _context.SaveChangesAsync();

            return Ok("Veículo editado com sucesso");
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiculo(int id)
        {
            var veiculo = await _context.Veiculo.FindAsync(id);

            if (veiculo == null)
            {
                return NotFound("Veículo não encontrado");
            }

            _context.Veiculo.Remove(veiculo);
            await _context.SaveChangesAsync();

            return Ok("Veículo removido com sucesso");
        }
    }
}
