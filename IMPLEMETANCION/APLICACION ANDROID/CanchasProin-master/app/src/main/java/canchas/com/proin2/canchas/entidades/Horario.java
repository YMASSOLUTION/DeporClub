package canchas.com.proin2.canchas.entidades;

/**
 * Created by USER on 14/11/2015.
 */
public class Horario {
    private int id;
    private int horaInicio;
    private int horaFin;
    private boolean seleccionado;

    public Horario(){
        this.id=0;
        this.seleccionado=false;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getHoraInicio() {
        return horaInicio;
    }

    public void setHoraInicio(int horaInicio) {
        this.horaInicio = horaInicio;
    }

    public int getHoraFin() {
        return horaFin;
    }

    public void setHoraFin(int horaFin) {
        this.horaFin = horaFin;
    }

    public boolean isSeleccionado() {
        return seleccionado;
    }

    public void setSeleccionado(boolean seleccionado) {
        this.seleccionado = seleccionado;
    }
}
