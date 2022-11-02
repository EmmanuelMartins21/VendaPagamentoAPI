using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Context;
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly OrganizadorContext _context;
        public VendasController(OrganizadorContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult RegistrarVenda(Venda venda)
        {
            if(venda == null)
                return BadRequest(new {Erro = "A venda não pode ser vazia" });

            _context.Add(venda);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = venda.IdVenda }, venda);            
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var venda = _context.Vendas.Find(id);
            return venda is null ? BadRequest(new { Erro = "A venda não pode ser vazia" }) : Ok(venda);
        }

        [HttpGet]
        public IActionResult ObterTodasVendas()
        {
            var venda = _context.Vendas;
            return venda is null ? BadRequest(new { Erro = "A venda não pode ser vazia" }) : Ok(venda);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarVendas(int id, Venda venda)
        {
            var vendaBanco = _context.Vendas.Find(id);

            if (vendaBanco == null)
                return NotFound();

            if (venda.Data > DateTime.Now)
                return BadRequest(new { Erro = "A data da venda não pode ser maior que a atual" });

            
            if(vendaBanco.Status == EnumStatusVenda.AguardandoPagamento)
            {
                if(venda.Status == EnumStatusVenda.Cancelada)
                {
                    vendaBanco.Status = venda.Status;
                }
                else if (venda.Status == EnumStatusVenda.PagamentoAprovado)
                {
                    vendaBanco.Status = venda.Status;
                }
                else
                {
                    return BadRequest(new { Erro = "Não é possivel aterar o status da venda" });
                }
            }

            if (vendaBanco.Status == EnumStatusVenda.PagamentoAprovado)
            {
                if (venda.Status == EnumStatusVenda.Cancelada)
                {
                    vendaBanco.Status = venda.Status;
                }
                else if (venda.Status == EnumStatusVenda.EnviadoTransportadora)
                {
                    vendaBanco.Status = venda.Status;
                }
                else
                {
                    return BadRequest(new { Erro = "Não é possivel aterar o status da venda" });
                }
            }

            if (vendaBanco.Status == EnumStatusVenda.EnviadoTransportadora)
            {
                if (venda.Status == EnumStatusVenda.Entregue)
                {
                    vendaBanco.Status = venda.Status;
                }
                else
                {
                    return BadRequest(new { Erro = "Não é possivel aterar o status da venda" });
                }
            }
            _context.Vendas.Update(vendaBanco);
            _context.SaveChanges();

            return Ok(vendaBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirVenda(int id)
        {
            var vendaBanco = _context.Vendas.Find(id);
            if(vendaBanco == null)
                return BadRequest(new { Erro = "A venda não foi localizada, portanto não pode ser excluida" });

            if (vendaBanco.Data < DateTime.Now.AddDays(-60) && vendaBanco.Status == EnumStatusVenda.Cancelada)
            {
                _context.Vendas.Remove(vendaBanco);
                _context.SaveChanges();
                return NoContent();
            }
            return BadRequest(new { Erro = "A data da venda não passou de 30 dias, portanto não pode ser excluida" });
        }
    }
}
