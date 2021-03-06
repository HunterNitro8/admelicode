﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class UnidadMedida
    {
        public int idUnidadMedida { get; set; }
        public string nombreUnidad { get; set; }
        public string simbolo { get; set; }
        public int estado { get; set; }
        public string tieneRegistros { get; set; }

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
}
