//------------------------------------------------------------------------------
// Author: Dev Peru
// Generado el Dia: 2015_octubre_11 - 19_15_39 
//-------------------------  Negocio NAmigo  ----------------------------------------
using Entidad;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Negocio
{
    public class NAmigo
    {
        private static NAmigo _instancia;
        public static NAmigo Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new NAmigo();
                return _instancia;
            }
        }
        protected NAmigo() { }
        public bool Create(Amigo obj)
        {
            try
            {
                return DAmigo.Instancia.Create(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(Amigo obj)
        {
            try
            {
                return DAmigo.Instancia.Edit(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Amigo Details(int id)
        {
            try
            {
                return DAmigo.Instancia.Details(id);
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
                return DAmigo.Instancia.DeleteConfirmed(id);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Amigo> SelectAll()
        {
            return DAmigo.Instancia.SelectAll();
        }
     
    }
}
