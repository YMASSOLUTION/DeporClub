//------------------------------------------------------------------------------
// Author: Dev Peru
// Generado el Dia: 2015_octubre_11 - 19_15_39 
//-------------------------  Negocio NReserva  ----------------------------------------
using Entidad;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Negocio
{
    public class NReserva
    {
        private static NReserva _instancia;
        public static NReserva Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new NReserva();
                return _instancia;
            }
        }
        protected NReserva() { }
        public bool Create(Reserva obj)
        {
            try
            {
                bool aptoParaReserva=true;

                List<Reserva> listilla = DReserva.Instancia.SelectReservaByCanchaAndFecha(obj.fechaHora,obj.idCancha);
                foreach(var item in listilla){
                    if (item.horaInicio == obj.horaInicio)
                    {
                        aptoParaReserva = false;
                        break;
                    }
                    if (item.horaFin == obj.horaFin) {
                        aptoParaReserva = false;
                        break;
                    }
                }

                if (aptoParaReserva)
                {
                    return DReserva.Instancia.Create(obj);
                }
                else {
                    return false;
                }

                
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(Reserva obj)
        {
            try
            {
                bool aptoParaReserva = true;

                List<Reserva> listilla = DReserva.Instancia.SelectReservaByCanchaAndFecha(obj.fechaHora, obj.idCancha);
                foreach (var item in listilla)
                {
                    if (item.horaInicio == obj.horaInicio)
                    {
                        aptoParaReserva = false;
                        break;
                    }
                    if (item.horaFin == obj.horaFin)
                    {
                        aptoParaReserva = false;
                        break;
                    }
                }

                if (aptoParaReserva)
                {
                    return DReserva.Instancia.Edit(obj);
                }
                else
                {
                    return false;
                }
                
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
                return DReserva.Instancia.Details(id);
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
                return DReserva.Instancia.DeleteConfirmed(id);
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
                return DReserva.Instancia.Disable(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Reserva> SelectAll()
        {
            return DReserva.Instancia.SelectAll();
        }
        public List<Reserva> SelectAllActivo()
        {
            return DReserva.Instancia.SelectAllActivo();
        }
    }
}
