//------------------------------------------------------------------------------
// Author: Dev Peru 
// Generado el Dia: 2015_noviembre_09 - 19_41_03 
//-------------------------  ENTIDAD Empresa  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using Entidad;
namespace AccesoDatos
{
    public class DEmpresa
    {
        private static DEmpresa _instancia;
        public static DEmpresa Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new DEmpresa();
                return _instancia;
            }
        }
        protected DEmpresa() { }
        private CanchaDBEntities1 db = new CanchaDBEntities1();
        #region creacion del CRUD
        public bool Create(Empresa obj)
        {
            try
            {
                db.Empresa.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(Empresa objEmpresa)
        {
            Empresa obj = db.Empresa.Find(objEmpresa.id);
            obj.id = objEmpresa.id;
            obj.nombre = objEmpresa.nombre;
            obj.idUsuario = objEmpresa.idUsuario;
            obj.direccion = objEmpresa.direccion;
            obj.activo = objEmpresa.activo;
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
        public Empresa Details(int id)
        {
            try
            {
                Empresa obj = db.Empresa.Find(id);
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
                query = "delete Empresa where id=" + id;
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
                var obj = db.Empresa.Find(id);
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
        public List<Empresa> SelectAll()
        {
            List<Empresa> lista = db.Empresa.AsNoTracking().Where(a=>a.id!=4).ToList();
            return lista;
        }
        public List<Empresa> SelectAllActivo()
        {
            List<Empresa> lista = db.Empresa.AsNoTracking().Where(a => a.activo == true && a.id != 3).ToList();
            return lista;
        }
        #endregion

        public bool DeleteConfirmed(int id, int idu)
        {
            throw new NotImplementedException();
        }
    }
}
