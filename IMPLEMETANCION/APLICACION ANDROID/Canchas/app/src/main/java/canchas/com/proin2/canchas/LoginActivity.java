package canchas.com.proin2.canchas;

import android.content.Intent;
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
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import canchas.com.proin2.canchas.entidades.Usuario;
import canchas.com.proin2.canchas.utilidades.Application;
import canchas.com.proin2.canchas.utilidades.ConexionWS;

public class LoginActivity extends AppCompatActivity {

    EditText txtUsuario,txtPassword;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        txtUsuario=(EditText)findViewById(R.id.txtUsuario);
        txtPassword=(EditText)findViewById(R.id.txtPassword);

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_login, menu);
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

    public void viewLogin(View v){

        if(txtUsuario.getText().toString().trim().length()>3) {
            if (txtPassword.getText().toString().trim().length() > 3) {

                WSLogin ws=new WSLogin();
                ws.execute();

            } else {
                Toast.makeText(LoginActivity.this, "La contraseña debe tener mas de 3 caracteres",
                        Toast.LENGTH_LONG).show();
            }
        }
        else{
            Toast.makeText(LoginActivity.this, "El usuario debe tener mas de 3 caracteres",
                    Toast.LENGTH_LONG).show();
        }

    }

    public void viewRegistrar(View v){
        Intent i=new Intent(LoginActivity.this,RegistrarPeloteroActivity.class);
        startActivity(i);
    }




    private class WSLogin extends AsyncTask<String,Integer,Boolean> {
        boolean error=false;
        protected void onPreExecute() {
            super.onPreExecute();

        }

        protected Boolean doInBackground(String... params) {
            boolean resul = true;

            ConexionWS objConex=new ConexionWS("Login");

            SoapObject request = new SoapObject(objConex.getNameSpace(), objConex.getMethodName());
            request.addProperty("usuario",txtUsuario.getText().toString());
            request.addProperty("clave",txtPassword.getText().toString());

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

                SoapObject obj1 = (SoapObject) envelope.getResponse();
                if (obj1 == null){
                    resul = false;
                }else{
                    Usuario objUsuario=new Usuario();
                    objUsuario.setId(Integer.parseInt(obj1.getProperty(0).toString()));
                    objUsuario.setNick(obj1.getProperty(1).toString());
                    objUsuario.setIdTipoUsuario(Integer.parseInt(obj1.getProperty(2).toString()));

                    final Application global=(Application)getApplicationContext();
                    global.setObjUsuario(objUsuario);

                }
            }
            catch (Exception e)
            {
                resul=false;
                e.printStackTrace();
                error = true;
            }
            return resul;
        }
        protected void onPostExecute(Boolean result) {

            if(result){
                Intent i=new Intent(LoginActivity.this,MainActivity.class);
                startActivity(i);
            }
            else{
                Toast.makeText(LoginActivity.this, "Usuario o password no valido",
                        Toast.LENGTH_LONG).show();
            }

        }
    }



}
