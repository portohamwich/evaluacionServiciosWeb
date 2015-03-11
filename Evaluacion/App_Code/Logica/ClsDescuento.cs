using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ClsDescuento
/// </summary>
public class ClsDescuento
{
    #region PROPIEDADES
    private ClsNegociaSql _objDatos;

    public dynamic ObjDatos
    {
        set { _objDatos = value; }
    }

    public int Id { get; set; }
    public string NombreCorto { get; set; }
    public decimal Descuento { get; set; }
    public string Codigo { get; set; }
    #endregion

    #region CONSTRUCTORES
    public ClsDescuento()
    {
        string cadenaCnn = System.Configuration.ConfigurationManager.ConnectionStrings["CadenaSqlSrv"].ConnectionString;
        _objDatos = new ClsNegociaSql(cadenaCnn);
    }
    #endregion

    #region MÉTODOS GENERALES PARA EL MANEJO DE CLIENTES
    public List<ClsDescuento> ConvertTableToList(DataTable dttD)
    {
        List<ClsDescuento> lstDescuentos = new List<ClsDescuento>();
        foreach (DataRow registro in dttD.Rows)
        {
            ClsDescuento objDescuento = new ClsDescuento();
            objDescuento.Id = int.Parse(registro["id"].ToString());
            objDescuento.NombreCorto = registro["nombrecorto"].ToString();
            objDescuento.Descuento = decimal.Parse(registro["descuento"].ToString());
            objDescuento.Codigo = registro["codigo"].ToString();
            lstDescuentos.Add(objDescuento);
        }
        return lstDescuentos;
    }
    #endregion

    #region MÉTODOS DE ACCESO A DATOS
    public string SeleccionaDatosJSON()
    {
        List<ClsDescuento> lstDescuentos = null;
        string sentencia = "SELECT 0 as id, 'NO APLICA' as nombrecorto, 0.00 as descuento, 'C0' as codigo UNION SELECT id, nombrecorto, descuento, codigo FROM descuentos";
        lstDescuentos = ConvertTableToList((DataTable)_objDatos.EjecutaAdaptador(null, null, sentencia, CommandType.Text, "Descuentos"));
        string datos = JsonConvert.SerializeObject(lstDescuentos);
        return datos;
    }

    public dynamic SeleccionaDato() { return null; }
    public DataTable Cliente() { return null; }
    public bool Existe() { return false; }
    public dynamic InsertaDatos() { return false; }
    public bool ActualizaDatos() { return false; }
    public bool EliminaDatos() { return false; }
    #endregion

}