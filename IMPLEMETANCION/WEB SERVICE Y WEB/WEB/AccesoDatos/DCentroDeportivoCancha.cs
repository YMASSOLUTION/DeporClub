//------------------------------------------------------------------------------
// Author: Dev Peru 
// Generado el Dia: 2015_noviembre_09 - 19_41_03 
//-------------------------  ENTIDAD CentroDeportivoCampo  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using Entidad;
namespace AccesoDatos
{
    public class DCentroDeportivoCampo
    {
        private static DCentroDeportivoCampo _instancia;
        public static DCentroDeportivoCampo Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new DCentroDeportivoCampo();
                return _instancia;
            }
        }
        protected DCentroDeportivoCampo() { }
        private CanchaDBEntities1 db = new CanchaDBEntities1();
        #region creacion del CRUD
        public bool Create(CentroDeportivoCampo obj)
        {
            try
            {
                db.CentroDeportivoCampo.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(CentroDeportivoCampo objCentroDeportivoCampo)
        {
            CentroDeportivoCampo obj = db.CentroDeportivoCampo.Find(objCentroDeportivoCampo.id);
            obj.id = objCentroDeportivoCampo.id;
            obj.idCentroDeportivo = objCentroDeportivoCampo.idCentroDeportivo;
            obj.idCancha = objCentroDeportivoCampo.idCancha;
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
        public CentroDeportivoCampo Details(int id)
        {
            try
            {
                CentroDeportivoCampo obj = db.CentroDeportivoCampo.Find(id);
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
                query = "delete CentroDeportivoCampo where id=" + id;
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
                var obj = db.CentroDeportivoCampo.Find(id);
                
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
        public List<CentroDeportivoCampo> SelectAll()
        {
            List<CentroDeportivoCampo> lista = db.CentroDeportivoCampo.ToList();
            return lista;
        }
        
        #endregion

        public List<CentroDeportivoCampo> SelectAllByCentroDeportivo(int idCentroDeportivo) {

            return db.CentroDeportivoCampo.Where(a=>a.idCentroDeportivo==idCentroDeportivo).ToList();
        }
    }
}
