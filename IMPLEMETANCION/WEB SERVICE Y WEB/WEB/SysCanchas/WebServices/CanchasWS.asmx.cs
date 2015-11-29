using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Entidad;
using Negocio;
using System.Globalization;
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
            eobj.id = obj.id;
            eobj.nick = obj.nick;
            eobj.activo = obj.activo;
            eobj.idDeportista = obj.Deportista.ElementAt(0).id;
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
        public bool registrarReserva(string fecha, int idUsuario, int idCancha, string[] horaInicio, string[] horaFin)
        {
            bool flag = false;

            for (int i = 0; i < horaInicio.Length; i++)
            {
                Reserva reserva = new Reserva();
                reserva.fecha = Convert.ToDateTime(fecha);
                reserva.idUsuario = idUsuario;
                reserva.idCancha = idCancha;

                TimeSpan horaInicio2 = DateTime.ParseExact(horaInicio[i], "HH", CultureInfo.InvariantCulture).TimeOfDay;
                TimeSpan horaFin2 = DateTime.ParseExact(horaFin[i], "HH", CultureInfo.InvariantCulture).TimeOfDay;
                reserva.horaInicio = horaInicio2;
                reserva.horaFin = horaFin2;
                reserva.activo = true;

                if (NReserva.Instancia.Create(reserva))
                {
                    flag = true;
                }
            }


            if (flag)
                return true;
            else
                return false;

            
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

            List<Campo> listilla = NCampo.Instancia.SelectAllByCentroDeportivo(idCentroDeportivo);
            List<ECampo> lista = new List<ECampo>();

            foreach(var item in listilla){
                ECampo obj = new ECampo();
                obj.id = item.id;
                obj.ancho = item.ancho;
                obj.largo = item.largo;
                obj.precio = item.precio;
                lista.Add(obj);
            }

            return lista;
            
        }

        [WebMethod]

        public List<EHorario> listarHorarioDisponible(string fecha,int idcampo) {

            return NReserva.Instancia.SelectHorariosDisponiblesParaReserva(Convert.ToDateTime(fecha),idcampo);
        
        }

        [WebMethod]

        public List<EReserva> listarReservas(int idUsuario) {
            List<Reserva> listilla = NReserva.Instancia.SelectReservaByIdUsuario(idUsuario);
            List<EReserva> listaReserva = new List<EReserva>();
            foreach(var item in listilla){
                EReserva obj = new EReserva();
                obj.id = item.id;
                obj.centrodeportivo = item.Campo.CentroDeportivo.nombre;
                obj.campo = item.Campo.nombre;
                obj.fecha = item.fecha.ToString();
                obj.horaInicio = item.horaInicio.ToString();
                obj.horaFin = item.horaFin.ToString();


                listaReserva.Add(obj);
            }

            return listaReserva;
        }

        [WebMethod]
        public List<EDeportista> listarAmigos(int idDeportista) {

            List<Deportista> listilla = NDeportista.Instancia.listarAmigos(idDeportista);

            List<EDeportista> lista = new List<EDeportista>();

            foreach(var item in listilla){
                EDeportista obj = new EDeportista();
                obj.id = item.id;
                obj.nombre = item.nombre;
                obj.apellidos = item.apellidos;
                obj.celular = item.celular;

                lista.Add(obj);
            }

            return lista;
        }

        [WebMethod]

        public List<EDeportista> listarDeportistas(int idDeportista) {

            List<Deportista> listilla = NDeportista.Instancia.listarDeportistas(idDeportista);

            List<EDeportista> lista = new List<EDeportista>();

            foreach (var item in listilla)
            {
                EDeportista obj = new EDeportista();
                obj.id = item.id;
                obj.nombre = item.nombre;
                obj.apellidos = item.apellidos;
                obj.celular = item.celular;

                lista.Add(obj);
            }

            return lista;
        }

        [WebMethod]
        public bool solicitudAmistad(int idPelotero, int[] idreceptores)
        {
            bool flag = false;

            foreach(var item in idreceptores){
                SolicitudAmistad objSolicitud = new SolicitudAmistad();
                objSolicitud.fechaHora = System.DateTime.Now;
                objSolicitud.activo = true;
                objSolicitud.estado = "pendiente";
                objSolicitud.idPelotero = idPelotero;
                objSolicitud.idReceptor = item;

                if (NSolicitudAmistad.Instancia.registrarSolicitud(objSolicitud))
                {
                    flag = true;
                }
            }

            if (flag)
                return true;
            else
                return false;

            
        }

        [WebMethod]

        public bool crearDetalleInvitado(int idReserva, int[] idpeloteros) {

            bool flag = false;

            foreach(var item in idpeloteros){
                DetalleInvitados obj=new DetalleInvitados();
                obj.idReserva = idReserva;
                obj.idDeportista = item;

                if (NDetalleInvitados.Instancia.Create(obj)) {
                    flag = true;
                }

            }

            if (flag)
                return true;
            else
                return false;
        }

       /*

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
                obj.Pelotero = new EDeportista();
                obj.Pelotero.nombre = item.Deportista.nombre;
                obj.Pelotero.apellidos = item.Deportista.apellidos;
                obj.Pelotero.email = item.Deportista.email;
                obj.Pelotero.celular = item.Deportista.celular;
                elista.Add(obj);
                
            }
            return elista;
        }

        [WebMethod]
        public bool responderSolicitudAmistad(int idSolicitudAmistad)
        {
            
            return NDeportista.Instancia.responderSolicitudAmistad(idSolicitudAmistad);
        }

    }
}