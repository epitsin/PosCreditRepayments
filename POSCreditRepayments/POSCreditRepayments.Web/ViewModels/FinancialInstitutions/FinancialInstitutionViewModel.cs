using System.ComponentModel;
using POSCreditRepayments.Models;
using POSCreditRepayments.Web.Infrastructure.Mappings;

namespace POSCreditRepayments.Web.ViewModels.FinancialInstitutions
{
    public class FinancialInstitutionViewModel : IMapFrom<FinancialInstitution>
    {
        public double MonthsOneToThree { get; set; }

        public double MonthsFourToSix { get; set; }

        public double MonthsSevenToNine { get; set; }

        public double MonthsTenToTwelve { get; set; }

        public double MonthsThirteenToEighteen { get; set; }

        public double MonthsNineteenToTwentyFour { get; set; }

        public double MonthsMoreThanTwentyFour { get; set; }
    }
}