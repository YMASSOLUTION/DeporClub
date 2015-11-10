//------------------------------------------------------------------------------
// Author: Dev Peru 
// Generado el Dia: 2015_octubre_11 - 18_52_51 
//-------------------------  ENTIDAD Usuario  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using Entidad;
namespace AccesoDatos
{
    public class DUsuario
    {
        private static DUsuario _instancia;
        public static DUsuario Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new DUsuario();
                return _instancia;
            }
        }
        protected DUsuario() { }
        private CanchaDBEntities1 db = new CanchaDBEntities1();

        public Usuario Login(String nick)
        {
            try
            {
                Usuario obj = new Usuario();

                obj = db.Usuario.Where(a => a.nick == nick).FirstOrDefault();

                return obj;
            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}
