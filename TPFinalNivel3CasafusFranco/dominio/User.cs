﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{

    public class User
    {

        public int id { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string Imagen { get; set; }

        public bool TipoUsuario { get; set; }
    }
}
