using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.WebPages;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string pswd)
        {
            if (email==null || pswd==null) 
            {
                email.IsEmpty();
                pswd.IsEmpty();
            }
           
            cn.Open();
            SqlDataAdapter cmd = new SqlDataAdapter("SP_BUSCAR_USUARIO",cn);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.SelectCommand.Parameters.AddWithValue("@EMAIL",email);
            cmd.SelectCommand.Parameters.AddWithValue("@PSWD", pswd);
            SqlDataReader dr = cmd.SelectCommand.ExecuteReader();
            if (dr.Read()==true) {
                return RedirectToAction("../Empleado/Index");
            }
            return View();
        }

    }
}