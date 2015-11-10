////------------------------------------------------------------------------------
//// Author: Dev Peru
//// Generado el Dia: 2015_octubre_11 - 19_23_00 
////-------------------------  Controller Anuncio  ----------------------------------------
//using Entidad;
//using Negocio;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Data;

//using System.Web;
//using System.Web.Mvc;
//using PagedList;
//namespace Vista.Controllers
//{
//    public class AnuncioController : Controller
//    {
//        public ActionResult Index(string orden, string filtro, string busqueda, int? page)
//        {
//            try
//            {
//                //sdfsdfsdfsdf
//                ViewBag.nombreOrden = String.IsNullOrEmpty(orden) ? "nombre_desc" : "";
//                ViewBag.imagenOrden = String.IsNullOrEmpty(orden) ? "imagen_desc" : "";
//                ViewBag.descripcionOrden = String.IsNullOrEmpty(orden) ? "descripcion_desc" : "";
//                ViewBag.fechaHoraOrden = String.IsNullOrEmpty(orden) ? "fechaHora_desc" : "";
//                ViewBag.activoOrden = String.IsNullOrEmpty(orden) ? "activo_desc" : "";
//                ViewBag.idEmpresaOrden = String.IsNullOrEmpty(orden) ? "idEmpresa_desc" : "";
//                ViewBag.OrdenActual = orden;
//                if (busqueda != null)
//                {
//                    page = 1;
//                }
//                else
//                {
//                    busqueda = filtro;
//                }
//                ViewBag.filtro = busqueda;
//                var obj = from s in NAnuncio.Instancia.SelectAll()
//                          select s;
//                if (!String.IsNullOrEmpty(busqueda))
//                {
//                    obj = obj.Where(s => s.nombre.ToLower().Trim().Contains(busqueda.ToLower().Trim()));
//                }
//                switch (orden)
//                {
//                    case "nombre_desc":
//                        obj = obj.OrderByDescending(s => s.nombre);
//                        break;
//                    case "imagen_desc":
//                        obj = obj.OrderByDescending(s => s.imagen);
//                        break;
//                    case "descripcion_desc":
//                        obj = obj.OrderByDescending(s => s.descripcion);
//                        break;
//                    case "fechaHora_desc":
//                        obj = obj.OrderByDescending(s => s.fechaHora);
//                        break;
//                    case "activo_desc":
//                        obj = obj.OrderByDescending(s => s.activo);
//                        break;
//                    case "idEmpresa_desc":
//                        obj = obj.OrderByDescending(s => s.idEmpresa);
//                        break;
//                    default:
//                        obj = obj.OrderBy(s => s.nombre);
//                        break;
//                }
//                int pageSize = 10;
//                int pageNumber = (page ?? 1);
//                return View(obj.ToPagedList(pageNumber, pageSize));
//            }
//            catch (Exception)
//            {
//                return View();
//            }
//        }
//        public ActionResult Create()
//        {
//            return View();
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(Anuncio obj, int cboEmpresa,HttpPostedFileBase file)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    String extension;
//                    String ExcelPath;
//                    extension = System.IO.Path.GetExtension(Request.Files["file"].FileName) ;
//                    string nombreimg = System.DateTime.Now.ToString("yyyy_MMMM_dd_H_mm_ss_")+ Request.Files["file"].FileName;
//                    if (extension == ".jpg" || extension == ".png" || extension == ".JPG" || extension == ".PNG")
//                    {
//                        ExcelPath = Server.MapPath("~/Exports/") + nombreimg ;
//                        Request.Files["file"].SaveAs(ExcelPath);
//                        obj.imagen = nombreimg;

//                    }
//                        obj.fechaHora = System.DateTime.Now;
//                        obj.idEmpresa = cboEmpresa;
//                        NAnuncio.Instancia.Create(obj);
//                    }
//                return RedirectToAction("Index");

//            }
//            catch (Exception)
//            {
//                return View(obj);
//            }
//        }
//        [HttpPost]
//        public ActionResult Edit(int id)
//        {
//            try
//            {
//                Anuncio obj = NAnuncio.Instancia.Details(id);
//                return View(obj);
//            }
//            catch (Exception)
//            {
//                return RedirectToAction("Index");
//            }
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult EditSave(Anuncio obj, HttpPostedFileBase file)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    String extension;
//                    String ExcelPath;
//                    extension = System.IO.Path.GetExtension(Request.Files["file"].FileName);
//                    string nombreimg = System.DateTime.Now.ToString("yyyy_MMMM_dd_H_mm_ss_") + Request.Files["file"].FileName;
//                    if (extension == ".jpg" || extension == ".png" || extension == ".JPG" || extension == ".PNG")
//                    {
//                        ExcelPath = Server.MapPath("~/Exports/") + nombreimg;
//                        Request.Files["file"].SaveAs(ExcelPath);
//                        obj.imagen = nombreimg;

//                    }
//                    obj.fechaHora = System.DateTime.Now;
//                    NAnuncio.Instancia.Edit(obj);
//                    return RedirectToAction("Index");
//                }
//                return View("Edit", obj);
//            }
//            catch (Exception)
//            {
//                return RedirectToAction("Index");
//            }
//        }
//        [HttpPost]
//        public ActionResult Details(int id = 0)
//        {
//            try
//            {
//                Anuncio obj = NAnuncio.Instancia.Details(id);
//                return View(obj);
//            }
//            catch (Exception)
//            {
//                return RedirectToAction("Index");
//            }
//        }
//        [HttpPost]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            try
//            {
//                if (NAnuncio.Instancia.DeleteConfirmed(id))
//                {
//                    return Json("true", JsonRequestBehavior.AllowGet);
//                }
//                return Json("false", JsonRequestBehavior.AllowGet);
//            }
//            catch (Exception)
//            {
//                return Json("error", JsonRequestBehavior.AllowGet);
//            }
//        }
//        [HttpPost]
//        public ActionResult Disable(int id)
//        {
//            try
//            {
//                if (NAnuncio.Instancia.Disable(id))
//                {
//                    return Json("true", JsonRequestBehavior.AllowGet);
//                }
//                return Json("false", JsonRequestBehavior.AllowGet);
//            }
//            catch (Exception)
//            {
//                return Json("error", JsonRequestBehavior.AllowGet);
//            }
//        }
//    }
//}
