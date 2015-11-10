//------------------------------------------------------------------------------
// Author: Dev Peru 
// Generado el Dia: 2015_octubre_11 - 18_52_51 
//-------------------------  ENTIDAD Provincia  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using Entidad;
namespace AccesoDatos
{
    public class DProvincia
    {
        private static DProvincia _instancia;
        public static DProvincia Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new DProvincia();
                return _instancia;
            }
        }
        protected DProvincia() { }
        private CanchaDBEntities1 db = new CanchaDBEntities1();
        #region creacion del CRUD
        public bool Create(Provincia obj)
        {
            try
            {
                db.Provincia.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(Provincia objProvincia)
        {
            Provincia obj = db.Provincia.Find(objProvincia.id);
            obj.id = objProvincia.id;
            obj.nombre = objProvincia.nombre;
            obj.activo = objProvincia.activo;
            obj.idDepartamento = objProvincia.idDepartamento;
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
        public Provincia Details(int id)
        {
            try
            {
                Provincia obj = db.Provincia.Find(id);
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
                query = "delete Provincia where id=" + id;
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
                var obj = db.Provincia.Find(id);
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
        public List<Provincia> SelectAll()
        {
            List<Provincia> lista = db.Provincia.ToList();
            return lista;
        }
        public List<Provincia> SelectAllActivo()
        {
            List<Provincia> lista = db.Provincia.Where(a => a.activo == true).ToList();
            return lista;
        }
        #endregion

        public List<Provincia> SelectAllByIdDepartamento(int idDepartamento)
        {
            List<Provincia> lista = db.Provincia.Where(a => a.idDepartamento == idDepartamento).ToList();
            return lista;
        }
    }
}
