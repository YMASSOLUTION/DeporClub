//------------------------------------------------------------------------------
// Author: Dev Peru
// Generado el Dia: 2015_octubre_11 - 19_15_39 
//-------------------------  Negocio NProvincia  ----------------------------------------
using Entidad;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Negocio
{
    public class NProvincia
    {
        private static NProvincia _instancia;
        public static NProvincia Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new NProvincia();
                return _instancia;
            }
        }
        protected NProvincia() { }
        public bool Create(Provincia obj)
        {
            try
            {
                return DProvincia.Instancia.Create(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(Provincia obj)
        {
            try
            {
                return DProvincia.Instancia.Edit(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Provincia Details(int id)
        {
            try
            {
                return DProvincia.Instancia.Details(id);
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
                return DProvincia.Instancia.DeleteConfirmed(id);
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
                return DProvincia.Instancia.Disable(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Provincia> SelectAll()
        {
            return DProvincia.Instancia.SelectAll();
        }
        public List<Provincia> SelectAllActivo()
        {
            return DProvincia.Instancia.SelectAllActivo();
        }

        public List<Provincia> SelectAllByIdDepartamento(int idDepartamento)
        {
            return DProvincia.Instancia.SelectAllByIdDepartamento(idDepartamento);
        }
    }
}
