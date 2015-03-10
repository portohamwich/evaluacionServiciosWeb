using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de ClsTransaccion
/// </summary>
public class ClsTransaccion
{
    #region PROPIEDADES
    private ClsNegociaSql _objDatos;

    public dynamic ObjDatos
    {
        set { _objDatos = value; }
    }

    public int IdVenta { get; set; }
    public string Tarjeta { get; set; }
    public string nombre { get; set; }
    public decimal Cantidad { get; set; }
    public char Status { get; set; }
    public int folio { get; set; }
    public DateTime Fecha { get; set; }
    public int Codigo { get; set; }
    public string FechaExp { get; set; }
    #endregion

    #region CONSTRUCTORES
    public ClsTransaccion()
    {
        string cadenaCnn = System.Configuration.ConfigurationManager.ConnectionStrings["CadenaSqlSrv"].ConnectionString;
        _objDatos = new ClsNegociaSql(cadenaCnn);
    }
    #endregion

    #region MÉTODOS DE ACCESO A DATOS
    public string SeleccionaDatos()
    {
        return "";
    }

    public DataTable SeleccionaDato()
    {
        DataTable dttDatos = new DataTable();
        string sentencia = "SELECT * FROM transaccion WHERE folio = @folio and status = @status";
        SqlParameter[] parametros = {
        new SqlParameter ("folio", SqlDbType.Int,50)
        ,new SqlParameter("status",SqlDbType.Char,1)
        };
        object[] valores = { folio, Status };
        dttDatos = (DataTable)_objDatos.EjecutaAdaptador(parametros, valores, sentencia, CommandType.Text, "Transaccion");
        return dttDatos;
    }

    public DataTable Cliente()
    {
        return null;
    }

    public bool Existe()
    {
        return false;
    }

    public bool InsertaDatos()
    {
        bool valido = false;

        string comando = "INSERT INTO transaccion (idventa, tarjeta, nombre, cantidad, folio, fecha) " +
            "VALUES (@idventa,@tarjeta,@nombre,@cantidad,@folio,@fecha)";
        SqlParameter[] parametros = {
             new SqlParameter("idventa",SqlDbType.Int,50)
             ,new SqlParameter("tarjeta",SqlDbType.NVarChar,16)
             ,new SqlParameter("nombre",SqlDbType.NVarChar,50)
             ,new SqlParameter("cantidad",SqlDbType.Decimal,50)
             ,new SqlParameter("folio",SqlDbType.Int,50)
             ,new SqlParameter("fecha",SqlDbType.DateTime,50)
                                  };
        Object[] valores = { IdVenta, Tarjeta, nombre, Cantidad, folio, Fecha };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;

        return valido;
    }

    public bool ActualizaDatos()
    {
        bool valido = false;

        string comando = "UPDATE transaccion SET status = @status WHERE folio = @folio";
        SqlParameter[] parametros = {
             new SqlParameter("folio",SqlDbType.Int,50)
             ,new SqlParameter("status",SqlDbType.Char,1)
                              };
        Object[] valores = { folio, Status };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;

        return valido;
    }

    public bool EliminaDatos()
    {
        return false;
    }
    #endregion
}