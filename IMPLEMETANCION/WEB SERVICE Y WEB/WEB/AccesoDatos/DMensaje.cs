//------------------------------------------------------------------------------
// Author: Dev Peru 
// Generado el Dia: 2015_octubre_11 - 18_52_51 
//-------------------------  ENTIDAD Mensaje  ----------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using Entidad;
namespace AccesoDatos
{
public class DMensaje
{
private static DMensaje _instancia;
public static DMensaje Instancia
{
get
{
if (_instancia == null) _instancia = new  DMensaje();
return _instancia;
}
}
protected DMensaje() { }
private CanchaDBEntities1 db = new CanchaDBEntities1();
#region creacion del CRUD 
public bool Create(Mensaje obj)
{
try
{
db.Mensaje.Add(obj);
db.SaveChanges();
return true;
}
catch (Exception)
{
return false;
}
}
public bool Edit(Mensaje objMensaje)
{
Mensaje obj = db.Mensaje.Find(objMensaje.id);
obj.id = objMensaje.id;
obj.idPelotero = objMensaje.idPelotero;
obj.idReceptor = objMensaje.idReceptor;
obj.descripcion = objMensaje.descripcion;
obj.visto = objMensaje.visto;
obj.activo = objMensaje.activo;
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
public Mensaje Details(int id)
{
try
{
Mensaje obj = db.Mensaje.Find(id);
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
query = "delete Mensaje where id=" + id;
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
var obj = db.Mensaje.Find(id);
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
public List<Mensaje> SelectAll()
{
List<Mensaje> lista=db.Mensaje.ToList();
return lista;
}
public List<Mensaje> SelectAllActivo()
{
List<Mensaje> lista=db.Mensaje.Where(a=>a.activo==true).ToList();
return lista;
}
#endregion  
}
}
