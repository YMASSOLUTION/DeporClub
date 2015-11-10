//------------------------------------------------------------------------------
// Author: Dev Peru
// Generado el Dia: 2015_octubre_11 - 19_15_39 
//-------------------------  Negocio NCancha  ----------------------------------------
using Entidad;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Negocio
{
    public class NCancha
    {
        private static NCancha _instancia;
        public static NCancha Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new NCancha();
                return _instancia;
            }
        }
        protected NCancha() { }
        public bool Create(Cancha obj)
        {
            try
            {
                return DCancha.Instancia.Create(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(Cancha obj)
        {
            try
            {
                return DCancha.Instancia.Edit(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Cancha Details(int id)
        {
            try
            {
                return DCancha.Instancia.Details(id);
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
                return DCancha.Instancia.DeleteConfirmed(id);
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
                return DCancha.Instancia.Disable(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Cancha> SelectAll()
        {
            return DCancha.Instancia.SelectAll();
        }
        public List<Cancha> SelectAllActivo()
        {
            return DCancha.Instancia.SelectAllActivo();
        }

        public List<Cancha> SelectAllByEmpresa(int idEmpresa)
        {
            return DCancha.Instancia.SelectAllByEmpresa(idEmpresa);
        }

        public List<Cancha> SelectAllByEmpresaForReserva(int idEmpresa)
        {
            return DCancha.Instancia.SelectAllByEmpresaForReserva(idEmpresa);
        }

        public List<Cancha> SelectAllByEmpresaForEditReserva(int idEmpresa) {
            return DCancha.Instancia.SelectAllByEmpresaForEditReserva(idEmpresa);
        }
    }
}
