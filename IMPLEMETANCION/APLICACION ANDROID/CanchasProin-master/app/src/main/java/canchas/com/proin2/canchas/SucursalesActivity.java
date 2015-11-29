package canchas.com.proin2.canchas;

import android.content.Intent;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;

import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapFragment;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.BitmapDescriptorFactory;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.Marker;
import com.google.android.gms.maps.model.MarkerOptions;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import java.util.ArrayList;
import java.util.List;

import canchas.com.proin2.canchas.R;
import canchas.com.proin2.canchas.entidades.CentroDeportivo;
import canchas.com.proin2.canchas.utilidades.ConexionWS;

public class SucursalesActivity extends AppCompatActivity {

    private GoogleMap googleMap;
    private List<CentroDeportivo> lista=new ArrayList<CentroDeportivo>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sucursales);

        googleMap =((MapFragment) getFragmentManager().findFragmentById(R.id.map)).getMap();

        googleMap.setMyLocationEnabled(true);

        googleMap.setOnInfoWindowClickListener(new GoogleMap.OnInfoWindowClickListener() {
            @Override
            public void onInfoWindowClick(Marker marker) {

                // Toast.makeText(getActivity(), marker.getId(), Toast.LENGTH_SHORT).show();
                Intent i=new Intent(SucursalesActivity.this,CanchasActivity.class);
                Bundle objBundle2=new Bundle();
                objBundle2.putSerializable("canchas.com.proin2.canchas.objSucursal",lista.get(0));
                i.putExtras(objBundle2);
                startActivity(i);
            }
        });


        googleMap.moveCamera(CameraUpdateFactory.zoomTo(12));
        googleMap.animateCamera(CameraUpdateFactory.newLatLng(new LatLng(-8.106154, -79.023623)));

        WSCentroDeportivo ws=new WSCentroDeportivo();
        ws.execute();


    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_sucursales, menu);
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

    private void setMarker(LatLng position, String titulo, String info) {
        // Agregamos marcadores para indicar sitios de interéses.
        Marker myMaker = googleMap.addMarker(new MarkerOptions()
                .position(position)
                .title(titulo) //Agrega un titulo al marcador
                .snippet(info) //Agrega información detalle relacionada con el marcador
                .icon(BitmapDescriptorFactory.defaultMarker(BitmapDescriptorFactory.HUE_GREEN))); //Color del marcador
    }


    private class WSCentroDeportivo extends AsyncTask<String,Integer,Boolean> {
        boolean error=false;
        protected void onPreExecute() {
            super.onPreExecute();

        }

        protected Boolean doInBackground(String... params) {
            boolean resul = true;

            ConexionWS objConex=new ConexionWS("listarCentrosDeportivos");

            SoapObject request = new SoapObject(objConex.getNameSpace(), objConex.getMethodName());


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
                        CentroDeportivo objCentro=new CentroDeportivo();
                        objCentro.setId(Integer.parseInt(obj2.getProperty(0).toString()));
                        objCentro.setNombre(obj2.getProperty(1).toString());
                        objCentro.setDireccion(obj2.getProperty(2).toString());
                        objCentro.setTelefono(obj2.getProperty(3).toString());
                        objCentro.setBalon(Boolean.parseBoolean(obj2.getProperty(4).toString()));
                        objCentro.setCamisetas(Boolean.parseBoolean(obj2.getProperty(5).toString()));
                        objCentro.setLatitud(Double.parseDouble(obj2.getProperty(6).toString()));
                        objCentro.setLongitud(Double.parseDouble(obj2.getProperty(7).toString()));

                        lista.add(objCentro);

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

                for (CentroDeportivo obj:lista){
                    setMarker(new LatLng(obj.getLatitud(), obj.getLongitud()),obj.getNombre(),obj.getNombre());
                }
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
