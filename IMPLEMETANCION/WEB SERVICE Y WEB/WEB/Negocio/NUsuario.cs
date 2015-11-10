//------------------------------------------------------------------------------
// Author: Dev Peru
// Generado el Dia: 2015_octubre_11 - 19_15_39 
//-------------------------  Negocio NUsuario  ----------------------------------------
using Entidad;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Negocio
{
    public class NUsuario
    {
        private static NUsuario _instancia;
        public static NUsuario Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new NUsuario();
                return _instancia;
            }
        }
        protected NUsuario() { }


        public Usuario Login(string prusuario, string prpassword)
        {
            try
            {
                Usuario obj = new Usuario();
                obj = DUsuario.Instancia.Login(prusuario);
                if (obj != null)
                {
                    if (obj.clave.ToString() == prpassword)
                        return obj;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
