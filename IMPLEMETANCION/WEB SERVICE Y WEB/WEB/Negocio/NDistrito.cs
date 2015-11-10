//------------------------------------------------------------------------------
// Author: Dev Peru
// Generado el Dia: 2015_octubre_11 - 19_15_39 
//-------------------------  Negocio NDistrito  ----------------------------------------
using Entidad;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Negocio
{
    public class NDistrito
    {
        private static NDistrito _instancia;
        public static NDistrito Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new NDistrito();
                return _instancia;
            }
        }
        protected NDistrito() { }
        public bool Create(Distrito obj)
        {
            try
            {
                return DDistrito.Instancia.Create(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(Distrito obj)
        {
            try
            {
                return DDistrito.Instancia.Edit(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Distrito Details(int id)
        {
            try
            {
                return DDistrito.Instancia.Details(id);
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
                return DDistrito.Instancia.DeleteConfirmed(id);
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
                return DDistrito.Instancia.Disable(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Distrito> SelectAll()
        {
            return DDistrito.Instancia.SelectAll();
        }
        public List<Distrito> SelectAllActivo()
        {
            return DDistrito.Instancia.SelectAllActivo();
        }

        public List<Distrito> SelectAllByIdProvincia(int idProvincia)
        {
            return DDistrito.Instancia.SelectAllByIdProvincia(idProvincia);
        }
    }
}
