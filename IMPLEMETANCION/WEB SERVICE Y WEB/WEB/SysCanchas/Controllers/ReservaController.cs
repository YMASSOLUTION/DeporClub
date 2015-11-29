//------------------------------------------------------------------------------
// Author: Dev Peru
// Generado el Dia: 2015_octubre_11 - 19_23_00 
//-------------------------  Controller Reserva  ----------------------------------------
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
    public class ReservaController : Controller
    {
        public ActionResult Index(string orden, string filtro, string busqueda, int? page)
        {
            try
            {
                ViewBag.fechaHoraOrden = String.IsNullOrEmpty(orden) ? "fechaHora_desc" : "";
                ViewBag.idUsuarioOrden = String.IsNullOrEmpty(orden) ? "idUsuario_desc" : "";
                ViewBag.idCanchaOrden = String.IsNullOrEmpty(orden) ? "idCancha_desc" : "";
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
                var obj = from s in NReserva.Instancia.SelectAll()
                          select s;
                if (!String.IsNullOrEmpty(busqueda))
                {
                    //obj = obj.Where(s => s.Cancha.Empresa.nombre.Contains(busqueda.ToLower().Trim()));
                }
                switch (orden)
                {
                   
                    case "idUsuario_desc":
                        obj = obj.OrderByDescending(s => s.idUsuario);
                        break;
                    case "idCancha_desc":
                        obj = obj.OrderByDescending(s => s.idCancha);
                        break;
                    default:
                        obj = obj.OrderByDescending(s => s.activo);
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
            if (Session["Usuario"] != null)
            {
                ViewBag.idEmpresa = (int)Session["idEmpresa"];
                return View();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reserva obj, int cboCampo)
        {
            try
            {
                obj.activo = true;
                if (ModelState.IsValid)
                {
                    obj.idCancha = cboCampo;
                    obj.idUsuario = (int)Session["idUsuario"];

                   

                    if (NReserva.Instancia.Create(obj))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.idEmpresa = (int)Session["idEmpresa"];
                        ViewBag.error = "La cancha seleccionada ya ha sido reservada en el horario escogido.";
                        return View(obj);
                    }
                }
                else {
                    return RedirectToAction("Index");
                }
                

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
                Reserva obj = NReserva.Instancia.Details(id);
                return View(obj);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSave(Reserva obj, int cboCancha, int initialcancha, DateTime initialFecha
            , TimeSpan initialHoraInicio,TimeSpan initialHoraFin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if ((cboCancha == initialcancha) && (obj.fechaHora == initialFecha) && (obj.horaInicio == initialHoraInicio)
                        && (obj.horaFin == initialHoraFin))
                    {
                        return RedirectToAction("Index");
                    }

                    obj.idUsuario = (int)Session["idUsuario"];
                    obj.idCancha = cboCancha;
                    if (NReserva.Instancia.Edit(obj))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.error = "La cancha seleccionada ya ha sido reservada en el horario escogido.";
                        return View("Edit", obj);
                    }


                }
                else {
                    return View("Edit", obj);
                }
                
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
                Reserva obj = NReserva.Instancia.Details(id);
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
                if (NReserva.Instancia.DeleteConfirmed(id))
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
                if (NReserva.Instancia.Disable(id))
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
        public JsonResult listarHorarioDisponible(string fecha, int idcampo)
        {
            List<EHorario> listHorario = new List<EHorario>();
            listHorario = NReserva.Instancia.SelectHorariosDisponiblesParaReserva(Convert.ToDateTime(fecha), idcampo);
            return Json(listHorario, JsonRequestBehavior.AllowGet);
        }
    }
}
