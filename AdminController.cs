using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using mypro.Models;

namespace mypro.Controllers
{
    public class AdminController : Controller
    {
        DBManager dBManager = new DBManager();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Category()
        {
            DBManager dBManager = new DBManager();
            DataTable dt=dBManager.ExecuteSelect("select * from tabl_category order by cid desc ");
            ViewBag.category=dt;
            return View();
        }


        [HttpPost]
        public ActionResult Category(string catname,HttpPostedFileBase caticon)
        {
            DBManager dBManager = new DBManager();
            if (catname != null && caticon != null)
            {
                string query = "insert into tabl_category values('" + catname + "','" + caticon.FileName + "')";
                int result = dBManager.ExecuteInsertUpdateDelete(query);
                if (result > 0)
                {
                    caticon.SaveAs(Server.MapPath("/content/caticon/") + caticon.FileName);
                    return Content("<script>alert('data added');location href='/admin/Category'</script>");
                }
                else
                {
                    return Content("<script>alert('data not added');location href='/admin/Category'</script>");
                }
            }
            else
         
            {
                return Content("<script>alert('fill all field properply');location href='/admin/Category'</script>");
            }
        
        }
        public ActionResult Subcategory()
        {
            DBManager dBManager = new DBManager();
            string query =" select * from tabl_category order by cname";
            DataTable dt = dBManager.ExecuteSelect(query);
            ViewBag.subcat = dt;

            return View();
        }
        public ActionResult Subcategory(int category,string subcatname,HttpPostedFileBase subcaticon)
        {
            string query = "insert into tabl_category values(" + category + ",'" + subcatname + "','" + subcaticon + "')";
            int result = dBManager.ExecuteInsertUpdateDelete(query);
            if (result > 0)
            {
                subcaticon.SaveAs(Server.MapPath("/content/subcatpic/") + subcaticon.FileName);
                return Content("<script>alert('data added');location href='/admin/subcategory'</script>");
            }
            else
            {
                return Content("<script>alert('data not added');location href='/admin/subcategory'</script>");
            }
            
        }
        public ActionResult Product()
        {
            string query = "select*from category order by cname";
            DataTable category = dBManager.ExecuteSelect(query);
            ViewBag.category = category;

            string command = "select * from tabl_subcategory order by subcat_name";
            DataTable subcat = dBManager.ExecuteSelect(command);
            ViewBag.subcat = subcat;

            string command = "select * from tabl_subcategory order by subcat_name";
            DataTable subcat = dBManager.ExecuteSelect(command);
            ViewBag.subcat = subcat;
            return View();
        }
        public ActionResult Product(int? pcat, int? psubcat, string pname, string pdesc, string pmodel, string psize, int psalerate,
          int pmrp, HttpPostedFileBase picon)
        {
            string query = "insert into tabl_product values(" + pcat + "," + psubcat + ",'" + pname + "','" + pdesc + "','" + pmodel + "'," + pmrp + "," + psalerate + ",'" + psize + "'," +
                "'" + picon.FileName + "','" + DateTime.Now.ToString("yyyy-MM-DD") + "')";
            int result = dBManager.ExecuteInsertUpdateDelete(query);
            if (result > 0)
            {
                picon.SaveAs(Server.MapPath("/content/Productpic/") + picon.FileName);
                return Content("<script>alert('data added'); location href='/admin/Product'</script>");
            }
            else

            {
                return Content("<script>alert('data not added'); location href='/admin/Product'</script>");
            }
            return View();
        }

        public ActionResult Productmanagement()
        {
           
            return View();
        }
        

        public ActionResult Usermanagement()
        {
            return View();
        }
        public ActionResult CustomerSupport()
        {
            return View();
        }
        public ActionResult Ordser()
        {
            return View();
        }
        public ActionResult ChangePaasword()
        {
            return View();
        }
    }
}
