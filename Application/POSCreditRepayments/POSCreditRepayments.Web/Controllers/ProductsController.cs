using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using PagedList;
using POSCreditRepayments.Data;
using POSCreditRepayments.Web.ViewModels.Products;

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
            var allProducts = this.Data.Products
                                  .All()
                                  .Project().To<AllProductsViewModel>()
                                  .OrderBy(u => u.Name);

            var pageNumber = page ?? 1;
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
                              .To<ProductDetailsViewModel>()
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
                                     .Select(u => new { Id = u.ProductId, Name = u.Name, ImageUrl = u.ImageUrl })
                                     .ToList();

            return this.Json(suggestedUsers, JsonRequestBehavior.AllowGet);
        }
    }
}