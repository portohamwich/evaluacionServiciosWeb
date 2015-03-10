using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    public string getRoutes()
    {
        clsRutas rutas =  new clsRutas();
        return rutas.SeleccionaDatosJSON();
    }

    public string getRoute(int id)
    {
        clsRutas ruta = new clsRutas();
        ruta.Id = id;
        return ruta.SeleccionaDato();
    }

    public string getViajes()
    {
        clsViajes v = new clsViajes();
        return v.SeleccionaDatosJSON();
    }

    public string getViaje(int id)
    {
        clsViajes v = new clsViajes();
        v.Id = id;
        return v.SeleccionaDato();
    }


    public string getAllClientes()
    {
        ClsClientes objDatos = new ClsClientes();
        string datos = objDatos.SeleccionaDatosJSON();
        return datos;
    }

    public DataTable getCliente(string dato)
    {
        ClsClientes objDato;
        objDato = JsonConvert.DeserializeObject<ClsClientes>(dato);
        DataTable dttDatos = objDato.SeleccionaDato();
        return dttDatos;
    }

    public bool insertCliente(string datos)
    {
        ClsClientes objDatos;
        objDatos = JsonConvert.DeserializeObject<ClsClientes>(datos);
        bool valido = objDatos.InsertaDatos();
        return valido;
    }

    public bool updateCliente(string datos)
    {
        ClsClientes objDatos;
        objDatos = JsonConvert.DeserializeObject<ClsClientes>(datos);
        bool valido = objDatos.ActualizaDatos();
        return valido;
    }

    public bool exist(string datos)
    {
        ClsClientes objDatos;
        objDatos = JsonConvert.DeserializeObject<ClsClientes>(datos);
        bool valido = objDatos.Existe();
        return valido;
    }

    public DataTable session(string datos)
    {
        ClsClientes objDato;
        objDato = JsonConvert.DeserializeObject<ClsClientes>(datos);
        DataTable dttDato = objDato.Cliente();
        return dttDato;
    }

    public DataTable pago(string datos)
    {
        DataTable dttDato = new DataTable();
        Random rnd = new Random();
        int folio = rnd.Next(1000, 9999);
        string linea = "";

        ClsTransaccion objTrans;
        objTrans = JsonConvert.DeserializeObject<ClsTransaccion>(datos);
        objTrans.Fecha = DateTime.Now;
        objTrans.folio = folio;
        bool valido = objTrans.InsertaDatos();
        if (valido)
        {
            StreamWriter archivo = new StreamWriter(@"C:\inetpub\wwwroot\evaluacion\wcfTransporte\Files\Request\" + "VTA" + folio.ToString() + ".dat");
            linea = "V" + folio.ToString() + ",";
            linea = linea + objTrans.nombre.ToString() + ",";
            linea = linea + objTrans.IdVenta.ToString() + ",";
            linea = linea + objTrans.Tarjeta.ToString() + ",";
            linea = linea + objTrans.FechaExp.ToString("yyyyMMdd") + ",";
            linea = linea + String.Format("{0:0.00}", objTrans.Cantidad) + ",";
            linea = linea + objTrans.Codigo.ToString();
            archivo.WriteLine(linea);
            archivo.Flush();
            archivo.Close();

            System.Threading.Thread.Sleep(10000);

            string _archivo = @"C:\inetpub\wwwroot\evaluacion\wcfTransporte\Files\Request\" + "VTA" + folio.ToString() + ".dat";
            string[] strLineas = File.ReadAllLines(_archivo);
            string[] campos = null;
            List<string> lineaMatriz = null;
            foreach (string _linea in strLineas)
            {
                lineaMatriz = new List<string>();
                campos = linea.Split(",".ToCharArray());
                lineaMatriz.AddRange(campos.ToList());
            }

            System.Threading.Thread.Sleep(10000);

            int autorizacion = rnd.Next(10000, 99999);
            if (double.Parse(lineaMatriz[5].ToString()) < 3000.00)
            {
                archivo = new StreamWriter(@"C:\inetpub\wwwroot\evaluacion\wcfTransporte\Files\Response\" + "VTA" + folio.ToString() + ".res");
                linea = "S," + rnd.Next(10000, 99999).ToString();
            }
            else
            {
                archivo = new StreamWriter(@"C:\inetpub\wwwroot\evaluacion\wcfTransporte\Files\Response\" + "VTA" + folio.ToString() + ".res");
                linea = "N,00000";
            }
            archivo.WriteLine(linea);
            archivo.Flush();
            archivo.Close();

            _archivo = @"C:\inetpub\wwwroot\evaluacion\wcfTransporte\Files\Response\" + "VTA" + folio.ToString() + ".res";
            strLineas = null;
            strLineas = File.ReadAllLines(_archivo);
            campos = null;
            lineaMatriz = null;
            foreach (string _linea in strLineas)
            {
                lineaMatriz = new List<string>();
                campos = linea.Split(",".ToCharArray());
                lineaMatriz.AddRange(campos.ToList());
            }

            ClsTransaccion objDato = new ClsTransaccion();
            objDato.folio = folio;
            objDato.Status = char.Parse(lineaMatriz[0].ToString());
            objDato.ActualizaDatos();

            dttDato = objDato.SeleccionaDato();
        }
        return dttDato;
    }

    public string SeleccionaVentas()
    {
        ClsVentas objVentas = new ClsVentas();
        string dttDatos = objVentas.SeleccionaDatosJSON();
        return dttDatos;
    }

    public int NuevaVenta(string objeto)
    {
        ClsVentas objVenta = new ClsVentas();
        objVenta = Newtonsoft.Json.JsonConvert.DeserializeObject<ClsVentas>(objeto);
        int valido = objVenta.insertaDatos();
        return valido;
    }
}
