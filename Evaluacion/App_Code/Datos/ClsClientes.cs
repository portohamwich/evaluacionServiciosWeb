using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de ClsClientes
/// </summary>
public class ClsClientes : ILogica
{

    #region PROPIEDADES
    private ClsNegociaSql _objDatos;

    public dynamic ObjDatos
    {
        set { _objDatos = value; }
    }

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Paterno { get; set; }
    public string Materno { get; set; }
    public string Direccion { get; set; }
    public string Ciudad { get; set; }
    public string Estado { get; set; }
    public int CP { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }
    public string Usuario { get; set; }
    public string Password { get; set; }

    #endregion

    #region CONSTRUCTORES
    public ClsClientes()
    {
        string cadenaCnn = System.Configuration.ConfigurationManager.ConnectionStrings["CadenaSqlSrv"].ConnectionString;
        _objDatos = new ClsNegociaSql(cadenaCnn);
    }

    #endregion

    #region MÉTODOS GENERALES PARA EL MANEJO DE CLIENTES
    public List<ClsClientes> ConvertTableToList(DataTable dttD)
    {
        List<ClsClientes> lstClientes = new List<ClsClientes>();
        foreach (DataRow registro in dttD.Rows)
        {
            ClsClientes objCliente = new ClsClientes();
            objCliente.Id = int.Parse(registro["id"].ToString());
            objCliente.Nombre = registro["nombre"].ToString();
            objCliente.Paterno = registro["paterno"].ToString();
            objCliente.Materno = registro["materno"].ToString();
            objCliente.Direccion = registro["direccion"].ToString();
            objCliente.Ciudad = registro["ciudad"].ToString();
            objCliente.Estado = registro["estado"].ToString();
            objCliente.CP = int.Parse(registro["cp"].ToString());
            objCliente.Telefono = registro["telefono"].ToString();
            objCliente.Correo = registro["correo"].ToString();
            objCliente.Usuario = registro["usuario"].ToString();
            lstClientes.Add(objCliente);
        }
        return lstClientes;
    }
    #endregion

    #region MÉTODOS DE ACCESO A DATOS
    public string SeleccionaDatosJSON()
    {
        List<ClsClientes> lstClientes = null;
        string sentencia = "SELECT * FROM clientes";
        lstClientes = ConvertTableToList((DataTable)_objDatos.EjecutaAdaptador(null, null, sentencia, CommandType.Text, "Clientes"));
        string datos = JsonConvert.SerializeObject(lstClientes);
        return datos;
    }

    public dynamic SeleccionaDato()
    {
        DataTable dttDatos = new DataTable();
        string sentencia = "SELECT * FROM clientes WHERE id = @id";
        SqlParameter[] parametros = {
        new SqlParameter ("id", SqlDbType.Int,50)
        };
        object[] valores = { Id };
        dttDatos = (DataTable)_objDatos.EjecutaAdaptador(parametros, valores, sentencia, CommandType.Text, "Cliente");
        return dttDatos;
    }

    public DataTable Cliente()
    {
        DataTable dttDatos = new DataTable();
        string sentencia = "SELECT id, usuario, nombre FROM clientes WHERE usuario = @usuario and password = @password";
        SqlParameter[] parametros = {
            new SqlParameter ("usuario", SqlDbType.NVarChar,50)
            ,new SqlParameter ("password",SqlDbType.NVarChar,50)
            };
        object[] valores = { Usuario, Password };
        dttDatos = (DataTable)_objDatos.EjecutaAdaptador(parametros, valores, sentencia, CommandType.Text, "Cliente");
        return dttDatos;
    }

    public bool Existe()
    {
        bool valido = false;
        DataTable dttDatos = new DataTable();
        string sentencia = "SELECT id FROM clientes WHERE usuario = @usuario and password = @password";
        SqlParameter[] parametros ={
        new SqlParameter ("@usuario", SqlDbType.NVarChar,50),
        new SqlParameter ("@password", SqlDbType.NVarChar,50)
        };
        object[] valores = { Usuario, Password };
        dttDatos = (DataTable)_objDatos.EjecutaAdaptador(parametros, valores, sentencia, CommandType.Text, "ExisteCliente");
        if (dttDatos != null)
            if (dttDatos.Rows.Count > 0)
            {
                valido = true;
            }
        return valido;
    }

    public bool InsertaDatos()
    {
        bool valido = false;

        string comando = "INSERT INTO clientes (nombre, paterno, materno, direccion, ciudad, estado, cp, telefono, correo, usuario, password) " +
            "VALUES (@nombre,@paterno,@materno,@direccion,@ciudad,@estado,@cp,@telefono,@correo,@usuario,@password)";
        SqlParameter[] parametros = {
             new SqlParameter("nombre",SqlDbType.NVarChar,50)
             ,new SqlParameter("paterno",SqlDbType.NVarChar,50)
             ,new SqlParameter("materno",SqlDbType.NVarChar,50)
             ,new SqlParameter("direccion",SqlDbType.NVarChar,50)
             ,new SqlParameter("ciudad",SqlDbType.NVarChar,50)
             ,new SqlParameter("estado",SqlDbType.NVarChar,50)
             ,new SqlParameter("cp",SqlDbType.Int,50)
             ,new SqlParameter("telefono",SqlDbType.NVarChar,50)
             ,new SqlParameter("correo",SqlDbType.NVarChar,50)
             ,new SqlParameter("usuario",SqlDbType.NVarChar,50)
             ,new SqlParameter("password",SqlDbType.NVarChar,50)
                                  };
        Object[] valores = { Nombre, Paterno, Materno, Direccion, Ciudad, Estado, CP, Telefono, Correo, Usuario, Password };
        int n = _objDatos.EjecutaComando(parametros, valores, comando, CommandType.Text);
        if (n > 0)
            valido = true;

        return valido;
    }

    public bool ActualizaDatos()
    {
        bool valido = false;
        string comando = "UPDATE clientes SET nombre = @nombre, paterno = @paterno, materno = @materno, direccion = @direccion, ciudad = @ciudad, " +
            "estado = @estado, cp = @cp, telefono = @telefono, correo = @correo WHERE id = @id";
        SqlParameter[] parametros = {
             new SqlParameter("nombre",SqlDbType.NVarChar,50)
             ,new SqlParameter("paterno",SqlDbType.NVarChar,50)
             ,new SqlParameter("materno",SqlDbType.NVarChar,50)
             ,new SqlParameter("direccion",SqlDbType.NVarChar,50)
             ,new SqlParameter("ciudad",SqlDbType.NVarChar,50)
             ,new SqlParameter("estado",SqlDbType.NVarChar,50)
             ,new SqlParameter("cp",SqlDbType.Int,50)
             ,new SqlParameter("telefono",SqlDbType.NVarChar,50)
             ,new SqlParameter("correo",SqlDbType.NVarChar,50)
                                  };
        Object[] valores = { Nombre, Paterno, Materno, Direccion, Ciudad, Estado, CP, Telefono, Correo };
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