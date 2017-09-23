using System.Collections.Generic;

namespace Mostremais.Domain.Entity
{
    public class Empresa
    { 
        public int EmpresaId { get; set; }
        public string Nome { get; set; }
        public string Alias { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Produto> Produto { get; set; }
        public virtual ICollection<ProdutoCategoria> ProdutoCategoria { get; set; }
        public virtual ICollection<Venda> vendas { get; set; }

    }
}
