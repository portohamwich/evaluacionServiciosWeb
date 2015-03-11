using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ClsConsulta
/// </summary>
public class ClsConsulta : ILogica
{
	#region CONSTRUCTOR

    public ClsConsulta()
        {
            string cadenaCnn = System.Configuration.ConfigurationManager.ConnectionStrings["CadenaSqlSrv"].ConnectionString;
            _objDatos = new ClsNegociaSql(cadenaCnn);
        }

    #endregion

    #region PROPIEDADES
    private ClsNegociaSql _objDatos;

    public dynamic ObjDatos
    {
        set { _objDatos = value; }
    }

    public string _fechafin { get; set; }
    public string _fechaini { get; set; }
    public string _categoria { get; set; }
    public string _descuento { get; set; }
    public string _ruta { get; set; }
    public string _tarjeta { get; set; }

    public string nombre { get; set; }
    public string origen { get; set; }
    public string destino { get; set; }
    public string costo { get; set; }
    public string marca { get; set; }
    public string categoria { get; set; }
    public string nombrecorto { get; set; }
    public string tarjeta { get; set; }
    #endregion

    #region MÉTODOS GENERALES PARA EL MANEJO DE CLIENTES
    public List<ClsConsulta> ConvertTableToList(DataTable dttD)
    {
        List<ClsConsulta> lstConsulta = new List<ClsConsulta>();
        foreach (DataRow registro in dttD.Rows)
        {
            ClsConsulta objConsulta = new ClsConsulta();
            objConsulta.nombre = registro["nombre"].ToString();
            objConsulta.origen = registro["origen"].ToString();
            objConsulta.destino = registro["destino"].ToString();
            objConsulta.costo = registro["costo"].ToString();
            objConsulta.marca = registro["marca"].ToString();
            objConsulta.categoria = registro["categoria"].ToString();
            objConsulta.nombrecorto = registro["nombrecorto"].ToString();
            objConsulta.tarjeta = registro["tarjeta"].ToString();
            lstConsulta.Add(objConsulta);
        }
        return lstConsulta;
    }
    #endregion

    #region MÉTODOS DE ACCESO A DATOS
    public string SeleccionaDatosJSON()
    {
        List<ClsConsulta> lstConsulta = null;
            
        string sentencia = "exec consulta @fechaini, @fechafin, @categoria, @descuento, @ruta, @tarjeta";
        SqlParameter[] parametros = {
            new SqlParameter ("fechaini", SqlDbType.NVarChar,50)
            ,new SqlParameter ("fechafin",SqlDbType.NVarChar,50)
            ,new SqlParameter ("categoria",SqlDbType.NVarChar,50)
            ,new SqlParameter ("descuento",SqlDbType.NVarChar,50)
            ,new SqlParameter ("ruta",SqlDbType.NVarChar,50)
            ,new SqlParameter ("tarjeta",SqlDbType.NVarChar,16)
            };
        object[] valores = { _fechaini, _fechafin, _categoria, _descuento, _ruta, _tarjeta };
        lstConsulta = ConvertTableToList((DataTable)_objDatos.EjecutaAdaptador(parametros, valores, sentencia, CommandType.Text, "Consulta"));
        string datos = JsonConvert.SerializeObject(lstConsulta);
        return datos;
    }

    public dynamic SeleccionaDato() {return null;}
    public bool Existe() {return false;}
    public DataTable Cliente() {return null;}
    public dynamic InsertaDatos() {return null;}
    public bool ActualizaDatos() {return false;}
    public bool EliminaDatos() { return false; }
    #endregion
}