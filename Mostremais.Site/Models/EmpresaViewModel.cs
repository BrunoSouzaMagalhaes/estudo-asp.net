using System.ComponentModel.DataAnnotations;

namespace Mostremais.Site.Models
{
    public class EmpresaViewModel
    {
        [Key]
        public int EmpresaId { get; set; }
        public string Nome { get; set; }
        public string Alias { get; set; }
    }
}