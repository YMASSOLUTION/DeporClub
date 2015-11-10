//------------------------------------------------------------------------------
// Author: Dev Peru
// Generado el Dia: 2015_octubre_11 - 19_15_39 
//-------------------------  Negocio NPelotero  ----------------------------------------
using Entidad;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Negocio
{
    public class NPelotero
    {
        private static NPelotero _instancia;
        public static NPelotero Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new NPelotero();
                return _instancia;
            }
        }
        protected NPelotero() { }
        public bool Create(Pelotero obj)
        {
            try
            {
                return DPelotero.Instancia.Create(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(Pelotero obj)
        {
            try
            {
                return DPelotero.Instancia.Edit(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Pelotero Details(int id)
        {
            try
            {
                return DPelotero.Instancia.Details(id);
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
                return DPelotero.Instancia.DeleteConfirmed(id);
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
                return DPelotero.Instancia.Disable(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Pelotero> SelectAll()
        {
            return DPelotero.Instancia.SelectAll();
        }
        public List<Pelotero> SelectAllActivo()
        {
            return DPelotero.Instancia.SelectAllActivo();
        }

        public List<Pelotero> SelectAll(string nombre, int idPelotero)
        {
            return DPelotero.Instancia.SelectAll(nombre, idPelotero);
        }

        public bool solicitudAmistad(int idPelotero, int idReceptor)
        {
            return DPelotero.Instancia.solicitudAmistad(idPelotero,idReceptor);
        }

        public bool responderSolicitudAmistad(int idPelotero, int idSolicitante, string respuesta)
        {
            return DPelotero.Instancia.responderSolicitudAmistad(idPelotero, idSolicitante,respuesta);
        }
    }
}
