using Mostremais.Domain.Entity;
using Mostremais.Infra.Repository.EntityFramework;

namespace Mostremais.Application
{
    public class ProdutoSubcategoriaService : ServiceBase<ProdutoSubcategoria>
    {
        public ProdutoSubcategoriaService()
        {
            this.Repository = new ProdutoSubcategoriaRepository();
        }
    }
}
