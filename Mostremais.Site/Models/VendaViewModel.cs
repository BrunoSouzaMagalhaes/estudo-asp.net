using Mostremais.Domain.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mostremais.Site.Models
{
    public class VendaViewModel
    {
        [Key] 
        public int VendaId { get; set; }
        public int EmpresaId { get; set; }
        public int ClienteId { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Cliente Cliente { get; set; } 
        public virtual ICollection<Produto> Produtos { get; set; }    
    }
}