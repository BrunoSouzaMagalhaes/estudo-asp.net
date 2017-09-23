using Mostremais.Domain.Entity;
using Mostremais.Infra.Repository.EntityFramework;

namespace Mostremais.Application
{
    public class EmpresaService : ServiceBase<Empresa> {
         
        public EmpresaService()
        {
            this.Repository = new EmpresaRepository();  
        }
    }
}
