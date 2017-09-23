using Mostremais.Domain.Entity;
using Mostremais.Infra.Repository.EntityFramework;

namespace Mostremais.Application
{
    public class ProdutoService : ServiceBase<Produto>
    {
        public ProdutoService()
        {
            this.Repository = new ProdutoReposity();  
        }
    }
}
