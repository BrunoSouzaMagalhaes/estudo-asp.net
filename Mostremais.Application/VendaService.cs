using Mostremais.Domain.Entity;
using Mostremais.Infra.Repository.EntityFramework;

namespace Mostremais.Application
{
    public class VendaService : ServiceBase<Venda>
    {
        public VendaService()
        {
            this.Repository = new VendaRepository();   
        }
    }
}
