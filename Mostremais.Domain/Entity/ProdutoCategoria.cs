namespace Mostremais.Domain.Entity 
{
    public class ProdutoCategoria
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
