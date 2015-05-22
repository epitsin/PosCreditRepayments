using System.ComponentModel.DataAnnotations;

namespace POSCreditRepayments.Models
{
    public enum InsuranceType
    {
        None,
        Life,
        Unemployment,
        [Display(Name = "Life and unemployment")]
        LifeAndUnemployment,
        Purchase,
        [Display(Name = "Life, unemployment and purchase")]
        All
    }
}
