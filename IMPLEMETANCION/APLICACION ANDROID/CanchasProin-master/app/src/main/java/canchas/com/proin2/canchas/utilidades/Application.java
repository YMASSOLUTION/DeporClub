package canchas.com.proin2.canchas.utilidades;

import canchas.com.proin2.canchas.entidades.Usuario;

/**
 * Created by USER on 11/11/2015.
 */
public class Application extends android.app.Application {

    private Usuario objUsuario;

    public Usuario getObjUsuario() {
        return objUsuario;
    }

    public void setObjUsuario(Usuario objUsuario) {
        this.objUsuario = objUsuario;
    }
}
