//------------------------------------------------------------------------------
// Author: Dev Peru 
// Generado el Dia: 2015_octubre_11 - 18_52_51 
//-------------------------  ENTIDAD Departamento  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using Entidad;
namespace AccesoDatos
{
    public class DDepartamento
    {
        private static DDepartamento _instancia;
        public static DDepartamento Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new DDepartamento();
                return _instancia;
            }
        }
        protected DDepartamento() { }
        private CanchaDBEntities1 db = new CanchaDBEntities1();
        #region creacion del CRUD
        public bool Create(Departamento obj)
        {
            try
            {
                db.Departamento.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(Departamento objDepartamento)
        {
            Departamento obj = db.Departamento.Find(objDepartamento.id);
            obj.id = objDepartamento.id;
            obj.nombre = objDepartamento.nombre;
            obj.activo = objDepartamento.activo;
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
        public Departamento Details(int id)
        {
            try
            {
                Departamento obj = db.Departamento.Find(id);
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
                query = "delete Departamento where id=" + id;
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
                var obj = db.Departamento.Find(id);
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
        public List<Departamento> SelectAll()
        {
            List<Departamento> lista = db.Departamento.ToList();
            return lista;
        }
        public List<Departamento> SelectAllActivo()
        {
            List<Departamento> lista = db.Departamento.Where(a => a.activo == true).ToList();
            return lista;
        }
        #endregion
    }
}
