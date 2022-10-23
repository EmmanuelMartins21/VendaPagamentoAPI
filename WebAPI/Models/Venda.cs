using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{    
    public class Venda
    {
        [Key]        
        public int IdVenda { get; set; }
        public int VendedorId { get; set; }
        public string VendedorName { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string ItensVendidos { get; set; }
        public EnumStatusVenda Status { get; set; }
        public DateTime Data { get; set; }
        
    }
}
