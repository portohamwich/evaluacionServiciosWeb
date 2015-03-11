using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for ClsVentas
/// </summary>
public class ClsVentas: ILogica
{
  
	
        #region CONSTRUCTOR
    
        public ClsVentas()
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


    private int _idventa;
    private int _idcliente;
    private int _idviaje;
    private int _cantidad;
    private decimal _costo;
    private decimal _total;
    private DateTime _fechaventa;
    private string _asiento;
    private int _iddescuento;

       
    public int Idcliente
    {
        get { return _idcliente; }
        set { _idcliente = value; }
    }

    public int Idviaje
    {
        get { return _idviaje; }
        set { _idviaje = value; }
    }
    public int Cantidad
    {
        get { return _cantidad; }
        set { _cantidad = value; }
    }
    public decimal Costo
    {
        get { return _costo; }
        set { _costo = value; }
    }
    public decimal Total
    {
        get { return _total; }
        set { _total = value; }
    }
    public DateTime Fechaventa
    {
        get { return _fechaventa; }
        set { _fechaventa = value; }
    }
    public string Asiento
    {
        get { return _asiento; }
        set { _asiento = value; }
    }
    public int Iddescuento
    {
        get { return _iddescuento; }
        set { _iddescuento = value; }
    }

    #endregion

    #region METODOS GENERALES PARA EL MANEJO DE ventas

    public void AsignaVentathis(DataRow registro)
    {
        int auxDato = 0;
        decimal auxDatoDec = 0;
        DateTime datofecha;

        if (!int.TryParse(registro["idcliente"].ToString(), out auxDato)) auxDato = 0;
        _idcliente = auxDato;
        if (!int.TryParse(registro["idviaje"].ToString(), out auxDato)) auxDato = 0;
        _idviaje = auxDato;
        if (!int.TryParse(registro["cantidad"].ToString(), out auxDato)) auxDato = 0;
        _cantidad = auxDato;
        if (!decimal.TryParse(registro["costo"].ToString(), out auxDatoDec)) auxDato = 0;
        _costo = auxDato;
        if (!decimal.TryParse(registro["total"].ToString(), out auxDatoDec)) auxDato = 0;
        _total= auxDato;
        if (!DateTime.TryParse(registro["fechaventa"].ToString(), out datofecha)) auxDato = 0;
        _total = auxDato;
        _asiento = registro["asiento"].ToString();
        if (!int.TryParse(registro["iddescuento"].ToString(), out auxDato)) auxDato = 0;
        _iddescuento = auxDato;
            }

    public ClsVentas AsignaVenta(DataRow registro)
    {
        ClsVentas objventa = new ClsVentas();
        int auxDato = 0;
        decimal auxDatoDec = 0;
        DateTime datofecha;
        if (!int.TryParse(registro["idcliente"].ToString(), out auxDato)) auxDato = 0;
        objventa.Idcliente = auxDato;
        if (!int.TryParse(registro["idviaje"].ToString(), out auxDato)) auxDato = 0;
        objventa.Idviaje = auxDato;
        if (!int.TryParse(registro["cantidad"].ToString(), out auxDato)) auxDato = 0;
        objventa.Cantidad = auxDato;
        if (!decimal.TryParse(registro["costo"].ToString(), out auxDatoDec)) auxDato = 0;
        objventa.Costo = auxDato; 
        if (!decimal.TryParse(registro["total"].ToString(), out auxDatoDec)) auxDato = 0;
        objventa.Total = auxDato;
        if (!DateTime.TryParse(registro["fechaventa"].ToString(), out datofecha)) auxDato = 0;
        objventa.Idviaje = auxDato;
        objventa.Asiento = registro["asiento"].ToString();

        return objventa;
    }


    public List<ClsVentas> ConvertTableToList(DataTable dttD)
    {
        
           List<ClsVentas> lstVentas = new List<ClsVentas>();
        foreach(DataRow registro in dttD.Rows)
        {
            ClsVentas objVenta = AsignaVenta(registro);
            lstVentas.Add(objVenta);
        }
        return lstVentas;
    }

    #endregion

    #region METODOS DE ACCESO A DATOS

   

    public string SeleccionaDatosJSON()
    {
        List<ClsVentas> lstVenta = null;
        string sentencia = "SELECT * from ventas";
        lstVenta = ConvertTableToList((DataTable)_objDatos.EjecutaAdaptador(null,null,sentencia,CommandType.Text,"Venta"));
        string datos = JsonConvert.SerializeObject(lstVenta);
        return datos;
    }

    public dynamic SeleccionaDato()
    {
        List<ClsVentas> lstVenta = null;
        string sentencia = "SELECT * from ventas WHERE ventaid = @id";
        SqlParameter[] parametros = { new SqlParameter("idventa", SqlDbType.Int) };
        Object[] valores = { _idventa };

        lstVenta = ConvertTableToList((DataTable)_objDatos.EjecutaAdaptador(parametros, valores, sentencia, CommandType.Text, "Venta"));
        string datos = JsonConvert.SerializeObject(lstVenta);
        return datos;
    }

    public dynamic insertaDatos()
    {
        string comando = "INSERT INTO ventas (idcliente,idviaje,cantidad,costo,total,fechaventa,asiento,iddescuento) "
                        + "VALUES (@idcliente,@idviaje,@cantidad,@costo,@total,GETDATE(),@asiento,@iddescuento); " +
                        "SELECT SCOPE_IDENTITY()";
        SqlParameter[] parametros = {
             new SqlParameter("idcliente",SqlDbType.Int)
             ,new SqlParameter("idviaje",SqlDbType.Int)             
             ,new SqlParameter("cantidad",SqlDbType.Int)
            , new SqlParameter("costo",SqlDbType.Decimal)
             ,new SqlParameter("total",SqlDbType.Decimal)
             ,new SqlParameter("asiento",SqlDbType.NVarChar,50)
             ,new SqlParameter("iddescuento",SqlDbType.Int)
        };

        

        Object[] valores = { _idcliente,_idviaje,_cantidad,_costo,_total,_asiento,_iddescuento};
        int n = _objDatos.EjecutaComandoEscalar(parametros, valores, comando, CommandType.Text);

        return n;
    }

   public bool PagoTarjeta()
    {
        bool valido = false;
        return valido;
    }

   public dynamic InsertaDatos() { return true; }
   public bool ActualizaDatos() { return true; }
   public bool EliminaDatos() { return true; }
   public bool Existe() { return true; }
   public DataTable Cliente() { return null; }
    #endregion

}