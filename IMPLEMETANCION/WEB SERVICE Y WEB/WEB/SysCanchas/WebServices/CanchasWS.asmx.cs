using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Entidad;
using Negocio;
namespace SysCanchas.WebServices
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class CanchasWS : System.Web.Services.WebService
    {
        [WebMethod]
        public EUsuario Login(string usuario, string clave)
        {
            Usuario obj = new Usuario();
            obj = NUsuario.Instancia.Login(usuario, clave);
            EUsuario eobj = new EUsuario();
            eobj.nick = obj.nick;
            eobj.activo = obj.activo;
            return eobj;
        }
        
        [WebMethod]
        public bool registrarPelotero(string nombre, string apellidos, int celular,
            string email, string nick, string clave)
        {
            Deportista pelotero = new Deportista();
            Usuario usuario = new Usuario();
            pelotero.nombre = nombre;
            pelotero.apellidos = apellidos;
            pelotero.celular = celular;
            pelotero.email = email;
            pelotero.activo = true;

            pelotero.Usuario = new Usuario();
            usuario.nick = nick;
            usuario.clave = clave;
            usuario.idTipoUsuario = 3;
            usuario.activo = true;
            pelotero.Usuario = usuario;
            return NDeportista.Instancia.Create(pelotero);
        }

        [WebMethod]
        public bool registrarReserva(string fecha, int idUsuario, int idCancha, string horaInicio, string horaFin)
        {
            Reserva reserva = new Reserva();
            reserva.fechaHora = Convert.ToDateTime(fecha);
            reserva.idUsuario = idUsuario;
            reserva.idCancha = idCancha;
            TimeSpan horaInicio2 = TimeSpan.Parse(horaInicio);
            TimeSpan horaFin2 = TimeSpan.Parse(horaFin);
            reserva.horaInicio = horaInicio2;
            reserva.horaFin = horaFin2;
            reserva.activo = true;
            return NReserva.Instancia.Create(reserva);
        }

        [WebMethod]
        public List<ECentroDeportivo> listarCentrosDeportivos(){

            List<CentroDeportivo> listilla = NCentroDeportivo.Instancia.SelectAllActivo();

            List<ECentroDeportivo> lista = new List<ECentroDeportivo>();

            foreach(var item in listilla){
                ECentroDeportivo obj = new ECentroDeportivo();
                obj.id = item.id;
                obj.nombre = item.nombre;
                obj.direccion = item.direccion;
                obj.telefono = item.telefono;
                obj.balon = Convert.ToBoolean(item.balon);
                obj.camisetas = Convert.ToBoolean(item.camisetas);
                obj.latitud = Convert.ToDouble( item.latitud);
                obj.longitud =Convert.ToDouble( item.longitud);

                lista.Add(obj);
            }

            return lista;
        
        }



        [WebMethod]
        public List<ECampo> listarCamposPorCentroDeportivo(int idCentroDeportivo) {

            List<CentroDeportivoCampo> listilla = NCentroDeportivo.Instancia.SelectAllByCentroDeportivo(idCentroDeportivo);
            List<ECampo> lista = new List<ECampo>();

            foreach(var item in listilla){
                ECampo obj = new ECampo();
                obj.id = item.Campo.id;
                obj.ancho = item.Campo.ancho;
                obj.largo = item.Campo.largo;
                obj.precio = item.Campo.precio;
                lista.Add(obj);
            }

            return lista;
            
        }

       /* [WebMethod]
        public List<EPelotero> listarPeloteros(string nombre, int idPelotero)
        {
            List<Pelotero> lista = new List<Pelotero>();
            List<EPelotero> elista = new List<EPelotero>();
            lista = NPelotero.Instancia.SelectAll(nombre,idPelotero);
            foreach (var item in lista)
	        {
                EPelotero eobj= new EPelotero();
                eobj.id = item.id;
                eobj.nombre=item.nombre;
                eobj.apellidos=item.apellidos;
		        elista.Add(eobj);
	        }
            return elista;
        }

        [WebMethod]
        public EPelotero verPerfil(int id)
        {
            Pelotero obj = new Pelotero();
            obj = NPelotero.Instancia.Details(id);
            EPelotero eobj = new EPelotero();
            eobj.nombre = obj.nombre;
            eobj.apellidos = obj.apellidos;
            eobj.email = obj.email;
            eobj.celular = obj.celular;

            return eobj;
        }*/
        /*
        [WebMethod]
        public bool solicitudAmistad(int idPelotero,int idReceptor)
        {
            return NPelotero.Instancia.solicitudAmistad(idPelotero,idReceptor);
        }

        [WebMethod]
        public List<ESolicitudAmistad> verSolicitudes(int idPelotero)
        {
            List<SolicitudAmistad> lista = new List<SolicitudAmistad>();
            List<ESolicitudAmistad> elista = new List<ESolicitudAmistad>();
            lista = NSolicitudAmistad.Instancia.SelectAll(idPelotero);

            foreach (var item in lista)
            {
                ESolicitudAmistad obj = new ESolicitudAmistad();
                obj.activo = item.activo;
                obj.estado = item.estado;
                obj.fechaHora = item.fechaHora;
                obj.id = item.id;
                obj.idPelotero = item.id;
                obj.Pelotero = new Pelotero();
                obj.Pelotero.nombre = item.Pelotero.nombre;
                obj.Pelotero.apellidos = item.Pelotero.apellidos;
                obj.Pelotero.email = item.Pelotero.email;
                obj.Pelotero.celular = item.Pelotero.celular;
                elista.Add(obj);
                
            }
            return elista;
        }

        [WebMethod]
        public bool responderSolicitudAmistad(int idPelotero, int idSolicitante, string respuesta)
        {
            //id Pelotero es el id de la sesion, idsolicitante es del pelotero que envio la solicitud
            return NPelotero.Instancia.responderSolicitudAmistad(idPelotero,idSolicitante,respuesta);
        }*/

    }
}