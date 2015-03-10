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
public class clsRutas : ILogica
{
    private ClsNegociaSql _objDatos;
    public dynamic ObjDatos
    { set { _objDatos = value; } }

    public int Id { get; set; }
    public string Origen { get; set; }
    public string Destino { get; set; }
    public decimal Costo { get; set; }

    public clsRutas()
    {
        string cadenaCnn = System.Configuration.ConfigurationManager.ConnectionStrings["CadenaSqlSrv"].ConnectionString;
        _objDatos = new ClsNegociaSql(cadenaCnn);
    }

    public List<clsRutas> ConvertTableToList(DataTable dttD)
    {
        List<clsRutas> lstRutas = new List<clsRutas>();
        foreach (DataRow registro in dttD.Rows)
        {
            clsRutas objRutas = new clsRutas();
            objRutas.Id = int.Parse(registro["id"].ToString());
            objRutas.Origen = registro["origen"].ToString();
            objRutas.Destino = registro["destino"].ToString();
            objRutas.Costo = decimal.Parse(registro["costo"].ToString());

            lstRutas.Add(objRutas);
        }
        return lstRutas;
    }

    public string SeleccionaDatosJSON()
    {
        List<clsRutas> lstProductos = null;
        string sentencia = "SELECT * FROM rutas";
        lstProductos = ConvertTableToList((DataTable)_objDatos.EjecutaAdaptador(null, null, sentencia, CommandType.Text, "Rutas"));
        string datos = JsonConvert.SerializeObject(lstProductos);
        return datos;
    }

    public dynamic SeleccionaDato() {
        List<clsRutas> lstProductos = null;
        string sentencia = "SELECT * FROM rutas WHERE id = @id";

        SqlParameter[] parametros ={ new SqlParameter ("id", SqlDbType.Int) };
        object[] valores = { Id };

        lstProductos = ConvertTableToList((DataTable)_objDatos.EjecutaAdaptador(parametros, valores, sentencia, CommandType.Text, "Rutas"));
        string datos = JsonConvert.SerializeObject(lstProductos);
        return datos;

    }
    public dynamic InsertaDatos(){ return true; }
    public bool ActualizaDatos() { return true; }
    public bool EliminaDatos() { return true; }
    public bool Existe() { return true; }
}