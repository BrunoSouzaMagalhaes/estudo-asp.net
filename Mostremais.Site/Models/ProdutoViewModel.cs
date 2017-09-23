using Mostremais.Application;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Mostremais.Site.Models
{
    public class ProdutoViewModel
    { 
        [Key]
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
        public int EmpresaId { get; set; }
        public int CategoriaId { get; set; }
        public int SubcategoriaId { get; set; }

        public ProdutoCategoriaViewModel ProdutoCategoria { get; set; }
        public ProdutoSubcategoriaViewModel ProdutoSubcategoria { get; set; }
        public EmpresaViewModel Empresa { get; set; }

        public SelectList SelectCategorias()
        {
            ProdutoCategoriaService Categorias = new ProdutoCategoriaService();
            return new SelectList(Categorias.GetAll(), "CategoriaId", "Nome");
        }

        public SelectList SelectSubcategorias()
        { 
            ProdutoSubcategoriaService Subcategorias = new ProdutoSubcategoriaService();
            return new SelectList(Subcategorias.GetAll(), "SubcategoriaId", "Nome");
        }

        public SelectList SelectEmpresas()
        {
            EmpresaService Empresas = new EmpresaService();
            return new SelectList(Empresas.GetAll(), "EmpresaId", "Nome");
        }
         
    }
}