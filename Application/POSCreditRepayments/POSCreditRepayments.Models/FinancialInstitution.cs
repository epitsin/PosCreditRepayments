﻿using System.Collections.Generic;

namespace POSCreditRepayments.Models
{
    public class FinancialInstitution : User
    {
        public FinancialInstitution()
        {
            this.Credits = new HashSet<Credit>();
            this.FinancialInstitutionPurchaseProfiles = new HashSet<FinancialInstitutionPurchaseProfile>();
            this.Insurances = new HashSet<Insurance>();
        }

        public string Address { get; set; }

        public decimal ApplicationFee { get; set; }

        public string CreditIntermerdiary { get; set; }

        public virtual ICollection<Credit> Credits { get; set; }

        public string Fax { get; set; }

        public virtual ICollection<FinancialInstitutionPurchaseProfile> FinancialInstitutionPurchaseProfiles { get; set; }

        public virtual ICollection<Insurance> Insurances { get; set; }

        public bool IsApproved { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string WebSite { get; set; }
    }
}