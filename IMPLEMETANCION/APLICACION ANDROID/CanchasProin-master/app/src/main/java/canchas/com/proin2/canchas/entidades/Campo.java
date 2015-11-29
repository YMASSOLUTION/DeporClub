package canchas.com.proin2.canchas.entidades;

import java.io.Serializable;

/**
 * Created by USER on 11/11/2015.
 */
public class Campo implements Serializable {

    private int id;
    private int largo;
    private int ancho;
    private int precio;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getLargo() {
        return largo;
    }

    public void setLargo(int largo) {
        this.largo = largo;
    }

    public int getAncho() {
        return ancho;
    }

    public void setAncho(int ancho) {
        this.ancho = ancho;
    }

    public int getPrecio() {
        return precio;
    }

    public void setPrecio(int precio) {
        this.precio = precio;
    }
}
