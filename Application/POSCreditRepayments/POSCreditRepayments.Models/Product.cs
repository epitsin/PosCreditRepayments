using System.Collections.Generic;

namespace POSCreditRepayments.Models
{
    public class Product
    {
        public Product()
        {
            this.Credits = new HashSet<Credit>();
        }

        public virtual ICollection<Credit> Credits { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int ProductId { get; set; }
    }
}