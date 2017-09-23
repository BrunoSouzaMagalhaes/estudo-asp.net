using System.ComponentModel.DataAnnotations;

namespace Mostremais.Site.Models
{
    public class ProdutoSubcategoriaViewModel
    {
        [Key]
        public int SubcategoriaId { get; set; }
        public string Nome { get; set; }
        public int CategoriaId { get; set; }
        public ProdutoCategoriaViewModel Categoria { get; set; }
    }
}