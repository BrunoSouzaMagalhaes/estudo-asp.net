namespace Mostremais.Domain.Entity
{
    public class ProdutoSubcategoria
    {
        public int SubcategoriaId { get; set; }
        public string Nome { get; set; }
        public int CategoriaId { get; set; }

        public virtual ProdutoCategoria Categoria { get; set; }
    }
}
