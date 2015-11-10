//------------------------------------------------------------------------------
// Author: Julio Becerra Urbina
// Generado el Dia: 2015_noviembre_09 - 20_39_15 
//-------------------------  Controller CentroDeportivo  ----------------------------------------
using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace Vista.Controllers
{
    public class CentroDeportivoController : Controller
    {
        public ActionResult Index(string orden, string filtro, string busqueda, int? page)
        {
            try
            {
                ViewBag.direccionOrden = String.IsNullOrEmpty(orden) ? "direccion_desc" : "";
                ViewBag.telefonoOrden = String.IsNullOrEmpty(orden) ? "telefono_desc" : "";
                ViewBag.celularOrden = String.IsNullOrEmpty(orden) ? "celular_desc" : "";
                ViewBag.idDistritoOrden = String.IsNullOrEmpty(orden) ? "idDistrito_desc" : "";
                ViewBag.nroCanchasOrden = String.IsNullOrEmpty(orden) ? "nroCanchas_desc" : "";
                ViewBag.balonOrden = String.IsNullOrEmpty(orden) ? "balon_desc" : "";
                ViewBag.camisetasOrden = String.IsNullOrEmpty(orden) ? "camisetas_desc" : "";
                ViewBag.idEmpresaOrden = String.IsNullOrEmpty(orden) ? "idEmpresa_desc" : "";
                ViewBag.nombreOrden = String.IsNullOrEmpty(orden) ? "nombre_desc" : "";
                ViewBag.fotoOrden = String.IsNullOrEmpty(orden) ? "foto_desc" : "";
                ViewBag.latitudOrden = String.IsNullOrEmpty(orden) ? "latitud_desc" : "";
                ViewBag.longitudOrden = String.IsNullOrEmpty(orden) ? "longitud_desc" : "";
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
                var obj = from s in NCentroDeportivo.Instancia.SelectAll()
                          select s;
                if (!String.IsNullOrEmpty(busqueda))
                {
                    obj = obj.Where(s => s.direccion.ToLower().Trim().Contains(busqueda.ToLower().Trim()));
                }
                switch (orden)
                {
                    case "direccion_desc":
                        obj = obj.OrderByDescending(s => s.direccion);
                        break;
                    case "telefono_desc":
                        obj = obj.OrderByDescending(s => s.telefono);
                        break;
                    case "celular_desc":
                        obj = obj.OrderByDescending(s => s.celular);
                        break;
                    case "idDistrito_desc":
                        obj = obj.OrderByDescending(s => s.idDistrito);
                        break;
                    case "nroCanchas_desc":
                        obj = obj.OrderByDescending(s => s.nroCanchas);
                        break;
                    case "balon_desc":
                        obj = obj.OrderByDescending(s => s.balon);
                        break;
                    case "camisetas_desc":
                        obj = obj.OrderByDescending(s => s.camisetas);
                        break;
                    case "idEmpresa_desc":
                        obj = obj.OrderByDescending(s => s.idEmpresa);
                        break;
                    case "nombre_desc":
                        obj = obj.OrderByDescending(s => s.nombre);
                        break;
                    case "foto_desc":
                        obj = obj.OrderByDescending(s => s.foto);
                        break;
                    case "latitud_desc":
                        obj = obj.OrderByDescending(s => s.latitud);
                        break;
                    case "longitud_desc":
                        obj = obj.OrderByDescending(s => s.longitud);
                        break;
                    case "activo_desc":
                        obj = obj.OrderByDescending(s => s.activo);
                        break;
                    default:
                        obj = obj.OrderBy(s => s.direccion);
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
        public ActionResult Create(CentroDeportivo obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    NCentroDeportivo.Instancia.Create(obj);
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
                CentroDeportivo obj = NCentroDeportivo.Instancia.Details(id);
                return View(obj);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSave(CentroDeportivo obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    NCentroDeportivo.Instancia.Edit(obj);
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
                CentroDeportivo obj = NCentroDeportivo.Instancia.Details(id);
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
                if (NCentroDeportivo.Instancia.DeleteConfirmed(id))
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
                if (NCentroDeportivo.Instancia.Disable(id))
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