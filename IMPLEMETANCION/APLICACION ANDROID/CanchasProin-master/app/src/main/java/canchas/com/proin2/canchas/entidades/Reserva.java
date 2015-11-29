package canchas.com.proin2.canchas.entidades;

import java.io.Serializable;

/**
 * Created by USER on 15/11/2015.
 */
public class Reserva implements Serializable {
    private  int id;
    private String centrodeportivo;
    private String campo;
    private String fecha;
    private String horaInicio;
    private String horaFin;


    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getCentrodeportivo() {
        return centrodeportivo;
    }

    public void setCentrodeportivo(String centrodeportivo) {
        this.centrodeportivo = centrodeportivo;
    }

    public String getCampo() {
        return campo;
    }

    public void setCampo(String campo) {
        this.campo = campo;
    }

    public String getFecha() {
        return fecha;
    }

    public void setFecha(String fecha) {
        this.fecha = fecha;
    }

    public String getHoraInicio() {
        return horaInicio;
    }

    public void setHoraInicio(String horaInicio) {
        this.horaInicio = horaInicio;
    }

    public String getHoraFin() {
        return horaFin;
    }

    public void setHoraFin(String horaFin) {
        this.horaFin = horaFin;
    }
}
