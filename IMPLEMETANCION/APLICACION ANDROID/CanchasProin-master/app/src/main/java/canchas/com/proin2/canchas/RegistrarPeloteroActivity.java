package canchas.com.proin2.canchas;

import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import canchas.com.proin2.canchas.utilidades.ConexionWS;

public class RegistrarPeloteroActivity extends AppCompatActivity {

    private EditText txtNombre,txtApellidos,txtCelular,txtEmail,txtUsuario,txtContrasenia;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_registrar_pelotero);

        findViewById();

    }

    void findViewById(){
        txtNombre=(EditText)findViewById(R.id.txtNombre);
        txtApellidos=(EditText)findViewById(R.id.txtApellidos);
        txtCelular=(EditText)findViewById(R.id.txtCelular);
        txtEmail=(EditText)findViewById(R.id.txtEmail);
        txtUsuario=(EditText)findViewById(R.id.txtUsuario);
        txtContrasenia=(EditText)findViewById(R.id.txtContrasenia);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_registrar_pelotero, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    public void viewRegistrar(View v){

        WSRegistrarDeportista ws=new WSRegistrarDeportista();
        ws.execute();

    }


    private class WSRegistrarDeportista extends AsyncTask<String,Integer,Boolean> {
        boolean error=false;
        protected void onPreExecute() {
            super.onPreExecute();

        }

        protected Boolean doInBackground(String... params) {
            boolean resul = true;

            ConexionWS objConex=new ConexionWS("registrarPelotero");

            SoapObject request = new SoapObject(objConex.getNameSpace(), objConex.getMethodName());
            request.addProperty("nombre",txtNombre.getText().toString());
            request.addProperty("apellidos",txtApellidos.getText().toString());
            request.addProperty("celular",txtCelular.getText().toString());
            request.addProperty("email",txtEmail.getText().toString());
            request.addProperty("nick",txtUsuario.getText().toString());
            request.addProperty("clave",txtContrasenia.getText().toString());

            SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
            envelope.dotNet = true;
            envelope.setOutputSoapObject(request);
            HttpTransportSE transporte = new HttpTransportSE(objConex.getUrl());
            transporte.debug=true;
            try
            {
                 transporte.call(objConex.getSoapAction(), envelope);
                  Log.e("Soap error, request ", transporte.requestDump);
                  Log.e("Soap error, response ",transporte.responseDump);

                SoapPrimitive obj1 = (SoapPrimitive) envelope.getResponse();
                  if (!Boolean.parseBoolean(obj1.toString())){
                      resul = false;
                  }else{
                   resul=true;
                 }
            }
            catch (Exception e)
            {
                e.printStackTrace();
                error = true;
            }
            return resul;
        }
        protected void onPostExecute(Boolean result) {

            if(result){
                Toast.makeText(RegistrarPeloteroActivity.this, "Deportista creado con exito",
                        Toast.LENGTH_LONG).show();

                finish();

            }else{

                Toast.makeText(RegistrarPeloteroActivity.this, "Error al registrar deportista",
                        Toast.LENGTH_LONG).show();
            }

        }
    }


}
