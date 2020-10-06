using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Asignacion
    {
        public int CodAsginacion { get; set; }
        public string NomAsignacion { get; set; }
        public DateTime IniAsignacion { get; set; }
        public DateTime FinAsignacion { get; set; }
        public string EstAsignacion { get; set; }
    }
}