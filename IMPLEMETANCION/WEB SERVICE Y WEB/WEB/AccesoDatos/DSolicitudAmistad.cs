//------------------------------------------------------------------------------
// Author: Dev Peru 
// Generado el Dia: 2015_octubre_11 - 18_52_51 
//-------------------------  ENTIDAD SolicitudAmistad  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using Entidad;
namespace AccesoDatos
{
    public class DSolicitudAmistad
    {
        private static DSolicitudAmistad _instancia;
        public static DSolicitudAmistad Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new DSolicitudAmistad();
                return _instancia;
            }
        }
        protected DSolicitudAmistad() { }
        private CanchaDBEntities1 db = new CanchaDBEntities1();
        #region creacion del CRUD
        public bool Create(SolicitudAmistad obj)
        {
            try
            {
                db.SolicitudAmistad.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(SolicitudAmistad objSolicitudAmistad)
        {
            SolicitudAmistad obj = db.SolicitudAmistad.Find(objSolicitudAmistad.id);
            obj.id = objSolicitudAmistad.id;
            obj.fechaHora = objSolicitudAmistad.fechaHora;
            obj.activo = objSolicitudAmistad.activo;
            obj.idPelotero = objSolicitudAmistad.idPelotero;
            obj.idReceptor = objSolicitudAmistad.idReceptor;
            obj.estado = objSolicitudAmistad.estado;
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
        public SolicitudAmistad Details(int id)
        {
            try
            {
                SolicitudAmistad obj = db.SolicitudAmistad.Find(id);
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
                query = "delete SolicitudAmistad where id=" + id;
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
                var obj = db.SolicitudAmistad.Find(id);
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
        public List<SolicitudAmistad> SelectAll()
        {
            List<SolicitudAmistad> lista = db.SolicitudAmistad.ToList();
            return lista;
        }
        public List<SolicitudAmistad> SelectAllActivo()
        {
            List<SolicitudAmistad> lista = db.SolicitudAmistad.Where(a => a.activo == true).ToList();
            return lista;
        }
        #endregion

        public List<SolicitudAmistad> SelectAll(int idPelotero)
        {
            return db.SolicitudAmistad.Where(a => a.idReceptor == idPelotero && a.estado == "pendiente").ToList();
        }
    }
}
