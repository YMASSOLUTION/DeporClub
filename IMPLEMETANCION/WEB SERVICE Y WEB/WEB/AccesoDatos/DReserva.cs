//------------------------------------------------------------------------------
// Author: Dev Peru 
// Generado el Dia: 2015_noviembre_09 - 19_41_03 
//-------------------------  ENTIDAD Reserva  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using Entidad;
namespace AccesoDatos
{
    public class DReserva
    {
        private static DReserva _instancia;
        public static DReserva Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new DReserva();
                return _instancia;
            }
        }
        protected DReserva() { }
        private CanchaDBEntities1 db = new CanchaDBEntities1();
        #region creacion del CRUD
        public bool Create(Reserva obj)
        {
            try
            {
                db.Reserva.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(Reserva objReserva)
        {
            Reserva obj = db.Reserva.Find(objReserva.id);
            obj.id = objReserva.id;
            obj.fechaHora = objReserva.fechaHora;
            obj.idUsuario = objReserva.idUsuario;
            obj.idCancha = objReserva.idCancha;
            obj.activo = objReserva.activo;
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
        public Reserva Details(int id)
        {
            try
            {
                Reserva obj = db.Reserva.Find(id);
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
                query = "delete Reserva where id=" + id;
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
                var obj = db.Reserva.Find(id);
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
        public List<Reserva> SelectAll()
        {
            List<Reserva> lista = db.Reserva.AsNoTracking().ToList();
            return lista;
        }
        public List<Reserva> SelectAllActivo()
        {
            List<Reserva> lista = db.Reserva.AsNoTracking().Where(a => a.activo == true).ToList();
            return lista;
        }
        #endregion

        public List<Reserva> SelectReservaByCanchaAndFecha(DateTime fecha, int idcancha)
        {
            return db.Reserva.AsNoTracking().Where(a => a.fecha == fecha && a.idCancha==idcancha && a.activo==true).ToList();
        }

        public List<Reserva> SelectReservaByIdUsuario(int idusuario)
        {
            return db.Reserva.AsNoTracking().Where(a => a.idUsuario==idusuario && a.activo == true).ToList();
        }
    }
}
