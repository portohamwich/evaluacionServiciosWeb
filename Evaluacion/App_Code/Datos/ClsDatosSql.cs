using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Implementación de la clase abstracta
/// </summary>
public class ClsDatosSql : ClsDatosAbs
{
    #region CONSTRUCTORES
    //Constructor por default, inicializa el tipo de autenticacíón a Sql Server
    public ClsDatosSql()
    {
        this.tipo = 1;
    }
    //Asigna el tipo de Autenticación, el cuál se recibe por pase de parámetros
    public ClsDatosSql(int tipo)
    {
        this.tipo = tipo;

    }
    //Asigna la cadena de conexión directamente
    public ClsDatosSql(string cadena)
    {
        this._cadenaCnn = cadena;

    }
    #endregion

    #region PROPIEDADES
    private int tipo = 0;

    public int Tipo
    {
        get { return tipo; }
    }

    public override string Servidor
    {
        get { return _servidor; }
        set { _servidor = value; }
    }

    public override string BD
    {
        get { return _bd; }
        set { _bd = value; }
    }

    public override string Usuario
    {
        get { return _usuario; }
        set { _usuario = value; }
    }

    public override string Password
    {
        get { return _password; }
        set { _password = value; }
    }

    public override string CadenaCnn
    {
        get { return _cadenaCnn; }
    }

    public override string Mensaje
    {
        get { return _mensaje; }
    }

    //Si la conexión no ha sido abierta, ejecuta el método de AbreConexión
    //La conexión es de tipo object, ya que toma la forma de acuerdo al tipo de manejador que se utiliza
    public override IDbConnection Conexion
    {
        get
        {
            if (_conexion == null)

                AbreConexion();
            else
                if (((SqlConnection)_conexion).State != System.Data.ConnectionState.Open)
                    AbreConexion();
            return _conexion;
        }
    }
    #endregion

    #region MANEJO DE ACCESO A DATOS
    public override void GeneraCadenaCnn()
    {
        switch (tipo)
        {
            case 1:

                if (_servidor != "" && _bd != "" && _usuario != "" && _password != "")
                {
                    _cadenaCnn = String.Format("Data Source ={0}; Initial Catalog={1}; User ID={2}; Password = {3}", _servidor, _bd, _usuario, _password);
                }
                else
                    _cadenaCnn = "";
                break;
            case 2: //Autenticación Windows

                if (_servidor != "" && _bd != "")
                {
                    _cadenaCnn = String.Format("Data Source ={0}; Initial Catalog={1}; Integrated Security=SSPI", _servidor, _bd);
                }
                else
                    _cadenaCnn = "";
                break;
            default:
                _cadenaCnn = "";
                break;
        }

    }

    /* Abre la conexión
     * Retonra: False: Si hubo error en la conexión, y el objeto es nulo
     * True: Si la conexión se abrió con éxito, y asigna al objeto la conexión a la bd
     * Requiere que la CadenaCnn se genere de manera adecuada, para que sea posible abrir la conexión
     */
    public override bool AbreConexion()
    {
        bool valido = false;
        try
        {
            _conexion = new SqlConnection();
            _conexion.ConnectionString = CadenaCnn;
            _conexion.Open();
            valido = true;
            _mensaje = "Conexión Abierta";
        }
        catch (Exception varEx)
        {
            _mensaje = varEx.Message;
            valido = false;
            _conexion = null;
        }

        return valido;
    }

    /*Cierra la conexión, solamente si existe el objeto y está abierta la conexión
     * Retorna: False: si no se pudo cerrar la conexión
     * True: Si la conexión fue cerrada 
     */
    public override bool CierraConexion()
    {
        bool valido = false;
        try
        {
            if (_conexion != null)
            {
                SqlConnection conexionBD = (SqlConnection)_conexion;
                if (conexionBD.State == System.Data.ConnectionState.Open)
                    conexionBD.Close();

                else
                    throw new Exception("Conexión No está abierta");
                _conexion = conexionBD;
                valido = true;

            }
            else
            {
                throw new Exception("Conexión No Existe");
            }
        }
        catch (Exception varEx)
        {
            _mensaje = varEx.Message;
            valido = false;
        }
        return valido;
    }
    #endregion
}