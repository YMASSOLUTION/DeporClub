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
            List<Deportista> lista = db.Deportista.AsNoTracking().ToList();
            return lista;
        }
        public List<Deportista> SelectAllActivo()
        {
            List<Deportista> lista = db.Deportista.AsNoTracking().Where(a => a.activo == true).ToList();
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

        public bool responderSolicitudAmistad(int idSolicitudAmistad)
        {
            SolicitudAmistad objSolicitud = db.SolicitudAmistad.Find(idSolicitudAmistad);
            objSolicitud.estado = "aceptado";

            Amigo objAmigo = new Amigo();
            objAmigo.idDeportista = objSolicitud.idPelotero;
            objAmigo.idAmigo = objSolicitud.idReceptor;
                        
            db.Amigo.Add(objAmigo);
           

            Amigo objAmigo2 = new Amigo();
            objAmigo2.idDeportista = objSolicitud.idReceptor;
            objAmigo2.idAmigo = objSolicitud.idPelotero;

            db.Amigo.Add(objAmigo2);

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

        public List<Deportista> listarAmigos(int idDeportista) { 
        
            List<Amigo> listilla=db.Amigo.AsNoTracking().Where(a=>a.idDeportista==idDeportista).ToList();
            
            List<Deportista> lista=new List<Deportista>();

            foreach(var item in listilla){
                Deportista obj=new Deportista();
                obj.id=item.Deportista1.id;
                obj.nombre=item.Deportista1.nombre;
                obj.apellidos=item.Deportista1.apellidos;
                obj.celular=item.Deportista1.celular;

                lista.Add(obj);
            }


            return lista;
        }

        public List<Deportista> listarDeportistas(int idDeportista)
        {

            List<Amigo> listilla = db.Amigo.AsNoTracking().Where(a => a.idDeportista == idDeportista).ToList();

            List<Deportista> listillaReborn = db.Deportista.AsNoTracking().Where(a=>a.id!=idDeportista).ToList();

            List<Deportista> lista = new List<Deportista>();

            foreach (var item in listillaReborn)
            {
                bool flag = true;
                foreach (var i in listilla){
                    if (item.id == i.idAmigo) {
                        flag = false;
                        break;
                    }
                }

                if(flag)
                    lista.Add(item);
             
            }


            return lista;
        }
    }
}
