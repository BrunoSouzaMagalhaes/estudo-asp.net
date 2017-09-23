using System.Collections.Generic; 

namespace Mostremais.Domain.Entity
{
    public class Venda
    {
        public int VendaId { get; set; }
        public int ClienteId { get; set; }
        public int EmpresaId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        
    }
}
