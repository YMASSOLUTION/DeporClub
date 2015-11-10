//------------------------------------------------------------------------------
// Author: Dev Peru 
// Generado el Dia: 2015_octubre_11 - 18_52_51 
//-------------------------  ENTIDAD Pelotero  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using Entidad;
namespace AccesoDatos
{
    public class DPelotero
    {
        private static DPelotero _instancia;
        public static DPelotero Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new DPelotero();
                return _instancia;
            }
        }
        protected DPelotero() { }
        private CanchaDBEntities1 db = new CanchaDBEntities1();
        #region creacion del CRUD
        public bool Create(Pelotero obj)
        {
            try
            {
                db.Pelotero.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(Pelotero objPelotero)
        {
            Pelotero obj = db.Pelotero.Find(objPelotero.id);
            obj.id = objPelotero.id;
            obj.nombre = objPelotero.nombre;
            obj.apellidos = objPelotero.apellidos;
            obj.idUsuario = objPelotero.idUsuario;
            obj.celular = objPelotero.celular;
            obj.email = objPelotero.email;
            obj.activo = objPelotero.activo;
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
        public Pelotero Details(int id)
        {
            try
            {
                Pelotero obj = db.Pelotero.Find(id);
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
                query = "delete Pelotero where id=" + id;
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
                var obj = db.Pelotero.Find(id);
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
        public List<Pelotero> SelectAll()
        {
            List<Pelotero> lista = db.Pelotero.ToList();
            return lista;
        }
        public List<Pelotero> SelectAllActivo()
        {
            List<Pelotero> lista = db.Pelotero.Where(a => a.activo == true).ToList();
            return lista;
        }
        #endregion

        public List<Pelotero> SelectAll(string nombre, int idPelotero)
        {
            List<Pelotero> lista = db.Pelotero.Where(a => a.id != idPelotero && a.nombre.Contains(nombre)).ToList();
            return lista;
        }

        public bool solicitudAmistad(int idPelotero, int idReceptor)
        {
            try
            {
                SolicitudAmistad obj = new SolicitudAmistad();
                obj.activo = true;
                obj.estado = "pendiente";
                obj.fechaHora = System.DateTime.Now;
                obj.idPelotero = idPelotero;
                obj.idReceptor = idReceptor;


                db.SolicitudAmistad.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {                
                return false;
            }
        }


        public bool responderSolicitudAmistad(int idPelotero, int idSolicitante, string respuesta)
        {
            
            try
            {
                Amigo obj = new Amigo();
                obj.idPelotero = idPelotero;
                obj.idAmigo = idSolicitante;
                db.Amigo.Add(obj);

                string query = string.Empty;
                query = "update SolicitudAmistad set estado='"+respuesta+"' where idPelotero="+ idPelotero +
                    " and idReceptor="+idSolicitante;
                db.Database.ExecuteSqlCommand(query);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }
    }
}
