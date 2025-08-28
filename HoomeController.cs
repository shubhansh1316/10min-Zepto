using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mypro.Models;

namespace mypro.Controllers
{
    public class HoomeController : Controller
    {
        // GET: Hoome
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }

        public ViewResult Contact()
        {
            return View();
        }

      
        [HttpPost]
        public ActionResult Contact(string name,long mobno,string email,string message)
        {
            DBManager dm = new DBManager();
            int x = dm.ExecuteInsertUpdateDelete("insert into tbl_contact values('" + name + "','" + mobno + "','" + email + "','" + message + "')");
          if (x > 0)
                Response.Write("<script> alert('thanks for contacting us..')</script>");
          else
                Response.Write("<script> alert('Data not have us..')</script>");
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }
 
        public ActionResult  adminlogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult adminlogin(string adminid,string password)
        {
            string query="select * from tabl_adminlogin where adminid= '" + adminid + "' and password= '" + password + "'  ";
            DBManager db = new DBManager();
            DataTable dt = db.ExecuteSelect(query);
            if (dt.Rows.Count > 0)
            {
                Session["admin"]=adminid;
                return RedirectToAction("index", "admin");
            }
            else
            {
                return Content("<script>alert('Id OR Password is invaild');location.href='/hoome/adminlogin'</script>");

            }
            return View();
        }
    }
}