//------------------------------------------------------------------------------
// Author: Dev Peru 
// Generado el Dia: 2015_noviembre_11 - 13_48_39 
//-------------------------  ENTIDAD Deportista  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using Entidad;
namespace AccesoDatos
{
    public class DDeportista
    {
        private static DDeportista _instancia;
        public static DDeportista Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new DDeportista();
                return _instancia;
            }
        }
        protected DDeportista() { }
        private CanchaDBEntities1 db = new CanchaDBEntities1();
        #region creacion del CRUD
        public bool Create(Deportista obj)
        {
            try
            {
                db.Deportista.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(Deportista objDeportista)
        {
            Deportista obj = db.Deportista.Find(objDeportista.id);
            obj.id = objDeportista.id;
            obj.nombre = objDeportista.nombre;
            obj.apellidos = objDeportista.apellidos;
            obj.idUsuario = objDeportista.idUsuario;
            obj.celular = objDeportista.celular;
            obj.email = objDeportista.email;
            obj.activo = objDeportista.activo;
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
        public Deportista Details(int id)
        {
            try
            {
                Deportista obj = db.Deportista.Find(id);
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
                query = "delete Deportista where id=" + id;
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
                var obj = db.Deportista.Find(id);
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
        public List<Deportista> SelectAll()
        {
            List<Deportista> lista = db.Deportista.ToList();
            return lista;
        }
        public List<Deportista> SelectAllActivo()
        {
            List<Deportista> lista = db.Deportista.Where(a => a.activo == true).ToList();
            return lista;
        }
        #endregion

        public List<Deportista> SelectAll(string nombre, int idDeportista)
        {
            throw new NotImplementedException();
        }

        public bool solicitudAmistad(int idDeportista, int idReceptor)
        {
            throw new NotImplementedException();
        }

        public bool responderSolicitudAmistad(int idDeportista, int idSolicitante, string respuesta)
        {
            throw new NotImplementedException();
        }
    }
}
