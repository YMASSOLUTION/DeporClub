//------------------------------------------------------------------------------
// Author: Dev Peru
// Generado el Dia: 2015_octubre_11 - 19_15_39 
//-------------------------  Negocio NDetalleInvitados  ----------------------------------------
using Entidad;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Negocio
{
    public class NDetalleInvitados
    {
        private static NDetalleInvitados _instancia;
        public static NDetalleInvitados Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new NDetalleInvitados();
                return _instancia;
            }
        }
        protected NDetalleInvitados() { }
        public bool Create(DetalleInvitados obj)
        {
            try
            {
                return DDetalleInvitados.Instancia.Create(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(DetalleInvitados obj)
        {
            try
            {
                return DDetalleInvitados.Instancia.Edit(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public DetalleInvitados Details(int id)
        {
            try
            {
                return DDetalleInvitados.Instancia.Details(id);
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
                return DDetalleInvitados.Instancia.DeleteConfirmed(id);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<DetalleInvitados> SelectAll()
        {
            return DDetalleInvitados.Instancia.SelectAll();
        }

    }
}
