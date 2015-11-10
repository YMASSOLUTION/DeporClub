//------------------------------------------------------------------------------
// Author: Dev Peru 
// Generado el Dia: 2015_noviembre_09 - 19_41_03 
//-------------------------  ENTIDAD CentroDeportivoCancha  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using Entidad;
namespace AccesoDatos
{
    public class DCentroDeportivoCancha
    {
        private static DCentroDeportivoCancha _instancia;
        public static DCentroDeportivoCancha Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new DCentroDeportivoCancha();
                return _instancia;
            }
        }
        protected DCentroDeportivoCancha() { }
        private CanchaDBEntities1 db = new CanchaDBEntities1();
        #region creacion del CRUD
        public bool Create(CentroDeportivoCancha obj)
        {
            try
            {
                db.CentroDeportivoCancha.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(CentroDeportivoCancha objCentroDeportivoCancha)
        {
            CentroDeportivoCancha obj = db.CentroDeportivoCancha.Find(objCentroDeportivoCancha.id);
            obj.id = objCentroDeportivoCancha.id;
            obj.idCentroDeportivo = objCentroDeportivoCancha.idCentroDeportivo;
            obj.idCancha = objCentroDeportivoCancha.idCancha;
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
        public CentroDeportivoCancha Details(int id)
        {
            try
            {
                CentroDeportivoCancha obj = db.CentroDeportivoCancha.Find(id);
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
                query = "delete CentroDeportivoCancha where id=" + id;
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
                var obj = db.CentroDeportivoCancha.Find(id);
                
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
        public List<CentroDeportivoCancha> SelectAll()
        {
            List<CentroDeportivoCancha> lista = db.CentroDeportivoCancha.ToList();
            return lista;
        }
        
        #endregion
    }
}
