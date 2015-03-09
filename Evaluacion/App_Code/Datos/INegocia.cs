using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Interface para generar acciones de la base de datos, abric onexion, ejecutar comando, cerrar conexion
/// </summary>
interface INegocia
{
    string MensajeError { get; }
    object EjecutaAdaptador(IDbDataParameter[] parametros, object[] valores, string sentencia, object tipoEjecucion, string nombreTabla);
    int EjecutaComando(IDbDataParameter[] parametros, object[] valores, string sentencia, object tipoEjecucion);
    int EjecutaComandoTrans(List<IDbDataParameter[]> parametros, List<object[]> valores, List<string> sentencia, object tipoEjecucion);

}