using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using POSCreditRepayments.Data;
using POSCreditRepayments.Web.ViewModels.Products;
using PagedList;

namespace POSCreditRepayments.Web.Controllers
{
    public class ProductsController : BaseController
    {
        public ProductsController(IPOSCreditRepaymentsData data)
            : base(data)
        {
        }

        public ActionResult AllProducts(int? page)
        {
            // returns IQueryable<ITSystems> representing an unknown number of products
            var allProducts = this.Data.Products
                .All()
                .Project().To<AllProductsViewModel>()
                .OrderBy(u => u.Name);

            // if no page was specified in the querystring, default to the first page (1)
            var pageNumber = page ?? 1;

            // will only contain PageSize systems max because of the pageSize
            var onePageOfProducts = allProducts.ToPagedList(pageNumber, 4);

            return this.View(onePageOfProducts);
        }

        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            var article = this.Data.Products
                .All()
                .AsQueryable()
                .Where(x => x.ProductId == id)
                .Project()
                .To<AllProductsViewModel>()
                .FirstOrDefault();
            if (article == null)
            {
                return this.HttpNotFound();
            }

            return this.View(article);
        }

        [HttpGet]
        public ActionResult SearchForProduct(string query)
        {
            var suggestedUsers = this.Data.Products
                .All()
                .Select(u => new { Id = u.ProductId, Name = u.Name, ImageUrl = u.ImageUrl})
                .ToList();

            return this.Json(suggestedUsers, JsonRequestBehavior.AllowGet);
        }
    }
}