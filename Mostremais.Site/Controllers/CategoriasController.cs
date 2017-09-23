using System.Web.Mvc;
using Mostremais.Domain.Entity;
using Mostremais.Site.Helpers;
using Mostremais.Application;
using AutoMapper;
using Mostremais.Site.Models;
using System.Collections.Generic;

namespace Mostremais.Site.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ProdutoCategoriaService CategoriaService;

        public CategoriasController()
        {
            AutoMapperHelper.InitializeMapper();
            CategoriaService = new ProdutoCategoriaService(); 
        }
         
        public ActionResult Index()
        {
            List<ProdutoCategoriaViewModel> CategoriasVM = new List<ProdutoCategoriaViewModel>();
            IEnumerable<ProdutoCategoria> Categorias = CategoriaService.GetAll();
             
           foreach(ProdutoCategoria categoria in Categorias){
               ProdutoCategoriaViewModel categoriaVm = Mapper.Map<ProdutoCategoria, ProdutoCategoriaViewModel>(categoria);
               CategoriasVM.Add(categoriaVm);
           }

            return View(CategoriasVM);
        }

       
        public ActionResult Details(int? id)
        {
            ProdutoCategoria Categoria = CategoriaService.GetById(id.GetValueOrDefault());
            ProdutoCategoriaViewModel CategoriaVM = Mapper.Map<ProdutoCategoria, ProdutoCategoriaViewModel>(Categoria);

            return View(CategoriaVM);
        }

         
      public ActionResult Create()
      {
          EmpresaService Empresa = new EmpresaService();  
          ViewBag.EmpresaId = new SelectList(Empresa.GetAll(), "EmpresaId", "Nome");
          return View();
      }
      

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Create([Bind(Include = "CategoriaId,Nome,EmpresaId")] ProdutoCategoriaViewModel produtoCategoriaVM)
      {
          if (ModelState.IsValid)
          {
                ProdutoCategoria Categoria = Mapper.Map<ProdutoCategoriaViewModel, ProdutoCategoria>(produtoCategoriaVM);
                CategoriaService.Insert(Categoria);
                return RedirectToAction("Index");
          }

          EmpresaService EmpresaSV = new EmpresaService();
          ViewBag.EmpresaId = new SelectList(EmpresaSV.GetAll(), "EmpresaId", "Nome", produtoCategoriaVM.EmpresaId);
          return View(produtoCategoriaVM);
      }

         
      public ActionResult Edit(int? id)
      {
            ProdutoCategoria Categoria = CategoriaService.GetById(id.GetValueOrDefault());
            ProdutoCategoriaViewModel CategoriaVM = Mapper.Map<ProdutoCategoria, ProdutoCategoriaViewModel>(Categoria);

            EmpresaService Empresa = new EmpresaService();
            ViewBag.EmpresaId = new SelectList(Empresa.GetAll(), "EmpresaId", "Nome", CategoriaVM.EmpresaId);

            return View(CategoriaVM);
      }
         

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Edit([Bind(Include = "CategoriaId,Nome,EmpresaId")] ProdutoCategoriaViewModel ProdutoCategoriaVM)
      {
          if (ModelState.IsValid)
          {
                ProdutoCategoria ProdutoCategoria = Mapper.Map<ProdutoCategoriaViewModel, ProdutoCategoria>(ProdutoCategoriaVM);
                CategoriaService.Update(ProdutoCategoria);
                return RedirectToAction("Index");
          }

          EmpresaService Empresa = new EmpresaService();
          ViewBag.EmpresaId = new SelectList(Empresa.GetAll(), "EmpresaId", "Nome", ProdutoCategoriaVM.EmpresaId);
          return View(ProdutoCategoriaVM);
      }

       
      public ActionResult Delete(int? id)
      {
        ProdutoCategoria Categoria = CategoriaService.GetById(id.GetValueOrDefault());
        ProdutoCategoriaViewModel CategoriaVM = Mapper.Map<ProdutoCategoria, ProdutoCategoriaViewModel>(Categoria);
        return View(CategoriaVM);
      }


      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public ActionResult DeleteConfirmed(int? id)
      {
        if(id == null){
                return RedirectToAction("Index");
        }
        ProdutoCategoria Categoria= CategoriaService.GetById(id.GetValueOrDefault());
        CategoriaService.Delete(Categoria);
        return RedirectToAction("Index");
      }
      
    }
}
