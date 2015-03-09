using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

interface ILogica
{
    dynamic ObjDatos { set; }
    string SeleccionaDatosJSON();
    dynamic SeleccionaDato();
    bool InsertaDatos();
    bool ActualizaDatos();
    bool EliminaDatos();
}