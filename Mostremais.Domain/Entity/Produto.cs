using System.Collections.Generic;

namespace Mostremais.Domain.Entity 
{
    public class Produto  
    {
        public int ProdutoId { get; set; } 
        public string Nome { get; set; }
        public float Preco { get; set; }
        public int CategoriaId { get; set; }


        public int SubcategoriaId { get; set; }
        public int EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual ProdutoSubcategoria ProdutoSubcategoria { get; set; }
        public virtual ProdutoCategoria ProdutoCategoria { get; set; }

        public virtual ICollection<Venda> Vendas { get; set; }

    }
}
