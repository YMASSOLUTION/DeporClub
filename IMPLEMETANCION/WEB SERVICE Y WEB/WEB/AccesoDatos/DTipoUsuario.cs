//------------------------------------------------------------------------------
// Author: Dev Peru 
// Generado el Dia: 2015_octubre_11 - 18_52_51 
//-------------------------  ENTIDAD TipoUsuario  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using Entidad;
namespace AccesoDatos
{
public class DTipoUsuario
{
private static DTipoUsuario _instancia;
public static DTipoUsuario Instancia
{
get
{
if (_instancia == null) _instancia = new  DTipoUsuario();
return _instancia;
}
}
protected DTipoUsuario() { }
private CanchaDBEntities1 db = new CanchaDBEntities1();
#region creacion del CRUD 
public bool Create(TipoUsuario obj)
{
try
{
db.TipoUsuario.Add(obj);
db.SaveChanges();
return true;
}
catch (Exception)
{
return false;
}
}
public bool Edit(TipoUsuario objTipoUsuario)
{
TipoUsuario obj = db.TipoUsuario.Find(objTipoUsuario.id);
obj.id = objTipoUsuario.id;
obj.nombre = objTipoUsuario.nombre;
obj.activo = objTipoUsuario.activo;
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
public TipoUsuario Details(int id)
{
try
{
TipoUsuario obj = db.TipoUsuario.Find(id);
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
query = "delete TipoUsuario where id=" + id;
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
var obj = db.TipoUsuario.Find(id);
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
public List<TipoUsuario> SelectAll()
{
List<TipoUsuario> lista=db.TipoUsuario.ToList();
return lista;
}
public List<TipoUsuario> SelectAllActivo()
{
List<TipoUsuario> lista=db.TipoUsuario.Where(a=>a.activo==true).ToList();
return lista;
}
#endregion  
}
}
