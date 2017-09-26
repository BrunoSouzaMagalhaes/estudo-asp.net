using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Mostremais.Domain.Entity;
using Mostremais.Application;
using Mostremais.Site.Helpers;
using System.Collections.Generic;
using Mostremais.Site.Models;
using AutoMapper;

namespace Mostremais.Site.Controllers
{
    public class VendaController : Controller
    {
        public readonly VendaService Service;
        public VendaController()
        {
            AutoMapperHelper.InitializeMapper();
            Service = new VendaService();
        }
        public ActionResult Index()
        {
            IEnumerable<VendaViewModel> VendasVm = Mapper.Map<IEnumerable<Venda>, IEnumerable<VendaViewModel> >(Service.GetAll());
            return View(VendasVm);
        }

        
        // GET: Venda/Details/5
        public ActionResult Details(int? id)
        {
            Venda Venda = new Venda();

            Venda.ClienteId = 1;
            Venda.EmpresaId = 1;

            ProdutoService ProdutoSV = new ProdutoService();
            Venda.Produtos = new List<Produto>();
            Venda.Produtos.Add(ProdutoSV.GetById(1));
            
            /*  
            Venda.Produtos = new List<Produto>(); 
            Venda.Produtos.Add(new Produto
            {
                ProdutoId = 1,
                CategoriaId = 1,
                SubcategoriaId = 1,
                EmpresaId = 1,
                Nome = "TESTE"
            });
            */
            Service.Insert(Venda);
            return RedirectToAction("Index"); 
        }

      
    }
}
