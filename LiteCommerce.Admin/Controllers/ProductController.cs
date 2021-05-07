using LiteCommerce.BusinessLayers;
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
        public ActionResult List(int category = 0, int supplier = 0, string searchValue = "", int page = 1)
        {
            try
            {
                int rowCount = 0;
                int pageSize = 5;
                var listOfProduct = ProductService.List(page, pageSize, category, supplier, searchValue, out rowCount);

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
    }
}