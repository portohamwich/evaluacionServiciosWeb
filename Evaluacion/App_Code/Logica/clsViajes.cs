using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsProducto
/// </summary>
public class clsViajes : ILogica
{
    private ClsNegociaSql _objDatos;
    public dynamic ObjDatos
    { set { _objDatos = value; } }

    public int Id { get; set; }
    public clsCamion Camion { get; set; }
    public clsRutas Ruta { get; set; }
    public DateTime Hora { get; set; }
    public decimal Costo { get; set; }

    public clsViajes()
    {
        string cadenaCnn = System.Configuration.ConfigurationManager.ConnectionStrings["CadenaSqlSrv"].ConnectionString;
        _objDatos = new ClsNegociaSql(cadenaCnn);
    }

    public List<clsViajes> ConvertTableToList(DataTable dttD)
    {
        List<clsViajes> lstRutas = new List<clsViajes>();
        foreach (DataRow registro in dttD.Rows)
        {
            clsViajes objViajes = new clsViajes();
            objViajes.Id = int.Parse(registro["id"].ToString());

            clsCamion camion = new clsCamion();
            camion.Marca = registro["marca"].ToString();
            camion.Modelo = registro["modelo"].ToString();
            camion.Capacidad = int.Parse(registro["capacidad"].ToString());
            objViajes.Camion = camion;

            clsRutas ruta = new clsRutas();
            ruta.Origen = registro["origen"].ToString();
            ruta.Destino = registro["destino"].ToString();
            objViajes.Ruta = ruta;

            objViajes.Costo = decimal.Parse(registro["costo"].ToString());
            objViajes.Hora = DateTime.Parse(registro["hora"].ToString());

            lstRutas.Add(objViajes);
        }
        return lstRutas;
    }

    public string SeleccionaDatosJSON()
    {
        List<clsViajes> lstViajes = null;
        string sentencia = "SELECT * FROM viajes v " +
                           "INNER JOIN camiones c " +
                           "ON c.id = v.idcamion " +
                           "INNER JOIN rutas r " +
                           "ON r.id = v.idruta";

        lstViajes = ConvertTableToList((DataTable)_objDatos.EjecutaAdaptador(null, null, sentencia, CommandType.Text, "Viajes"));
        string datos = JsonConvert.SerializeObject(lstViajes);
        return datos;
    }

    public dynamic SeleccionaDato()
    {
        List<clsViajes> lstViajes = null;
        string sentencia = "SELECT * FROM viajes v " +
                           "INNER JOIN camiones c " +
                           "ON c.id = v.idcamion " +
                           "INNER JOIN rutas r " +
                           "ON r.id = v.idruta " +
                           "WHERE v.id = @id";

        SqlParameter[] parametros = { new SqlParameter("id", SqlDbType.Int) };
        object[] valores = { Id };

        lstViajes = ConvertTableToList((DataTable)_objDatos.EjecutaAdaptador(parametros, valores, sentencia, CommandType.Text, "Viajes"));
        string datos = JsonConvert.SerializeObject(lstViajes);
        return datos;
    }
    public bool InsertaDatos() { return true; }
    public bool ActualizaDatos() { return true; }
    public bool EliminaDatos() { return true; }
}