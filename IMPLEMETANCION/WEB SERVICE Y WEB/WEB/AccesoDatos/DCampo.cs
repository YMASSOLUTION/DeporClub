//------------------------------------------------------------------------------
// Author: Dev Peru 
// Generado el Dia: 2015_noviembre_09 - 19_41_03 
//-------------------------  ENTIDAD Campo  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using Entidad;
namespace AccesoDatos
{
    public class DCampo
    {
        private static DCampo _instancia;
        public static DCampo Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new DCampo();
                return _instancia;
            }
        }
        protected DCampo() { }
        private CanchaDBEntities1 db = new CanchaDBEntities1();
        #region creacion del CRUD
        public bool Create(Campo obj)
        {
            try
            {
                db.Campo.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(Campo objCampo)
        {
            Campo obj = db.Campo.Find(objCampo.id);
            obj.id = objCampo.id;
            obj.largo = objCampo.largo;
            obj.ancho = objCampo.ancho;
            obj.precio = objCampo.precio;
            obj.activo = objCampo.activo;
            obj.tipoCampo = objCampo.tipoCampo;
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
        public Campo Details(int id)
        {
            try
            {
                Campo obj = db.Campo.Find(id);
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
                query = "delete Campo where id=" + id;
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
                var obj = db.Campo.Find(id);
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
        public List<Campo> SelectAll()
        {
            List<Campo> lista = db.Campo.ToList();
            return lista;
        }
        public List<Campo> SelectAllActivo()
        {
            List<Campo> lista = db.Campo.Where(a => a.activo == true).ToList();
            return lista;
        }
        #endregion

        public List<Campo> SelectAllByEmpresa(int idEmpresa)
        {
            throw new NotImplementedException();
        }

        public List<Campo> SelectAllByEmpresaForReserva(int idEmpresa)
        {
            throw new NotImplementedException();
        }

        public List<Campo> SelectAllByEmpresaForEditReserva(int idEmpresa)
        {
            throw new NotImplementedException();
        }
        public List<CentroDeportivoCampo> SelectAllbyCentroDeportivo(int idCentroDeportivo)
        {
            List<CentroDeportivoCampo> lista = db.CentroDeportivoCampo.Where(a => a.idCentroDeportivo == idCentroDeportivo).ToList();
            return lista;
        }
    }
}
