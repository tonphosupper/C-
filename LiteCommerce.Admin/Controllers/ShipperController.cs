using LiteCommerce.BusinessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    public class ShipperController : Controller
    {
        // GET: Shipper
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            int rowCount = 0;
            int pageSize = 3;
            var listShippers = DataService.ListShippers(page, pageSize, searchValue, out rowCount);

            var model = new Models.ShipperPaginationQueryResult()
            {
                Page = page,
                PageSize = pageSize,
                SearchValue = searchValue,
                RowCount = rowCount,
                Data = listShippers
            };
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Thay đổi thông tin nhà vận chuyển";
            var model = DataService.GetShipper(id);
            if (model == null)
                RedirectToAction("Index");
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            ViewBag.Title = "Thêm thông tin nhà vận chuyển";
            return View("Edit");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(string id)
        {
            ViewBag.Title = "Xóa nhà vận chuyển";
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Save()
        {
            return RedirectToAction("Index");
        }
    }
}