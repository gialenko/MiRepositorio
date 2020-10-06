using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Usuario
    {
        public string IdUsuario { get; set; }
        public string Email { get; set; }
        public string PswdUsuario { get; set; }
        public int TipoUsuario { get; set; }
        public int EstadoUsuario { get; set; }
    }
}