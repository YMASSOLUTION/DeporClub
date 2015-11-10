//------------------------------------------------------------------------------
// Author: Dev Peru
// Generado el Dia: 2015_octubre_11 - 19_15_39 
//-------------------------  Negocio NDepartamento  ----------------------------------------
using Entidad;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Negocio
{
public class NDepartamento
{
private static NDepartamento _instancia;
public static NDepartamento Instancia
{
get
{
if (_instancia == null) _instancia = new  NDepartamento();
return _instancia;
}
}
protected NDepartamento() { }
public bool Create(Departamento obj)
{
try
{
return DDepartamento.Instancia.Create(obj);
}
catch (Exception)
{
return false;
}
}
public bool Edit(Departamento obj)
{
try
{
return DDepartamento.Instancia.Edit(obj);
}
catch (Exception)
{
return false;
}
}
public Departamento Details(int id)
{
try
{
return DDepartamento.Instancia.Details(id);
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
return DDepartamento.Instancia.DeleteConfirmed(id);
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
return DDepartamento.Instancia.Disable(id);
}
catch (Exception)
{
return false;
}
}
public List<Departamento> SelectAll()
{
return DDepartamento.Instancia.SelectAll();
}
public List<Departamento> SelectAllActivo()
{
return DDepartamento.Instancia.SelectAllActivo();
}
}
}
