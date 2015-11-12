//------------------------------------------------------------------------------
// Author: Dev Peru
// Generado el Dia: 2015_octubre_11 - 19_15_39 
//-------------------------  Negocio NCampo  ----------------------------------------
using Entidad;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Negocio
{
    public class NCampo
    {
        private static NCampo _instancia;
        public static NCampo Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new NCampo();
                return _instancia;
            }
        }
        protected NCampo() { }
        public bool Create(Campo obj)
        {
            try
            {
                return DCampo.Instancia.Create(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(Campo obj)
        {
            try
            {
                return DCampo.Instancia.Edit(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Campo Details(int id)
        {
            try
            {
                return DCampo.Instancia.Details(id);
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
                return DCampo.Instancia.DeleteConfirmed(id);
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
                return DCampo.Instancia.Disable(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Campo> SelectAll()
        {
            return DCampo.Instancia.SelectAll();
        }
        public List<Campo> SelectAllActivo()
        {
            return DCampo.Instancia.SelectAllActivo();
        }

        public List<Campo> SelectAllByEmpresa(int idEmpresa)
        {
            return DCampo.Instancia.SelectAllByEmpresa(idEmpresa);
        }

        public List<Campo> SelectAllByEmpresaForReserva(int idEmpresa)
        {
            return DCampo.Instancia.SelectAllByEmpresaForReserva(idEmpresa);
        }

        public List<Campo> SelectAllByEmpresaForEditReserva(int idEmpresa) {
            return DCampo.Instancia.SelectAllByEmpresaForEditReserva(idEmpresa);
        }
        public List<CentroDeportivoCampo> SelectAllbyCentroDeportivo(int idCentroDeportivo)
        {
            return DCampo.Instancia.SelectAllbyCentroDeportivo(idCentroDeportivo);
        }

    }
}
