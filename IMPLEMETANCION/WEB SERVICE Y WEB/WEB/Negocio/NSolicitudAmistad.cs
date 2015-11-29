//------------------------------------------------------------------------------
// Author: Dev Peru
// Generado el Dia: 2015_octubre_11 - 19_15_39 
//-------------------------  Negocio NSolicitudAmistad  ----------------------------------------
using Entidad;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Negocio
{
    public class NSolicitudAmistad
    {
        private static NSolicitudAmistad _instancia;
        public static NSolicitudAmistad Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new NSolicitudAmistad();
                return _instancia;
            }
        }
        protected NSolicitudAmistad() { }
        public bool Create(SolicitudAmistad obj)
        {
            try
            {
                return DSolicitudAmistad.Instancia.Create(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(SolicitudAmistad obj)
        {
            try
            {
                return DSolicitudAmistad.Instancia.Edit(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public SolicitudAmistad Details(int id)
        {
            try
            {
                return DSolicitudAmistad.Instancia.Details(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool DeleteConfirmed(int id)
        {
            try
            {
                return DSolicitudAmistad.Instancia.DeleteConfirmed(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Disable(int id)
        {
            try
            {
                return DSolicitudAmistad.Instancia.Disable(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<SolicitudAmistad> SelectAll()
        {
            return DSolicitudAmistad.Instancia.SelectAll();
        }
        public List<SolicitudAmistad> SelectAllActivo()
        {
            return DSolicitudAmistad.Instancia.SelectAllActivo();
        }

        public List<SolicitudAmistad> SelectAll(int idPelotero)
        {
            return DSolicitudAmistad.Instancia.SelectAll(idPelotero);
        }

        public bool registrarSolicitud(SolicitudAmistad obj) {

            return DSolicitudAmistad.Instancia.registrarSolicitud(obj);
        }
    }
}
