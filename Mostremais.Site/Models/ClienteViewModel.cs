using System.ComponentModel.DataAnnotations;

namespace Mostremais.Site.Models
{
    public class ClienteViewModel
    {
        [Key]
        public int ClienteId { get; set; }

        [Display(Name="Nome do Cliente")]
        public string Nome { get; set; }
        public EmpresaViewModel Empresa { get; set; }
        public int EmpresaId { get; set; } 
    }
}