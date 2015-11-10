//------------------------------------------------------------------------------
// Author: Dev Peru
// Generado el Dia: 2015_octubre_11 - 19_23_00 
//-------------------------  Controller Pelotero  ----------------------------------------
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
    public class PeloteroController : Controller
    {
        public ActionResult Index(string orden, string filtro, string busqueda, int? page)
        {
            try
            {
                ViewBag.nombreOrden = String.IsNullOrEmpty(orden) ? "nombre_desc" : "";
                ViewBag.apellidosOrden = String.IsNullOrEmpty(orden) ? "apellidos_desc" : "";
                ViewBag.idUsuarioOrden = String.IsNullOrEmpty(orden) ? "idUsuario_desc" : "";
                ViewBag.celularOrden = String.IsNullOrEmpty(orden) ? "celular_desc" : "";
                ViewBag.emailOrden = String.IsNullOrEmpty(orden) ? "email_desc" : "";
                ViewBag.activoOrden = String.IsNullOrEmpty(orden) ? "activo_desc" : "";
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
                var obj = from s in NPelotero.Instancia.SelectAll()
                          select s;
                if (!String.IsNullOrEmpty(busqueda))
                {
                    obj = obj.Where(s => s.nombre.ToLower().Trim().Contains(busqueda.ToLower().Trim()));
                }
                switch (orden)
                {
                    case "nombre_desc":
                        obj = obj.OrderByDescending(s => s.nombre);
                        break;
                    case "apellidos_desc":
                        obj = obj.OrderByDescending(s => s.apellidos);
                        break;
                    case "idUsuario_desc":
                        obj = obj.OrderByDescending(s => s.idUsuario);
                        break;
                    case "celular_desc":
                        obj = obj.OrderByDescending(s => s.celular);
                        break;
                    case "email_desc":
                        obj = obj.OrderByDescending(s => s.email);
                        break;
                    case "activo_desc":
                        obj = obj.OrderByDescending(s => s.activo);
                        break;
                    default:
                        obj = obj.OrderBy(s => s.nombre);
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
        public ActionResult Create(Pelotero obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    NPelotero.Instancia.Create(obj);
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
                Pelotero obj = NPelotero.Instancia.Details(id);
                return View(obj);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSave(Pelotero obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    NPelotero.Instancia.Edit(obj);
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
                Pelotero obj = NPelotero.Instancia.Details(id);
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
                if (NPelotero.Instancia.DeleteConfirmed(id))
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
                if (NPelotero.Instancia.Disable(id))
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
