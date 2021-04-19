using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiteCommerce.DataLayers;
using LiteCommerce.DataLayers.SQLServer;
using LiteCommerce.DomainModels;

namespace LiteCommerce.Admin.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager
                .ConnectionStrings["LiteCommerceDB"]
                .ConnectionString;
                 
            ICityDAL dal = new CityDAL(connectionString);
            var data = dal.List();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PoniCity(string countryName)
        {
            string connectionString = ConfigurationManager
                .ConnectionStrings["LiteCommerceDB"]
                .ConnectionString;

            ICityDAL dal = new CityDAL(connectionString);
            var data = dal.List(countryName);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Panigation(int page, int pageSize, string searchValue)
        {
            string connectionString = ConfigurationManager
               .ConnectionStrings["LiteCommerceDB"]
               .ConnectionString;

            ISupplierDAL dal = new SupplierDAL(connectionString);
            var data = dal.List(page, pageSize, searchValue);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        //TestURL: http://http://localhost:52297/Test/Panigation?page=2&pageSize=10&searchValue=
    }
}