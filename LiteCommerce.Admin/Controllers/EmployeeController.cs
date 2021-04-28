using LiteCommerce.BusinessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            int rowCount = 0;
            int pageSize = 3;
            var listEmployees = DataService.ListEmployees(page, pageSize, searchValue, out rowCount);

            var model = new Models.EmployeePaginationQueryResult()
            {
                Page = page,
                PageSize = pageSize,
                SearchValue = searchValue,
                RowCount = rowCount,
                Data = listEmployees
            };
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(string id)
        {
            ViewBag.Title = "Thay đổi thông tin nhân viên";
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            ViewBag.Title = "Thêm thông tin nhân viên";
            return View("Edit");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(string id)
        {
            ViewBag.Title = "Xóa nhân viên";
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