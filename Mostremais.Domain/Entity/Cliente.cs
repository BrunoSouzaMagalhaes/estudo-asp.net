namespace Mostremais.Domain.Entity
{
    public class Cliente
    { 
        public int ClienteId { get; set; }
        public string Nome { get; set; } 
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
