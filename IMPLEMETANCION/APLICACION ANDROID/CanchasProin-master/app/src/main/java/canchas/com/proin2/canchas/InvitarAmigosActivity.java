package canchas.com.proin2.canchas;

import android.content.Intent;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.telephony.SmsManager;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.CheckBox;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.Toast;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import canchas.com.proin2.canchas.entidades.Deportista;
import canchas.com.proin2.canchas.entidades.Reserva;
import canchas.com.proin2.canchas.entidades.Usuario;
import canchas.com.proin2.canchas.utilidades.Application;
import canchas.com.proin2.canchas.utilidades.ConexionWS;

public class InvitarAmigosActivity extends AppCompatActivity {

    private static Reserva objReserva;
    private Usuario objUsuario;
    private ListView listaAdapter;
    private List<Deportista> listaDeportista=new ArrayList<>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_invitar_amigos);

        if(objReserva==null){
            objReserva=(Reserva)getIntent().getExtras().getSerializable("canchas.com.proin2.canchas.objReserva");
        }

        final Application global=(Application)getApplicationContext();
        objUsuario=global.getObjUsuario();

        WSListarAmigos ws=new WSListarAmigos();
        ws.execute();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_invitar_amigos, menu);
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


    private class WSListarAmigos extends AsyncTask<String,Integer,Boolean> {
        boolean error=false;
        protected void onPreExecute() {
            super.onPreExecute();

        }

        protected Boolean doInBackground(String... params) {
            boolean resul = true;

            ConexionWS objConex=new ConexionWS("listarAmigos");

            SoapObject request = new SoapObject(objConex.getNameSpace(), objConex.getMethodName());
            request.addProperty("idDeportista", objUsuario.getIdDeportista());

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

                    for(int i=0; i<obj1.getPropertyCount(); i++)
                    {
                        SoapObject obj2 =(SoapObject) obj1.getProperty(i);
                        Deportista objDeportista=new Deportista();
                        objDeportista.setId(Integer.parseInt(obj2.getProperty(0).toString()));
                        objDeportista.setNombre(obj2.getProperty(1).toString());
                        objDeportista.setApellidos(obj2.getProperty(2).toString());
                        objDeportista.setCelular(obj2.getProperty(4).toString());

                        listaDeportista.add(objDeportista);
                    }
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

                ArrayList<HashMap<String,String>> mylist=new ArrayList<HashMap<String, String>>();

                for (Deportista obj:listaDeportista){
                    HashMap<String,String> map=new HashMap<String,String>();
                    map.put("campo",obj.getNombre()+" "+obj.getApellidos());

                    mylist.add(map);
                }

                ListAdapter adapter=new SimpleAdapter(InvitarAmigosActivity.this
                        ,mylist,R.layout.activity_item_deportista
                        ,new String[]{"campo"}
                        ,new int[]{R.id.lblHorario});

                listaAdapter=(ListView)findViewById(R.id.listViewPersona);

                listaAdapter.setAdapter(adapter);

                listaAdapter.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                    @Override
                    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                        CheckBox cb=(CheckBox)view.findViewById(R.id.chkEstado);
                        if(cb.isChecked()){
                            cb.setChecked(false);
                            listaDeportista.get(position).setSeleccionado(false);
                        }else{
                            cb.setChecked(true);
                            listaDeportista.get(position).setSeleccionado(true);
                        }
                    }
                });

               /* Intent i=new Intent(LoginActivity.this,MainActivity.class);
                startActivity(i);*/
            }
            else{
               /* Toast.makeText(LoginActivity.this, "Usuario o password no valido",
                        Toast.LENGTH_LONG).show();*/
            }

        }
    }





    public void viewGuardar(View v){

        boolean flag=false;

        for(Deportista obj:listaDeportista){
            if(obj.isSeleccionado()){
                flag=true;
                break;
            }
        }

        if(flag){
            WSDetalleInvitados ws=new WSDetalleInvitados();
            ws.execute();
        }
        else{
            Toast.makeText(InvitarAmigosActivity.this, "Debe Seleccionar un amigo",
                    Toast.LENGTH_LONG).show();
        }
    }


    private class WSDetalleInvitados extends AsyncTask<Integer,Integer,Boolean> {
        boolean error=false;
        protected void onPreExecute() {
            super.onPreExecute();

        }

        protected Boolean doInBackground(Integer... params) {
            boolean resul = true;

            ConexionWS objConex=new ConexionWS("crearDetalleInvitado");

            SoapObject request = new SoapObject(objConex.getNameSpace(), objConex.getMethodName());
            request.addProperty("idReserva",objReserva.getId());


            SoapObject soapLogs = new SoapObject(objConex.getNameSpace(), "idpeloteros");

            for(Deportista obj: listaDeportista){
                if(obj.isSeleccionado()){
                    soapLogs.addProperty("int",obj.getId());
                    sendSMS(obj.getCelular(),"Estas invitado al Centro Deportivo: "+objReserva.getCentrodeportivo()
                            +" en el Campo: "+objReserva.getCampo()+", el Dia: "+objReserva.getFecha()+" a las "+objReserva.getHoraInicio());
                 }
            }

            request.addSoapObject(soapLogs);


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

                Toast.makeText(InvitarAmigosActivity.this, "Invitaciones enviadas",
                        Toast.LENGTH_LONG).show();
                finish();
                Intent i=new Intent(InvitarAmigosActivity.this,MainActivity.class);
                startActivity(i);
            }
            else{
                Toast.makeText(InvitarAmigosActivity.this, "No se envio la invitacion",
                        Toast.LENGTH_LONG).show();
            }

        }
    }


    private void sendSMS(String phoneNumber, String message)
    {
        SmsManager sms = SmsManager.getDefault();
        sms.sendTextMessage(phoneNumber, null, message, null, null);

    }


}
