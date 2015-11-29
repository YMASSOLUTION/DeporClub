package canchas.com.proin2.canchas;

import android.content.Intent;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SimpleAdapter;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import canchas.com.proin2.canchas.entidades.Reserva;
import canchas.com.proin2.canchas.entidades.Usuario;
import canchas.com.proin2.canchas.utilidades.Application;
import canchas.com.proin2.canchas.utilidades.ConexionWS;

public class MisReservasActivity extends AppCompatActivity {

    private Usuario objUsuario;
    private List<Reserva> listaReserva=new ArrayList<>();
    private ListView listaAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_mis_reservas);

        final Application global=(Application)getApplicationContext();
        objUsuario=global.getObjUsuario();

        WSListarReservas ws=new WSListarReservas();
        ws.execute();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_mis_reservas, menu);
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


    private class WSListarReservas extends AsyncTask<String,Integer,Boolean> {
        boolean error=false;
        protected void onPreExecute() {
            super.onPreExecute();

        }

        protected Boolean doInBackground(String... params) {
            boolean resul = true;

            ConexionWS objConex=new ConexionWS("listarReservas");

            SoapObject request = new SoapObject(objConex.getNameSpace(), objConex.getMethodName());
            request.addProperty("idUsuario", objUsuario.getId());


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
                        Reserva objReserva=new Reserva();
                        objReserva.setId(Integer.parseInt(obj2.getProperty(0).toString()));
                        objReserva.setCentrodeportivo(obj2.getProperty(1).toString());
                        objReserva.setCampo(obj2.getProperty(2).toString());
                        objReserva.setFecha(obj2.getProperty(3).toString());
                        objReserva.setHoraInicio(obj2.getProperty(4).toString());
                        objReserva.setHoraFin(obj2.getProperty(5).toString());

                        listaReserva.add(objReserva);
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

                for (Reserva obj:listaReserva){
                    HashMap<String,String> map=new HashMap<String,String>();
                    map.put("campo",obj.getCentrodeportivo() + " - " + obj.getCampo());
                    map.put("precio",obj.getFecha()+"  "+obj.getHoraInicio()+" - "+obj.getHoraFin());

                    mylist.add(map);
                }

                ListAdapter adapter=new SimpleAdapter(MisReservasActivity.this
                        ,mylist,R.layout.activity_item_reserva
                        ,new String[]{"campo","precio"}
                        ,new int[]{R.id.lblCentroDeportivo,R.id.txtFecha});

                listaAdapter=(ListView)findViewById(R.id.listViewPersona);

                listaAdapter.setAdapter(adapter);

                listaAdapter.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                    @Override
                    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                        Intent i=new Intent(MisReservasActivity.this,InvitarAmigosActivity.class);
                        Bundle objBundle2=new Bundle();
                        objBundle2.putSerializable("canchas.com.proin2.canchas.objReserva",listaReserva.get(position));
                        i.putExtras(objBundle2);

                        finish();

                        startActivity(i);


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
}
