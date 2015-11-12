using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SysCanchas.Controllers
{
    public class IntranetController : Controller
    {
        // GET: Intranet
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Salir()
        {
            try
            {
                Session.Clear();
                Session.Abandon();
                return RedirectToAction("Login", "Intranet");
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "Intranet");
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerificarAcceso(string prusuario, string prpassword)
        {
            Usuario objUsuario = NUsuario.Instancia.Login(prusuario, prpassword);
            try
            {
                if (objUsuario != null)
                {
                    Usuario usuario = new Usuario();
                    usuario.id = objUsuario.id;
                    usuario.nick = objUsuario.nick;
                    usuario.TipoUsuario = new TipoUsuario();
                    usuario.TipoUsuario.id = objUsuario.TipoUsuario.id;
                    usuario.TipoUsuario.nombre = objUsuario.TipoUsuario.nombre;

                    Session["Usuario"] = usuario;
                    Session["Cargo"] = usuario.TipoUsuario.id;
                    int idempresa = objUsuario.Empresa.ElementAt(0).id;
                    Session["idEmpresa"] = idempresa;
                    Session["idUsuario"] = usuario.id;

                    return Json(usuario, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("error", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {

                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DepartamentoLista(bool isActivo)
        {
            if (isActivo)
                return View("_ListaDepartamentoPartial", NDepartamento.Instancia.SelectAllActivo());
            else
                return View("_ListaDepartamentoPartial", NDepartamento.Instancia.SelectAll());
        }

        public ActionResult ProvinciaByDepartamento(int idDepartamento)
        {
            if (idDepartamento == -1)
                return View("_ListaProvinciaPartial", null);
            else
                return View("_ListaProvinciaPartial", NProvincia.Instancia.SelectAllByIdDepartamento(idDepartamento));
        }

        public ActionResult DistritoByProvincia(int idProvincia)
        {
            if (idProvincia == -1)
                return View("_ListaDistritoPartial", null);
            else
                return View("_ListaDistritoPartial", NDistrito.Instancia.SelectAllByIdProvincia(idProvincia));
        }        
        public ActionResult SelectAllEmpresaActivo()
        {
            return View("_ListaEmpresaPartial", NEmpresa.Instancia.SelectAllActivo());
        }

        public ActionResult SelectAllCanchaActivo() {
            return View("_ListaCanchaPartial",NCampo.Instancia.SelectAllActivo());
        }

        public ActionResult SelectAllByEmpresaForReserva() {
            return View("_ListaCanchaPartial", NCampo.Instancia.SelectAllByEmpresaForReserva((int)Session["idEmpresa"]));
        }

        public ActionResult SelectAllByEmpresaForEditReserva()
        {
            return View("_ListaCanchaPartial", NCampo.Instancia.SelectAllByEmpresaForEditReserva((int)Session["idEmpresa"]));
        }
        public ActionResult SelectCentroDeportivobyEmpresa(int idEmpresa)
        {
            return View("_ListaCentroDeportivoPartial", NCentroDeportivo.Instancia.SelectAllbyEmpresa(idEmpresa));
        }

        public ActionResult CampobyCentroDeportivo(int idCentroDeportivo)
        {
            if (idCentroDeportivo==-1)
            {
                return View("_ListaCampoPartial",null);
            }
            return View("_ListaCampoPartial", NCampo.Instancia.SelectAllbyCentroDeportivo(idCentroDeportivo));
        }
              
    }
}