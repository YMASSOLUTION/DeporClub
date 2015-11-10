//------------------------------------------------------------------------------
// Author: Dev Peru
// Generado el Dia: 2015_octubre_11 - 19_15_39 
//-------------------------  Negocio NEmpresa  ----------------------------------------
using Entidad;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Negocio
{
    public class NEmpresa
    {
        private static NEmpresa _instancia;
        public static NEmpresa Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new NEmpresa();
                return _instancia;
            }
        }
        protected NEmpresa() { }
        public bool Create(Empresa obj)
        {
            try
            {
                return DEmpresa.Instancia.Create(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(Empresa obj)
        {
            try
            {
                return DEmpresa.Instancia.Edit(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Empresa Details(int id)
        {
            try
            {
                return DEmpresa.Instancia.Details(id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool DeleteConfirmed(int id,int idu)
        {
            try
            {
                return DEmpresa.Instancia.DeleteConfirmed(id,idu);
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
                return DEmpresa.Instancia.Disable(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Empresa> SelectAll()
        {
            return DEmpresa.Instancia.SelectAll();
        }
        public List<Empresa> SelectAllActivo()
        {
            return DEmpresa.Instancia.SelectAllActivo();
        }
    }
}
