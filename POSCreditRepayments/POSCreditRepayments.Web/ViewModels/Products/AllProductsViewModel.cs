using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using POSCreditRepayments.Models;
using POSCreditRepayments.Web.Infrastructure.Mappings;

namespace POSCreditRepayments.Web.ViewModels.Products
{
    public class AllProductsViewModel : IMapFrom<Product>
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 20)]
        public string Description { get; set; }

        [Required]
        [Range(1, 100000)]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}