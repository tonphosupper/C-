using LiteCommerce.BusinessLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult List(int CategoryID = 0, int SupplierID = 0, string searchValue = "", int page = 1)
        {
            try
            {
                int rowCount = 0;
                int pageSize = 5;
                var listOfProduct = ProductService.List(page, pageSize, CategoryID, SupplierID, searchValue, out rowCount);

                var model = new Models.ProductPaginationQueryResult()
                {
                    Page = page,
                    PageSize = pageSize,
                    SearchValue = searchValue,
                    RowCount = rowCount,
                    Data = listOfProduct
                };
                return View(model);
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Thay đổi thông tin hang hoa";

            var model = ProductService.Get(id);
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
            ViewBag.Title = "Thêm thông tin hang hoa";

            Product model = new Product()
            {
                ProductID = 0
            };

            return View("Edit", model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            ViewBag.Title = "Xóa hang hoa";

            if (Request.HttpMethod == "GET")
            {
                var model = ProductService.Get(id);
                if (model == null)
                    RedirectToAction("Index");
                return View(model);
            }
            else
            {
                ProductService.Delete(id);
                return RedirectToAction("Index");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Save(Product data)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(data.ProductName))
                    ModelState.AddModelError("ProductName", "Vui long nhap ten hàng hóa !");
                if (string.IsNullOrWhiteSpace(data.Photo))
                    ModelState.AddModelError("Photo", "Ban chua thêm ảnh !");
                if (string.IsNullOrWhiteSpace(Convert.ToString(data.Price)))
                    ModelState.AddModelError("Price", "Ban chua nhập giá bán !");
                if (string.IsNullOrWhiteSpace(data.Unit))
                    ModelState.AddModelError("Unit", "Ban chua nhập đơn vị tính !");
                if (string.IsNullOrWhiteSpace(Convert.ToString(data.CategoryID)))
                    ModelState.AddModelError("CategoryID", "Ban chua nhập loại hàng !");
                if (string.IsNullOrWhiteSpace(Convert.ToString(data.SupplierID)))
                    ModelState.AddModelError("SupplierID", "Ban chua nhập nhà cung cấp !");

                if (!ModelState.IsValid)
                {
                    if (data.ProductID == 0)
                        ViewBag.Title = "Bo sung hàng hóa";
                    else
                        ViewBag.Title = "Thay doi thong tin hàng hóa";
                    return View("Edit", data);
                }

                if (data.ProductID == 0)
                    ProductService.Add(data);
                else
                    ProductService.Update(data);

                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Oops! Trang nay khong ton tai :)");
            }
        }
    }
}