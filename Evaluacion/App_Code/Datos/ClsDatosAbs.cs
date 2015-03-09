using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public abstract class ClsDatosAbs
{
    #region PROPIEDADES
    protected string _servidor;
    protected string _bd;
    protected string _usuario;
    protected string _password;
    protected string _cadenaCnn;
    protected string _mensaje;
    protected IDbConnection _conexion;

    public abstract string Servidor { get; set; }
    public abstract string BD { get; set; }
    public abstract string Usuario { get; set; }
    public abstract string Password { get; set; }
    public abstract string CadenaCnn { get; }
    public abstract string Mensaje { get; }
    public abstract IDbConnection Conexion { get; }
    #endregion

    #region Métodos de acceso a db
    public abstract void GeneraCadenaCnn();
    public abstract bool AbreConexion();
    public abstract bool CierraConexion();
    #endregion

}