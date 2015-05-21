using System.Web.Mvc;
using POSCreditRepayments.Models;
using POSCreditRepayments.Web.Infrastructure.Mappings;

namespace POSCreditRepayments.Web.ViewModels.Products
{
    public class AllProductsViewModel : IMapFrom<Product>
    {
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }
    }
}