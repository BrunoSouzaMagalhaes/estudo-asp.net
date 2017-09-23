using Mostremais.Domain.Entity;
using Mostremais.Infra.Repository.EntityFramework;
using System.Collections.Generic;

namespace Mostremais.Application
{
    public class ClienteService : ServiceBase<Cliente> {
         
        public ClienteService()
        {
            this.Repository = new ClienteRepository(); 
        }
    }

    
}
