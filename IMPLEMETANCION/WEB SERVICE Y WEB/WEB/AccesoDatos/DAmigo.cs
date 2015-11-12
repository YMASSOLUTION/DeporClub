//------------------------------------------------------------------------------
// Author: Dev Peru 
// Generado el Dia: 2015_octubre_11 - 18_52_51 
//-------------------------  ENTIDAD Amigo  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using Entidad;
namespace AccesoDatos
{
    public class DAmigo
    {
        private static DAmigo _instancia;
        public static DAmigo Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new DAmigo();
                return _instancia;
            }
        }
        protected DAmigo() { }
        private CanchaDBEntities1 db = new CanchaDBEntities1();
        #region creacion del CRUD
        public bool Create(Amigo obj)
        {
            try
            {
                db.Amigo.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(Amigo objAmigo)
        {
            Amigo obj = db.Amigo.Find(objAmigo.id);
            obj.id = objAmigo.id;
            obj.idDeportista = objAmigo.idDeportista;
            obj.idAmigo = objAmigo.idAmigo;
            try
            {
                db.SaveChanges();
                return true;
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
                Amigo obj = db.Amigo.Find(id);
                if (obj == null)
                {
                    return null;
                }
                return obj;
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
                string query = string.Empty;
                query = "delete Amigo where id=" + id;
                db.Database.ExecuteSqlCommand(query);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Amigo> SelectAll()
        {
            List<Amigo> lista = db.Amigo.ToList();
            return lista;
        }

        #endregion
    }
}
