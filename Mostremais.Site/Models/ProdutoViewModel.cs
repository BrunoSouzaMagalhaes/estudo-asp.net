using System.ComponentModel.DataAnnotations;

namespace Mostremais.Site.Models
{
    public class ProdutoViewModel
    { 
        [Key]
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        public ProdutoCategoriaViewModel ProdutoCategoria { get; set; }
        public ProdutoSubcategoriaViewModel ProdutoSubcategoria { get; set; }
    }
}