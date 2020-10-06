using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WebApplication2.Models;
using System.Web.WebPages;

namespace WebApplication2.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        public ActionResult Index()
        {
            cn.Open();
            SqlDataAdapter cmd = new SqlDataAdapter("sp_listEMPLEADO", cn);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.SelectCommand.ExecuteReader();
            Empleado emp = null;
            List<Empleado> lista = new List<Empleado>();
            while (dr.Read()) 
            {
                emp = new Empleado()
                {
                    IdEmpleado = dr[0].ToString(),
                    DocIdentidad = dr[1].ToString(),
                    NomEmpleado = dr[2].ToString(),
                    CorEmpleado = dr[3].ToString(),
                    TipoDoc = Int32.Parse(dr[4].ToString()),
                    DirEmpleado = dr[5].ToString(),
                    FechaNacimiento = DateTime.Parse(dr[6].ToString()),
                    EstEmpleado = dr[7].ToString(),
                    FechaIniContrato = DateTime.Parse(dr[8].ToString()),
                    FechaFinContrato = DateTime.Parse(dr[9].ToString())
                };
                lista.Add(emp);
            }
            return View(lista);
        }


        public ActionResult Details()
        {
            
            cn.Open();
            SqlDataAdapter cmd = new SqlDataAdapter("SELECT * FROM EMPLEADO_ASIGNACION_V", cn);
            cmd.SelectCommand.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.SelectCommand.ExecuteReader();
            Empleado emp = null;
            List<Asignacion> lista = new List<Asignacion>();
            if (dr.Read())
            {
                emp = new Empleado()
                {
                    IdEmpleado = dr[0].ToString(),
                    DocIdentidad = dr[1].ToString(),
                    NomEmpleado = dr[2].ToString(),
                    CorEmpleado = dr[3].ToString(),
                    TipoDoc = Int32.Parse(dr[4].ToString()),
                    DirEmpleado = dr[5].ToString(),
                    FechaNacimiento = DateTime.Parse(dr[6].ToString()),

                    FechaIniContrato = DateTime.Parse(dr[7].ToString()),
                    FechaFinContrato = DateTime.Parse(dr[8].ToString()),
                    EstEmpleado = dr[9].ToString()
                };

                Asignacion a = new Asignacion() 
                {
                    CodAsginacion = Int32.Parse(dr[10].ToString()),
                    NomAsignacion = dr[11].ToString(),
                    IniAsignacion = DateTime.Parse(dr[12].ToString()),
                    FinAsignacion = DateTime.Parse(dr[13].ToString()),
                    EstAsignacion = dr[14].ToString()
                };
                lista.Add(a);

                emp.Asignaciones = lista;
            }
            return View(emp);
        }

    }
}