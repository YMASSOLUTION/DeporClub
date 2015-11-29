package canchas.com.proin2.canchas.entidades;

import java.io.Serializable;

/**
 * Created by USER on 11/11/2015.
 */
public class CentroDeportivo implements Serializable {
    private int id;
    private String nombre;
    private String direccion;
    private String telefono;
    private boolean balon;
    private boolean camisetas;
    private double latitud;
    private double longitud;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getDireccion() {
        return direccion;
    }

    public void setDireccion(String direccion) {
        this.direccion = direccion;
    }

    public String getTelefono() {
        return telefono;
    }

    public void setTelefono(String telefono) {
        this.telefono = telefono;
    }

    public boolean isBalon() {
        return balon;
    }

    public void setBalon(boolean balon) {
        this.balon = balon;
    }

    public boolean isCamisetas() {
        return camisetas;
    }

    public void setCamisetas(boolean camisetas) {
        this.camisetas = camisetas;
    }

    public double getLatitud() {
        return latitud;
    }

    public void setLatitud(double latitud) {
        this.latitud = latitud;
    }

    public double getLongitud() {
        return longitud;
    }

    public void setLongitud(double longitud) {
        this.longitud = longitud;
    }
}
