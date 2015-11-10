//------------------------------------------------------------------------------
// Author: Dev Peru
// Generado el Dia: 2015_octubre_11 - 19_15_39 
//-------------------------  Negocio NMensaje  ----------------------------------------
using Entidad;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Negocio
{
public class NMensaje
{
private static NMensaje _instancia;
public static NMensaje Instancia
{
get
{
if (_instancia == null) _instancia = new  NMensaje();
return _instancia;
}
}
protected NMensaje() { }
public bool Create(Mensaje obj)
{
try
{
return DMensaje.Instancia.Create(obj);
}
catch (Exception)
{
return false;
}
}
public bool Edit(Mensaje obj)
{
try
{
return DMensaje.Instancia.Edit(obj);
}
catch (Exception)
{
return false;
}
}
public Mensaje Details(int id)
{
try
{
return DMensaje.Instancia.Details(id);
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
return DMensaje.Instancia.DeleteConfirmed(id);
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
return DMensaje.Instancia.Disable(id);
}
catch (Exception)
{
return false;
}
}
public List<Mensaje> SelectAll()
{
return DMensaje.Instancia.SelectAll();
}
public List<Mensaje> SelectAllActivo()
{
return DMensaje.Instancia.SelectAllActivo();
}
}
}
