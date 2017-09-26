using System.Collections.Generic;
using System.Web.Mvc;
using Mostremais.Site.Models;
using Mostremais.Site.Helpers;
using Mostremais.Application;
using Mostremais.Domain.Entity;
using AutoMapper;
 
namespace Mostremais.Site.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ProdutoService Service;

        public ProdutosController()
        {
            AutoMapperHelper.InitializeMapper();
            Service = new ProdutoService();
        }

        public ActionResult Index()
        {
            IEnumerable<Produto> Subcategorias = Service.GetAll();
            var SubcategoriaVM = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(Subcategorias);
            return View(SubcategoriaVM);
        }
         
        public ActionResult Details(int? id)
        {
            Produto Produto = Service.GetById(id.GetValueOrDefault());
            ProdutoViewModel SubcategoriaVM = Mapper.Map<Produto, ProdutoViewModel>(Produto);
            return View(SubcategoriaVM);
        } 

        public ActionResult Create()
        {
            ProdutoViewModel produtoVM = new ProdutoViewModel();
            ViewBag.Categorias = produtoVM.SelectCategorias();
            ViewBag.Subcategorias = produtoVM.SelectSubcategorias();
            ViewBag.Empresas = produtoVM.SelectEmpresas();

            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoId,Nome,Preco, EmpresaId, CategoriaId, SubcategoriaId")] ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                Produto Produto = Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);
                Service.Insert(Produto);
                return RedirectToAction("Index");
            }
             
            ViewBag.Categorias = produtoViewModel.SelectCategorias();
            ViewBag.Subcategorias = produtoViewModel.SelectSubcategorias();
            ViewBag.Empresas = produtoViewModel.SelectEmpresas();
             
            return View(produtoViewModel);
        }


        public ActionResult Edit(int? id)
        {

            Produto Produto = Service.GetById(id.GetValueOrDefault());
            ProdutoViewModel ProdutoVM = Mapper.Map<Produto, ProdutoViewModel>(Produto);

            ViewBag.Categorias = ProdutoVM.SelectCategorias();
            ViewBag.Subcategorias = ProdutoVM.SelectSubcategorias();
            ViewBag.Empresas = ProdutoVM.SelectEmpresas();

            return View(ProdutoVM);
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoId,Nome,Preco, EmpresaId, CategoriaId, SubcategoriaId")] ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                Produto Produto = Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);
                Service.Update(Produto);
                return RedirectToAction("Index");
            }

            ViewBag.Categorias = produtoViewModel.SelectCategorias();
            ViewBag.Subcategorias = produtoViewModel.SelectSubcategorias();
            ViewBag.Empresas = produtoViewModel.SelectEmpresas();
             
            return View(produtoViewModel);
        }


        public ActionResult Delete(int? id)
        {
            Produto Produto = Service.GetById(id.GetValueOrDefault());
            ProdutoViewModel ProdutoVM = Mapper.Map<Produto, ProdutoViewModel>(Produto);

            return View(ProdutoVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Produto Produto = Service.GetById(id.GetValueOrDefault());
            Service.Delete(Produto);
            return RedirectToAction("Index");
        }
         
    }
}
