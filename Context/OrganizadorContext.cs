using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using System.Threading.Tasks; 
namespace WebAPI.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {
            // Onde faz a comunicação com o banco
        }

        public DbSet<Venda> Vendas { get; set; }
    }
}
