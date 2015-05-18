using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
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

        public ActionResult AllProducts()
        {
            var products = this.Data.Products
                   .All()
                   .Project()
                   .To<AllProductsViewModel>()
                   .ToList();

            return this.View(products);
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
    }
}