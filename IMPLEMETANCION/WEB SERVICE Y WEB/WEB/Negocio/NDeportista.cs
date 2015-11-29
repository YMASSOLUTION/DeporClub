//------------------------------------------------------------------------------
// Author: Dev Peru
// Generado el Dia: 2015_octubre_11 - 19_15_39 
//-------------------------  Negocio NDeportista  ----------------------------------------
using Entidad;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Negocio
{
    public class NDeportista
    {
        private static NDeportista _instancia;
        public static NDeportista Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new NDeportista();
                return _instancia;
            }
        }
        protected NDeportista() { }
        public bool Create(Deportista obj)
        {
            try
            {
                return DDeportista.Instancia.Create(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(Deportista obj)
        {
            try
            {
                return DDeportista.Instancia.Edit(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Deportista Details(int id)
        {
            try
            {
                return DDeportista.Instancia.Details(id);
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
                return DDeportista.Instancia.DeleteConfirmed(id);
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
                return DDeportista.Instancia.Disable(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Deportista> SelectAll()
        {
            return DDeportista.Instancia.SelectAll();
        }
        public List<Deportista> SelectAllActivo()
        {
            return DDeportista.Instancia.SelectAllActivo();
        }

        public List<Deportista> SelectAll(string nombre, int idDeportista)
        {
            return DDeportista.Instancia.SelectAll(nombre, idDeportista);
        }

        public bool solicitudAmistad(int idDeportista, int idReceptor)
        {
            return DDeportista.Instancia.solicitudAmistad(idDeportista,idReceptor);
        }

        public bool responderSolicitudAmistad(int idSolicitudAmistad)
        {
            return DDeportista.Instancia.responderSolicitudAmistad(idSolicitudAmistad);
        }

        public List<Deportista> listarAmigos(int idDeportista) {
            return DDeportista.Instancia.listarAmigos(idDeportista);
        }

        public List<Deportista> listarDeportistas(int idDeportista) {
            return DDeportista.Instancia.listarDeportistas(idDeportista);
        }
    }
}
