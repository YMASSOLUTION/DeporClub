//------------------------------------------------------------------------------
// Author: Dev Peru
// Generado el Dia: 2015_octubre_11 - 19_15_39 
//-------------------------  Negocio NTipoUsuario  ----------------------------------------
using Entidad;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Negocio
{
public class NTipoUsuario
{
private static NTipoUsuario _instancia;
public static NTipoUsuario Instancia
{
get
{
if (_instancia == null) _instancia = new  NTipoUsuario();
return _instancia;
}
}
protected NTipoUsuario() { }
public bool Create(TipoUsuario obj)
{
try
{
return DTipoUsuario.Instancia.Create(obj);
}
catch (Exception)
{
return false;
}
}
public bool Edit(TipoUsuario obj)
{
try
{
return DTipoUsuario.Instancia.Edit(obj);
}
catch (Exception)
{
return false;
}
}
public TipoUsuario Details(int id)
{
try
{
return DTipoUsuario.Instancia.Details(id);
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
return DTipoUsuario.Instancia.DeleteConfirmed(id);
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
return DTipoUsuario.Instancia.Disable(id);
}
catch (Exception)
{
return false;
}
}
public List<TipoUsuario> SelectAll()
{
return DTipoUsuario.Instancia.SelectAll();
}
public List<TipoUsuario> SelectAllActivo()
{
return DTipoUsuario.Instancia.SelectAllActivo();
}
}
}
