//------------------------------------------------------------------------------
// Author: Dev Peru
// Generado el Dia: 2015_octubre_11 - 19_23_00 
//-------------------------  Controller Campo  ----------------------------------------
using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

using System.Web;
using System.Web.Mvc;
using PagedList;
namespace Vista.Controllers
{
 //dgdfg
    public class CampoController : Controller
    {
        public ActionResult Index(string orden, string filtro, string busqueda, int? page)
        {
            try
            {
                ViewBag.largoOrden = String.IsNullOrEmpty(orden) ? "largo_desc" : "";
                ViewBag.anchoOrden = String.IsNullOrEmpty(orden) ? "ancho_desc" : "";
                ViewBag.precioOrden = String.IsNullOrEmpty(orden) ? "precio_desc" : "";
                ViewBag.activoOrden = String.IsNullOrEmpty(orden) ? "activo_desc" : "";
                ViewBag.tipoCampoOrden = String.IsNullOrEmpty(orden) ? "tipoCampo_desc" : "";
                ViewBag.OrdenActual = orden;
                if (busqueda != null)
                {
                    page = 1;
                }
                else
                {
                    busqueda = filtro;
                }
                ViewBag.filtro = busqueda;
                var obj = from s in NCampo.Instancia.SelectAll()
                          select s;
                
                switch (orden)
                {
                    case "largo_desc":
                        obj = obj.OrderByDescending(s => s.largo);
                        break;
                    case "ancho_desc":
                        obj = obj.OrderByDescending(s => s.ancho);
                        break;
                    case "precio_desc":
                        obj = obj.OrderByDescending(s => s.precio);
                        break;
                    case "activo_desc":
                        obj = obj.OrderByDescending(s => s.activo);
                        break;
                    case "tipoCampo_desc":
                        obj = obj.OrderByDescending(s => s.tipoCampo);
                        break;
                    default:
                        obj = obj.OrderBy(s => s.largo);
                        break;
                }
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(obj.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception)
            {
                return View();
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Campo obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    NCampo.Instancia.Create(obj);
                }
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return View(obj);
            }
        }
        [HttpPost]
        public ActionResult Edit(int id)
        {
            try
            {
                Campo obj = NCampo.Instancia.Details(id);
                return View(obj);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSave(Campo obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    NCampo.Instancia.Edit(obj);
                    return RedirectToAction("Index");
                }
                return View("Edit", obj);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Details(int id = 0)
        {
            try
            {
                Campo obj = NCampo.Instancia.Details(id);
                return View(obj);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (NCampo.Instancia.DeleteConfirmed(id))
                {
                    return Json("true", JsonRequestBehavior.AllowGet);
                }
                return Json("false", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Disable(int id)
        {
            try
            {
                if (NCampo.Instancia.Disable(id))
                {
                    return Json("true", JsonRequestBehavior.AllowGet);
                }
                return Json("false", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
    }
}