//------------------------------------------------------------------------------
// Author: Dev Peru 
// Generado el Dia: 2015_noviembre_09 - 19_41_03 
//-------------------------  ENTIDAD Cancha  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using Entidad;
namespace AccesoDatos
{
    public class DCancha
    {
        private static DCancha _instancia;
        public static DCancha Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new DCancha();
                return _instancia;
            }
        }
        protected DCancha() { }
        private CanchaDBEntities1 db = new CanchaDBEntities1();
        #region creacion del CRUD
        public bool Create(Cancha obj)
        {
            try
            {
                db.Cancha.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(Cancha objCancha)
        {
            Cancha obj = db.Cancha.Find(objCancha.id);
            obj.id = objCancha.id;
            obj.largo = objCancha.largo;
            obj.ancho = objCancha.ancho;
            obj.precio = objCancha.precio;
            obj.activo = objCancha.activo;
            obj.tipoCampo = objCancha.tipoCampo;
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
        public Cancha Details(int id)
        {
            try
            {
                Cancha obj = db.Cancha.Find(id);
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
                query = "delete Cancha where id=" + id;
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
                var obj = db.Cancha.Find(id);
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
        public List<Cancha> SelectAll()
        {
            List<Cancha> lista = db.Cancha.ToList();
            return lista;
        }
        public List<Cancha> SelectAllActivo()
        {
            List<Cancha> lista = db.Cancha.Where(a => a.activo == true).ToList();
            return lista;
        }
        #endregion

        public List<Cancha> SelectAllByEmpresa(int idEmpresa)
        {
            throw new NotImplementedException();
        }

        public List<Cancha> SelectAllByEmpresaForReserva(int idEmpresa)
        {
            throw new NotImplementedException();
        }

        public List<Cancha> SelectAllByEmpresaForEditReserva(int idEmpresa)
        {
            throw new NotImplementedException();
        }
    }
}
