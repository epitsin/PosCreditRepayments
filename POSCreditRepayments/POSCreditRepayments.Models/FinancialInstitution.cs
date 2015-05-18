using System.Collections.Generic;

namespace POSCreditRepayments.Models
{
    public class FinancialInstitution
    {
        public int FinancialInstitutionId { get; set; }

        public string Name { get; set; }

        public double MonthsOneToThree { get; set; }

        public double MonthsFourToSix { get; set; }

        public double MonthsSevenToNine { get; set; }

        public double MonthsTenToTwelve { get; set; }

        public double MonthsThirteenToEighteen { get; set; }

        public double MonthsNineteenToTwentyFour { get; set; }

        public double MonthsMoreThanTwentyFour { get; set; }

        public FinancialInstitution()
        {
            this.Credits = new HashSet<Credit>();
        }

        public virtual ICollection<Credit> Credits { get; set; }
    }
}
