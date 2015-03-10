using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

interface ILogica
{
    dynamic ObjDatos { set; }
    string SeleccionaDatosJSON();
    dynamic SeleccionaDato();
    bool Existe();
    dynamic InsertaDatos();
    bool ActualizaDatos();
    bool EliminaDatos();
}