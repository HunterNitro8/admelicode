﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Proveedor
    {
        public int idProveedor { get; set; }
        public string ruc { get; set; }
        public string razonSocial { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string actividadPrincipal { get; set; }
        public string tipoProveedor { get; set; }
        public string direccion { get; set; }
        public int estado { get; set; }
        public int idUbicacionGeografica { get; set; }
        public string NroCompras { get; set; }

        private string estadoString;
        public string EstadoString
        {
            get
            {
                if (estado == 1) { return "Activo"; }
                else { return "Anulado"; }
            }
            set
            {
                estadoString = value;
            }
        }
    }

   public  class Ruc
    {
        public string nroDocumento { get; set; }


    }
}
