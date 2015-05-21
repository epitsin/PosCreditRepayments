using System.Web.Mvc;
using POSCreditRepayments.Models;
using POSCreditRepayments.Web.Infrastructure.Mappings;

namespace POSCreditRepayments.Web.ViewModels.Products
{
    public class ProductDetailsViewModel : IMapFrom<Product>
    {
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }
    }
}