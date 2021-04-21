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

            //ICityDAL dal = new CityDAL(connectionString);
            //var data = dal.List(countryName);

            //ISupplierDAL dal = new SupplierDAL(connectionString);
            //var data = dal.Get(1);

            ISupplierDAL dal = new SupplierDAL(connectionString);
            Supplier s = new Supplier()
            {
                SupplierName = "Ton That Pho",
                ContactName = "t1",
                Address = "t2",
                City = "t3",
                PostalCode = "t4",
                Country = "t5",
                Phone = "t6"
            };
            var data = dal.Add(s);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult delupsup(string countryName)
        {
            string connectionString = ConfigurationManager
                .ConnectionStrings["LiteCommerceDB"]
                .ConnectionString;
            ISupplierDAL dal = new SupplierDAL(connectionString);
            Supplier s = new Supplier()
            {
                SupplierName = "Ton That Pho",
                ContactName = "hahahaha",
                Address = "t2",
                City = "trong",
                PostalCode = "t4",
                Country = "t5",
                Phone = "t6"
            };
            var data = dal.Update(s);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult delupship(int id)
        {
            string connectionString = ConfigurationManager
                .ConnectionStrings["LiteCommerceDB"]
                .ConnectionString;
            IShipperDAL dal = new ShipperDAL(connectionString);
            Shipper s = new Shipper()
            {
                ShipperName = "KAKA",
                Phone = "03399"
            };
            var data = dal.Get(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Panigation(int page, int pageSize, string searchValue)
        {
            string connectionString = ConfigurationManager
               .ConnectionStrings["LiteCommerceDB"]
               .ConnectionString;

            IEmployeeDAL dal = new EmployeeDAL(connectionString);
            var data = dal.List(page, pageSize, searchValue);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        //TestURL: http://http://localhost:52297/Test/Panigation?page=2&pageSize=10&searchValue=
    }
}