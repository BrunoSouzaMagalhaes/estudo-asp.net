using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Mostremais.Infra.Context;
using Mostremais.Site.Models;
using Mostremais.Application;
using Mostremais.Site.Helpers;
using System.Collections;
using Mostremais.Domain.Entity;
using System.Collections.Generic;
using AutoMapper;

namespace Mostremais.Site
{
    public class SubcategoriasController : Controller
    {
        private readonly ProdutoSubcategoriaService Service;
        public SubcategoriasController()
        {
            AutoMapperHelper.InitializeMapper();
            Service = new ProdutoSubcategoriaService();
        }
        public ActionResult Index()
        {
            IEnumerable<ProdutoSubcategoria> Subcategorias = Service.GetAll();
            var SubcategoriaVM = Mapper.Map<IEnumerable<ProdutoSubcategoria>, IEnumerable<ProdutoSubcategoriaViewModel> >(Subcategorias);
            return View(SubcategoriaVM);
        }


        public ActionResult Details(int? id)
        {
            ProdutoSubcategoria Subcategoria = Service.GetById(id.GetValueOrDefault());
            ProdutoSubcategoriaViewModel SubcategoriaVM = Mapper.Map<ProdutoSubcategoria, ProdutoSubcategoriaViewModel>(Subcategoria);
            return View(SubcategoriaVM);
        }


        public ActionResult Create()
        {
            ProdutoCategoriaService Categorias = new ProdutoCategoriaService();
            ViewBag.CategoriaId = new SelectList(Categorias.GetAll(), "CategoriaId", "Nome");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubcategoriaId,Nome,CategoriaId")] ProdutoSubcategoriaViewModel produtoSubcategoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                ProdutoSubcategoria Subcategoria = Mapper.Map<ProdutoSubcategoriaViewModel, ProdutoSubcategoria>(produtoSubcategoriaViewModel);
                Service.Insert(Subcategoria);
                return RedirectToAction("Index");
            }

            ProdutoCategoriaService Categorias = new ProdutoCategoriaService();
            ViewBag.CategoriaId = new SelectList(Categorias.GetAll(), "CategoriaId", "Nome");
            return View(produtoSubcategoriaViewModel);
        }
         
        public ActionResult Edit(int? id)
        { 
            ProdutoSubcategoria Subcategoria = Service.GetById(id.GetValueOrDefault());
            ProdutoSubcategoriaViewModel SubcategoriaVM = Mapper.Map<ProdutoSubcategoria, ProdutoSubcategoriaViewModel>(Subcategoria);

            ProdutoCategoriaService Categorias = new ProdutoCategoriaService();
            ViewBag.CategoriaId = new SelectList(Categorias.GetAll(), "CategoriaId", "Nome");

            return View(SubcategoriaVM);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubcategoriaId,Nome,CategoriaId")] ProdutoSubcategoriaViewModel produtoSubcategoriaViewModel)
        {
            if (ModelState.IsValid)
            { 
                ProdutoSubcategoria Subcategoria = Mapper.Map<ProdutoSubcategoriaViewModel, ProdutoSubcategoria>(produtoSubcategoriaViewModel);
                Service.Update(Subcategoria);
                return RedirectToAction("Index");
            }

            ProdutoCategoriaService Categorias = new ProdutoCategoriaService();
            ViewBag.CategoriaId = new SelectList(Categorias.GetAll(), "CategoriaId", "Nome");

            return View(produtoSubcategoriaViewModel);
        }


        public ActionResult Delete(int? id)
        {
            ProdutoSubcategoria Subcategoria = Service.GetById(id.GetValueOrDefault());
            ProdutoSubcategoriaViewModel SubcategoriaVM = Mapper.Map<ProdutoSubcategoria, ProdutoSubcategoriaViewModel>(Subcategoria);

            return View(SubcategoriaVM);
        }
         
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            ProdutoSubcategoria Subcategoria = Service.GetById(id.GetValueOrDefault());
            Service.Delete(Subcategoria);
            return RedirectToAction("Index");
        }
         
    }
}
