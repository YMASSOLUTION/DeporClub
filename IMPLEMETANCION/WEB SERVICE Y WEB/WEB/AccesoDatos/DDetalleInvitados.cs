//------------------------------------------------------------------------------
// Author: Dev Peru 
// Generado el Dia: 2015_octubre_11 - 18_52_51 
//-------------------------  ENTIDAD DetalleInvitados  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using Entidad;
namespace AccesoDatos
{
    public class DDetalleInvitados
    {
        private static DDetalleInvitados _instancia;
        public static DDetalleInvitados Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new DDetalleInvitados();
                return _instancia;
            }
        }
        protected DDetalleInvitados() { }
        private CanchaDBEntities1 db = new CanchaDBEntities1();
        #region creacion del CRUD
        public bool Create(DetalleInvitados obj)
        {
            try
            {
                db.DetalleInvitados.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(DetalleInvitados objDetalleInvitados)
        {
            DetalleInvitados obj = db.DetalleInvitados.Find(objDetalleInvitados.id);
            obj.id = objDetalleInvitados.id;
            obj.idDeportista = objDetalleInvitados.idDeportista;
            obj.idReserva = objDetalleInvitados.idReserva;
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
        public DetalleInvitados Details(int id)
        {
            try
            {
                DetalleInvitados obj = db.DetalleInvitados.Find(id);
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
                query = "delete DetalleInvitados where id=" + id;
                db.Database.ExecuteSqlCommand(query);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<DetalleInvitados> SelectAll()
        {
            List<DetalleInvitados> lista = db.DetalleInvitados.ToList();
            return lista;
        }

        #endregion
    }
}
