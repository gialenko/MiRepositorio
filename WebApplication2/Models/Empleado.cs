using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Empleado
    {
        [DisplayName("ID")]        
        public string IdEmpleado { get; set; }
        [DisplayName("Doc. Identidad")]
        public string DocIdentidad { get; set; }
        [DisplayName("Nombre")]
        public string NomEmpleado { get; set; }
        public string CorEmpleado { get; set; }
        public Int32 TipoDoc { get; set; }
        public string DirEmpleado { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [DisplayName("Estado")]
        public string EstEmpleado { get; set; }
        public DateTime FechaIniContrato { get; set; }
        public DateTime FechaFinContrato { get; set; }
        public List<Asignacion> Asignaciones { get; set; } 
    }
}