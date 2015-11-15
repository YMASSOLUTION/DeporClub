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
                obj.fechaHora = DateTime.Now;
                //List<Reserva> listilla = DReserva.Instancia.SelectReservaByCanchaAndFecha(obj.fechaHora, obj.idCancha);
                //foreach (var item in listilla)
                //{
                //    if (item.horaInicio == obj.horaInicio)
                //    {
                //        aptoParaReserva = false;
                //        break;
                //    }
                //    if (item.horaFin == obj.horaFin)
                //    {
                //        aptoParaReserva = false;
                //        break;
                //    }
                //}

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

        //Algoritmo del marido que no deberia estar en esta clase 
        public List<EHorario> SelectHorariosDisponiblesParaReserva(DateTime fecha,int idcampo) {

            List<int> horaInicio = new List<int>() {7,8,9,10,11,12,13,14,15,16,17,18,19,20,21};
            List<int> horaFin = new List<int>() { 8,9,10,11,12,13,14,15,16,17,18,19,20,21,22};


            List<Reserva> listilla = DReserva.Instancia.SelectReservaByCanchaAndFecha(fecha, idcampo);

            int cantHoras=0;

            foreach (var item in listilla)
            {
                
                int horFin=item.horaFin.Value.Hours;
                int horInicio=item.horaInicio.Value.Hours;
                cantHoras = horFin - horInicio;                
                for(int i=0;i<cantHoras;i++){
                    horaInicio.Remove(horInicio+i);
                    horaFin.Remove(horInicio + (i+1));
                }
            }

            List<EHorario> listHorario = new List<EHorario>();
            for (int i = 0; i < horaInicio.Count(); i++) {
                EHorario obj = new EHorario();
                obj.horainicio=horaInicio.ElementAt(i);
                obj.horafin = horaFin.ElementAt(i);

                listHorario.Add(obj);
            }

                return listHorario;
        }
    }
}
