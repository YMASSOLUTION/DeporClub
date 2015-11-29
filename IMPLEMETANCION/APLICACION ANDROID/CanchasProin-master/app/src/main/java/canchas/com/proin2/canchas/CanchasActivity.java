package canchas.com.proin2.canchas;

import android.app.DatePickerDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.TextView;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;

import canchas.com.proin2.canchas.entidades.Campo;
import canchas.com.proin2.canchas.entidades.CentroDeportivo;
import canchas.com.proin2.canchas.utilidades.ConexionWS;

public class CanchasActivity extends AppCompatActivity {

    private static CentroDeportivo objCentroDeportivo;
    TextView lblNombre,lblDireccion,lblTelefono,lblBalon,lblCamisetas;
    private ListView listaAdapter;
    private List<Campo> listaCampo=new ArrayList<Campo>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_canchas);

        if(objCentroDeportivo==null){
            objCentroDeportivo=(CentroDeportivo)getIntent().getExtras().getSerializable("canchas.com.proin2.canchas.objSucursal");
        }


        findViews();

        lblNombre.setText(objCentroDeportivo.getNombre());
        lblDireccion.setText(objCentroDeportivo.getDireccion());
        lblTelefono.setText(objCentroDeportivo.getTelefono());
        lblBalon.setText((objCentroDeportivo.isBalon()?"Si":"No"));
        lblCamisetas.setText(objCentroDeportivo.isCamisetas()?"Si":"No");


        WSListarCampo ws=new WSListarCampo();
        ws.execute();

    }

    void findViews(){
        lblNombre=(TextView)findViewById(R.id.lblNombre);
        lblDireccion=(TextView)findViewById(R.id.lblDireccion);
        lblTelefono=(TextView)findViewById(R.id.lblTelefono);
        lblBalon=(TextView)findViewById(R.id.lblBalon);
        lblCamisetas=(TextView)findViewById(R.id.lblCamisetas);
    }




    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_canchas, menu);
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


    private class WSListarCampo extends AsyncTask<String,Integer,Boolean> {
        boolean error=false;
        protected void onPreExecute() {
            super.onPreExecute();

        }

        protected Boolean doInBackground(String... params) {
            boolean resul = true;

            ConexionWS objConex=new ConexionWS("listarCamposPorCentroDeportivo");

            SoapObject request = new SoapObject(objConex.getNameSpace(), objConex.getMethodName());
            request.addProperty("idCentroDeportivo",objCentroDeportivo.getId());


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
                        Campo objCampo=new Campo();
                        objCampo.setId(Integer.parseInt(obj2.getProperty(0).toString()));
                        objCampo.setLargo(Integer.parseInt(obj2.getProperty(1).toString()));
                        objCampo.setAncho(Integer.parseInt(obj2.getProperty(2).toString()));
                        objCampo.setPrecio(Integer.parseInt(obj2.getProperty(3).toString()));

                        listaCampo.add(objCampo);
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

                for (Campo obj:listaCampo){
                    HashMap<String,String> map=new HashMap<String,String>();
                    map.put("campo","Largo: "+obj.getLargo()+" Ancho: "+obj.getAncho());
                    map.put("precio","S/. "+obj.getPrecio());

                    mylist.add(map);
                }

                ListAdapter adapter=new SimpleAdapter(CanchasActivity.this
                        ,mylist,R.layout.activity_item_campo
                        ,new String[]{"campo","precio"}
                        ,new int[]{R.id.txtCampo,R.id.txtPrecio});

                listaAdapter=(ListView)findViewById(R.id.listViewPersona);

                listaAdapter.setAdapter(adapter);

                listaAdapter.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                    @Override
                    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                        Intent i=new Intent(CanchasActivity.this,ReservaActivity.class);
                        Bundle objBundle2=new Bundle();
                        objBundle2.putSerializable("canchas.com.proin2.canchas.objCampo",listaCampo.get(position));
                        i.putExtras(objBundle2);
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
