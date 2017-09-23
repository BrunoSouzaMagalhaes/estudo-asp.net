using Mostremais.Domain.Entity;
using Mostremais.Infra.Repository.EntityFramework;

namespace Mostremais.Application
{
    public class ProdutoCategoriaService : ServiceBase<ProdutoCategoria>
    {
        public ProdutoCategoriaService()
        {
            this.Repository = new ProdutoCategoriaRepository();
        }
    }
}
