//------------------------------------------------------------------------------
// Author: Dev Peru 
// Generado el Dia: 2015_octubre_11 - 18_52_51 
//-------------------------  ENTIDAD Distrito  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using Entidad;
namespace AccesoDatos
{
    public class DDistrito
    {
        private static DDistrito _instancia;
        public static DDistrito Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new DDistrito();
                return _instancia;
            }
        }
        protected DDistrito() { }
        private CanchaDBEntities1 db = new CanchaDBEntities1();
        #region creacion del CRUD
        public bool Create(Distrito obj)
        {
            try
            {
                db.Distrito.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(Distrito objDistrito)
        {
            Distrito obj = db.Distrito.Find(objDistrito.id);
            obj.id = objDistrito.id;
            obj.nombre = objDistrito.nombre;
            obj.activo = objDistrito.activo;
            obj.idProvincia = objDistrito.idProvincia;
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
        public Distrito Details(int id)
        {
            try
            {
                Distrito obj = db.Distrito.Find(id);
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
                query = "delete Distrito where id=" + id;
                db.Database.ExecuteSqlCommand(query);
                db.SaveChanges();
                return true;
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
                var obj = db.Distrito.Find(id);
                obj.activo = false;
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Distrito> SelectAll()
        {
            List<Distrito> lista = db.Distrito.AsNoTracking().ToList();
            return lista;
        }
        public List<Distrito> SelectAllActivo()
        {
            List<Distrito> lista = db.Distrito.AsNoTracking().Where(a => a.activo == true).ToList();
            return lista;
        }
        #endregion

        public List<Distrito> SelectAllByIdProvincia(int idProvincia)
        {
            List<Distrito> lista = db.Distrito.AsNoTracking().Where(a => a.idProvincia == idProvincia).ToList();
            return lista;
        }
    }
}
