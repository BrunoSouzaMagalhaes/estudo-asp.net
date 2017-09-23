using System.ComponentModel.DataAnnotations;

namespace Mostremais.Site.Models
{
    public class ProdutoCategoriaViewModel
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required]
        public string Nome { get; set; }
        public int EmpresaId { get; set; }
        public virtual EmpresaViewModel Empresa { get; set; }
    }
}