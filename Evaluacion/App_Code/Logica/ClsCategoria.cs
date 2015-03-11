using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ClsCategoria
/// </summary>
public class ClsCategoria : ILogica
{
	 #region PROPIEDADES
    private ClsNegociaSql _objDatos;

    public dynamic ObjDatos
    {
        set { _objDatos = value; }
    }

    public int Id { get; set; }
    public string Categoria { get; set; }
    #endregion

    #region CONSTRUCTORES
    public ClsCategoria()
    {
        string cadenaCnn = System.Configuration.ConfigurationManager.ConnectionStrings["CadenaSqlSrv"].ConnectionString;
        _objDatos = new ClsNegociaSql(cadenaCnn);
    }
    #endregion

    #region MÉTODOS GENERALES PARA EL MANEJO DE CLIENTES
    public List<ClsCategoria> ConvertTableToList(DataTable dttD)
    {
        List<ClsCategoria> lstCategorias = new List<ClsCategoria>();
        foreach (DataRow registro in dttD.Rows)
        {
            ClsCategoria objCat = new ClsCategoria();
            objCat.Id = int.Parse(registro["id"].ToString());
            objCat.Categoria = registro["categoria"].ToString();
            lstCategorias.Add(objCat);
        }
        return lstCategorias;
    }
    #endregion

    #region MÉTODOS DE ACCESO A DATOS
    public string SeleccionaDatosJSON()
    {
        List<ClsCategoria> lstCategorias = null;
        string sentencia = "SELECT 0 as id, 'Todos' as categoria UNION SELECT id, categoria FROM categoria";
        lstCategorias = ConvertTableToList((DataTable)_objDatos.EjecutaAdaptador(null, null, sentencia, CommandType.Text, "Categorias"));
        string datos = JsonConvert.SerializeObject(lstCategorias);
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