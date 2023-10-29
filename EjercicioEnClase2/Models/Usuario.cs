﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjercicioEnClase2.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public Boolean EsAdmin { get; set; }

    }
}