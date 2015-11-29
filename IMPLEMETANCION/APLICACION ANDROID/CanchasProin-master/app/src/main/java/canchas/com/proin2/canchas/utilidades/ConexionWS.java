package canchas.com.proin2.canchas.utilidades;

/**
 * Created by USER on 02/11/2015.
 */
public class ConexionWS {

    private String nameSpace;
    private String url;
    private String methodName;
    private String soapAction;

    public ConexionWS(String methodName){
        this.methodName=methodName;
        this.nameSpace="http://tempuri.org/";
        this.url="192.168.1.200/Webservices/CanchasWS.asmx";
        this.soapAction= this.nameSpace+methodName;
    }

    public String getNameSpace() {
        return nameSpace;
    }

    public String getUrl() {
        return url;
    }

    public String getMethodName() {
        return methodName;
    }

    public String getSoapAction() {
        return soapAction;
    }
}
