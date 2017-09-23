using System.Web.Mvc;
using Mostremais.Application;
using Mostremais.Domain.Entity;
using System.Collections.Generic;
using Mostremais.Site.Models;
using Mostremais.Site.Helpers;
using AutoMapper;

namespace Mostremais.Site.Controllers
{
    public class EmpresaController : Controller
    {
        public EmpresaController()
        {
            AutoMapperHelper.InitializeMapper(); 
        }

        public ActionResult Index()
        {
            EmpresaService Service = new EmpresaService();
            IEnumerable<Empresa> Empresas = Service.GetAll();

            List<EmpresaViewModel> ListaEmpresaVM = new List<EmpresaViewModel>();

            foreach (Empresa Empresa in Empresas)
            {
                EmpresaViewModel EmpresaVM = Mapper.Map<Empresa, EmpresaViewModel>(Empresa);
                ListaEmpresaVM.Add(EmpresaVM);
                /*
                ListaEmpresaVM.Add( new EmpresaViewModel()
                {
                    EmpresaId = Empresa.EmpresaId,
                    Nome = Empresa.Nome,
                    Alias = Empresa.Alias
                });
                */
            }            

            return View(ListaEmpresaVM);
        }

         
     public ActionResult Details(int? id)
     { 
         EmpresaService Service = new EmpresaService();
         EmpresaViewModel EmpresaVm = Mapper.Map<Empresa, EmpresaViewModel>(Service.GetById(id.GetValueOrDefault()));

         return View(EmpresaVm);
     }

         
     public ActionResult Create()
     {
         return View();
     }
         
     [HttpPost]
     [ValidateAntiForgeryToken]
     public ActionResult Create([Bind(Include = "EmpresaId,Nome,Alias")] EmpresaViewModel EmpresaVM)
    {
            if (ModelState.IsValid){

                EmpresaService Servico = new EmpresaService();
                Empresa Empresa = Mapper.Map<EmpresaViewModel, Empresa>(EmpresaVM);
                Servico.Insert(Empresa);

                return RedirectToAction("Index");
            }

         return View(EmpresaVM);
     }

        
    public ActionResult Edit(int? id)
    {
        EmpresaService Servico = new EmpresaService();
        EmpresaViewModel EmpresaVM = Mapper.Map<Empresa, EmpresaViewModel>(Servico.GetById(id.GetValueOrDefault()));
        return View(EmpresaVM);
    }

         
   [HttpPost]
   [ValidateAntiForgeryToken]
   public ActionResult Edit([Bind(Include = "EmpresaId,Nome,Alias")] EmpresaViewModel EmpresaVM)
   {
       if (ModelState.IsValid)
       {
                EmpresaService Servico = new EmpresaService();
                Empresa Empresa = Mapper.Map<EmpresaViewModel, Empresa>(EmpresaVM);
                Servico.Update(Empresa);

           return RedirectToAction("Index");
       }
       return View(EmpresaVM);
   }
         
   public ActionResult Delete(int? id)
   {
       EmpresaService Service = new EmpresaService();
       EmpresaViewModel EmpresaVM = Mapper.Map<Empresa, EmpresaViewModel>(Service.GetById(id.GetValueOrDefault()));
       return View(EmpresaVM); 
   }

       
  [HttpPost, ActionName("Delete")]
  [ValidateAntiForgeryToken]
  public ActionResult DeleteConfirmed(int? id)
  {
        if(id == null)
        {
            RedirectToAction("Index");
        }
        EmpresaService Service = new EmpresaService();
        Empresa empresa = Service.GetById(id.GetValueOrDefault());
        Service.Delete(empresa);
      return RedirectToAction("Index");
  }
         

    }
}
