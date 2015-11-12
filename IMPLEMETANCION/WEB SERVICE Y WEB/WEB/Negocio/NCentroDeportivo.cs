using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using AccesoDatos;
namespace Negocio
{
    public class NCentroDeportivo
    {
        private static NCentroDeportivo _instancia;
        
        public static NCentroDeportivo Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new NCentroDeportivo();
                return _instancia;
            }
        }
        protected NCentroDeportivo() { }
        public bool Create(CentroDeportivo obj)
        {
            try
            {
                return DCentroDeportivo.Instancia.Create(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(CentroDeportivo obj)
        {
            try
            {
                return DCentroDeportivo.Instancia.Edit(obj);
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
                return DCentroDeportivo.Instancia.Details(id);
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
                return DCentroDeportivo.Instancia.DeleteConfirmed(id);
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
                return DCentroDeportivo.Instancia.Disable(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<CentroDeportivo> SelectAll()
        {
            return DCentroDeportivo.Instancia.SelectAll();
        }
        public List<CentroDeportivo> SelectAllActivo()
        {
            return DCentroDeportivo.Instancia.SelectAllActivo();
        }
        public List<CentroDeportivo> SelectAllbyEmpresa(int idEmpresa)
        {
            return DCentroDeportivo.Instancia.SelectAllbyEmpresa(idEmpresa);
        }

        public List<CentroDeportivoCampo> SelectAllByCentroDeportivo(int idCentroDeportivo) {

            return DCentroDeportivoCampo.Instancia.SelectAllByCentroDeportivo(idCentroDeportivo);
        }

    }
}