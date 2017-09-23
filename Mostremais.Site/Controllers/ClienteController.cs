using System.Collections.Generic;
using System.Web.Mvc;
using Mostremais.Site.Models;
using Mostremais.Site.Helpers;
using Mostremais.Application;
using AutoMapper;
using Mostremais.Domain.Entity;

namespace Mostremais.Site.Controllers
{
    public class ClienteController : Controller 
    {
        private readonly ClienteService Service;
        public ClienteController()
        {
            Service = new ClienteService();
            AutoMapperHelper.InitializeMapper();
        } 

        public ActionResult Index()
        { 
            IEnumerable<Cliente> clientes = Service.GetAll();
            List<ClienteViewModel> ListClienteVm = new List<ClienteViewModel>();

            foreach(Cliente cli in clientes)
            {
                ClienteViewModel Cliente = Mapper.Map<Cliente, ClienteViewModel>(cli);
                ListClienteVm.Add(Cliente);
            }
             
            return View(ListClienteVm);
        }

        
        public ActionResult Details(int? id)
        { 
            ClienteViewModel ClienteVM = Mapper.Map<Cliente, ClienteViewModel>(Service.GetById(id.GetValueOrDefault()));
            return View(ClienteVM);
        }
         

       public ActionResult Create()
       {
            EmpresaService EmpresaServ = new EmpresaService();

            ViewBag.empresas = new SelectList(
                    EmpresaServ.GetAll(),
                    "EmpresaId",
                    "Nome"
                );

           return View();
       }


       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult Create([Bind(Include = "ClienteId,Nome,EmpresaId")] ClienteViewModel clienteVM)
       {
            if (ModelState.IsValid) 
            {
                Cliente cliente = Mapper.Map<ClienteViewModel, Cliente>(clienteVM);
                Service.Insert(cliente);
                return RedirectToAction("Index");
            }

           return View(clienteVM);
       }

       // GET: Cliente/Edit/5
       public ActionResult Edit(int? id)
       {
           Cliente cliente = Service.GetById(id.GetValueOrDefault());
           ClienteViewModel ClienteVm = Mapper.Map<Cliente, ClienteViewModel>(cliente);

           EmpresaService Empresa = new EmpresaService(); 

           ViewBag.Empresas = new SelectList(
                   Empresa.GetAll(),
                   "EmpresaId",
                   "Nome"
               );

            return View(ClienteVm);
       }


       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult Edit([Bind(Include = "ClienteId,Nome, EmpresaId")] ClienteViewModel clienteVM)
       {
           if (ModelState.IsValid)
           {
                Cliente cliente = Mapper.Map<ClienteViewModel, Cliente>(clienteVM);
                Service.Update(cliente);
               return RedirectToAction("Index");
           }
           return View(clienteVM);
       }
         
       public ActionResult Delete(int? id)
       {
           Cliente cliente = Service.GetById(id.GetValueOrDefault());
           ClienteViewModel clienteVM = Mapper.Map<Cliente, ClienteViewModel>(cliente);
           return View(clienteVM);
       }
         
       [HttpPost, ActionName("Delete")]
       [ValidateAntiForgeryToken]
       public ActionResult DeleteConfirmed(int? id)
       {
            Cliente cliente = Service.GetById(id.GetValueOrDefault());
            if(cliente != null)
                Service.Delete(cliente);
           return RedirectToAction("Index");
       }

      
    }
}
