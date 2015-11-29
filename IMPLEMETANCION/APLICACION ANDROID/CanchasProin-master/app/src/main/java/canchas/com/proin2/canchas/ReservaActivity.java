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
import android.widget.CheckBox;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.gms.internal.fe;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;

import canchas.com.proin2.canchas.entidades.Campo;
import canchas.com.proin2.canchas.entidades.Horario;
import canchas.com.proin2.canchas.entidades.Reserva;
import canchas.com.proin2.canchas.entidades.Usuario;
import canchas.com.proin2.canchas.utilidades.Application;
import canchas.com.proin2.canchas.utilidades.ConexionWS;

public class ReservaActivity extends AppCompatActivity {


    private EditText dtpDate;
    private TextView lblTotal;

    private SimpleDateFormat dateFormatter;
    private ListView listaAdapter;

    private DatePickerDialog fromDatePickerDialog;

    private static Campo objCampo;
    private Usuario objUsuario;

    private List<Horario> listaHorario=new ArrayList<Horario>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_reserva);

        if(objCampo==null){
            objCampo=(Campo)getIntent().getExtras().getSerializable("canchas.com.proin2.canchas.objCampo");
        }
        final Application global=(Application)getApplicationContext();
        objUsuario=global.getObjUsuario();

        dateFormatter = new SimpleDateFormat("dd-MM-yyyy", Locale.US);
        dtpDate=(EditText)findViewById(R.id.dtpFecha);
        lblTotal=(TextView)findViewById(R.id.lblTotal);

        setDateTimeField();
    }


    private void setDateTimeField() {
        dtpDate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                fromDatePickerDialog.show();
            }
        });

        Calendar newCalendar = Calendar.getInstance();
        fromDatePickerDialog = new DatePickerDialog(this, new DatePickerDialog.OnDateSetListener() {

            public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {
                Calendar newDate = Calendar.getInstance();
                newDate.set(year, monthOfYear, dayOfMonth);
                dtpDate.setText(dateFormatter.format(newDate.getTime()));
            }

        },newCalendar.get(Calendar.YEAR), newCalendar.get(Calendar.MONTH), newCalendar.get(Calendar.DAY_OF_MONTH));
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_reserva, menu);
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

    public void viewBuscar(View v){

        if(!dtpDate.getText().toString().equals("")){
            WSListarHorarios ws=new WSListarHorarios();
            ws.execute();
        }
        else{
            Toast.makeText(ReservaActivity.this, "Seleccione una fecha primero",
                    Toast.LENGTH_LONG).show();
        }

    }


    private class WSListarHorarios extends AsyncTask<String,Integer,Boolean> {
        boolean error=false;
        protected void onPreExecute() {
            super.onPreExecute();

        }

        protected Boolean doInBackground(String... params) {
            boolean resul = true;

            ConexionWS objConex=new ConexionWS("listarHorarioDisponible");


            SoapObject request = new SoapObject(objConex.getNameSpace(), objConex.getMethodName());
            request.addProperty("fecha", dtpDate.getText().toString());
            request.addProperty("idcampo",objCampo.getId());


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
                    listaHorario.clear();
                    for(int i=0; i<obj1.getPropertyCount(); i++)
                    {
                        SoapObject obj2 =(SoapObject) obj1.getProperty(i);
                        Horario objHorario=new Horario();
                        objHorario.setHoraInicio(Integer.parseInt(obj2.getProperty(0).toString()));
                        objHorario.setHoraFin(Integer.parseInt(obj2.getProperty(1).toString()));

                        listaHorario.add(objHorario);
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

                for (Horario obj:listaHorario){
                    HashMap<String,String> map=new HashMap<String,String>();
                    map.put("horario",obj.getHoraInicio()+" - "+obj.getHoraFin());

                    mylist.add(map);
                }

                ListAdapter adapter=new SimpleAdapter(ReservaActivity.this
                        ,mylist,R.layout.activity_item_horario
                        ,new String[]{"horario"}
                        ,new int[]{R.id.lblHorario});

                listaAdapter=(ListView)findViewById(R.id.listViewPersona);

                listaAdapter.setAdapter(adapter);

                listaAdapter.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                    @Override
                    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                        CheckBox cb=(CheckBox)view.findViewById(R.id.chkEstado);
                        if(cb.isChecked()){
                            cb.setChecked(false);
                            listaHorario.get(position).setSeleccionado(false);
                        }else{
                            cb.setChecked(true);
                            listaHorario.get(position).setSeleccionado(true);
                        }

                        calcularTotal();
                       /* Intent i=new Intent(CanchasActivity.this,ReservaActivity.class);
                        startActivity(i);*/
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


    void calcularTotal(){
        int total=0;
        for (int i=0;i<listaHorario.size();i++){
            if(listaHorario.get(i).isSeleccionado()){
                total+=objCampo.getPrecio();
            }
        }

        lblTotal.setText(""+total);

    }

    public void viewGuardar(View v){

        boolean flag=false;

        for(Horario obj:listaHorario){
            if(obj.isSeleccionado()){
                flag=true;
                break;
            }
        }

        if(flag){
            WSRegistrarReserva ws=new WSRegistrarReserva();
            ws.execute();
        }
        else{
            Toast.makeText(ReservaActivity.this, "Debe Seleccionar un horario",
                    Toast.LENGTH_LONG).show();
        }



    }

    private class WSRegistrarReserva extends AsyncTask<Integer,Integer,Boolean> {
        boolean error=false;
        protected void onPreExecute() {
            super.onPreExecute();

        }

        protected Boolean doInBackground(Integer... params) {
            boolean resul = true;

            ConexionWS objConex=new ConexionWS("registrarReserva");

            SoapObject request = new SoapObject(objConex.getNameSpace(), objConex.getMethodName());
            request.addProperty("fecha",dtpDate.getText().toString());
            request.addProperty("idUsuario",objUsuario.getId());
            request.addProperty("idCancha",objCampo.getId());


            SoapObject soapLogs = new SoapObject(objConex.getNameSpace(), "horaInicio");
            SoapObject soapLogs2 = new SoapObject(objConex.getNameSpace(), "horaFin");

            for(Horario obj: listaHorario){
                if(obj.isSeleccionado()){
                    soapLogs.addProperty("string",obj.getHoraInicio());
                    soapLogs2.addProperty("string",obj.getHoraFin());
                }
            }

            request.addSoapObject(soapLogs);
            request.addSoapObject(soapLogs2);



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

                Toast.makeText(ReservaActivity.this, "Reserva Registrada",
                        Toast.LENGTH_LONG).show();
                finish();
                Intent i=new Intent(ReservaActivity.this,MainActivity.class);
                startActivity(i);
            }
            else{
                Toast.makeText(ReservaActivity.this, "Hubo un error al registrar",
                        Toast.LENGTH_LONG).show();
            }

        }
    }

}
