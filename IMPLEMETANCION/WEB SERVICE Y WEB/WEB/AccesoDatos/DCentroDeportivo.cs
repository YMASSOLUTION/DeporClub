//------------------------------------------------------------------------------
// Author: Dev Peru 
// Generado el Dia: 2015_noviembre_09 - 19_41_03 
//-------------------------  ENTIDAD CentroDeportivo  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using Entidad;
namespace AccesoDatos
{
    public class DCentroDeportivo
    {
        private static DCentroDeportivo _instancia;
        public static DCentroDeportivo Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new DCentroDeportivo();
                return _instancia;
            }
        }
        protected DCentroDeportivo() { }
        private CanchaDBEntities1 db = new CanchaDBEntities1();
        #region creacion del CRUD
        public bool Create(CentroDeportivo obj)
        {
            try
            {
                db.CentroDeportivo.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(CentroDeportivo objCentroDeportivo)
        {
            CentroDeportivo obj = db.CentroDeportivo.Find(objCentroDeportivo.id);
            obj.id = objCentroDeportivo.id;
            obj.direccion = objCentroDeportivo.direccion;
            obj.telefono = objCentroDeportivo.telefono;
            obj.celular = objCentroDeportivo.celular;
            obj.idDistrito = objCentroDeportivo.idDistrito;
            obj.nroCanchas = objCentroDeportivo.nroCanchas;
            obj.balon = objCentroDeportivo.balon;
            obj.camisetas = objCentroDeportivo.camisetas;
            obj.idEmpresa = objCentroDeportivo.idEmpresa;
            obj.nombre = objCentroDeportivo.nombre;
            obj.foto = objCentroDeportivo.foto;
            obj.latitud = objCentroDeportivo.latitud;
            obj.longitud = objCentroDeportivo.longitud;
            obj.activo = objCentroDeportivo.activo;
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
        public CentroDeportivo Details(int id)
        {
            try
            {
                CentroDeportivo obj = db.CentroDeportivo.Find(id);
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
                query = "delete CentroDeportivo where id=" + id;
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
                var obj = db.CentroDeportivo.Find(id);
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
        public List<CentroDeportivo> SelectAll()
        {
            List<CentroDeportivo> lista = db.CentroDeportivo.ToList();
            return lista;
        }
        public List<CentroDeportivo> SelectAllActivo()
        {
            List<CentroDeportivo> lista = db.CentroDeportivo.Where(a => a.activo == true).ToList();
            return lista;
        }

        public List<CentroDeportivo> SelectAllbyEmpresa(int idEmpresa)
        {
            List<CentroDeportivo> lista = db.CentroDeportivo.Where(a => a.activo == true && a.idEmpresa==idEmpresa).ToList();
            return lista;
        }
        #endregion
    }
}
