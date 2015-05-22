using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using POSCreditRepayments.Common;
using POSCreditRepayments.Models;

namespace POSCreditRepayments.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<POSCreditRepaymentsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            // TODO turn off data loss
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "POSCreditRepayments.Data.POSCreditRepaymentsDbContext";
        }

        protected override void Seed(POSCreditRepaymentsDbContext context)
        {
            this.SeedRoles(context);
            this.SeedProducts(context);
            this.SeedFinancialInstitutions(context);
        }

        private void SeedFinancialInstitutions(POSCreditRepaymentsDbContext context)
        {
            if (context.FinancialInstitutions.Any())
            {
                return;
            }

            PurchaseProfile upToOneYearUpTo2000 = new PurchaseProfile
            {
                MonthsMin = 3,
                MonthsMax = 12,
                PriceMin = 100,
                PriceMax = 2000
            };

            PurchaseProfile upToOneYearAbove2000 = new PurchaseProfile
            {
                MonthsMin = 3,
                MonthsMax = 12,
                PriceMin = 2000.001m,
                PriceMax = 100000
            };
            PurchaseProfile upToTwoYearsUpTo2000 = new PurchaseProfile
            {
                MonthsMin = 13,
                MonthsMax = 24,
                PriceMin = 100,
                PriceMax = 2000
            };
            PurchaseProfile upToTwoYearsAbove2000 = new PurchaseProfile
            {
                MonthsMin = 13,
                MonthsMax = 24,
                PriceMin = 2000.001m,
                PriceMax = 100000
            };
            PurchaseProfile upToThreeYearsUpTo2000 = new PurchaseProfile
            {
                MonthsMin = 25,
                MonthsMax = 36,
                PriceMin = 100,
                PriceMax = 2000
            };
            PurchaseProfile upToThreeYearsAbove2000 = new PurchaseProfile
            {
                MonthsMin = 25,
                MonthsMax = 36,
                PriceMin = 2000.001m,
                PriceMax = 100000
            };

            FinancialInstitution fiBank = new FinancialInstitution
            {
                Name = "FiBank",
                MonthlyTax = 1.5m,
                UserName = "FiBank",
                IsApproved = true
            };

            fiBank.FinancialInstitutionPurchaseProfiles = new List<FinancialInstitutionPurchaseProfile>()
            {
                new FinancialInstitutionPurchaseProfile
                {
                    FinancialInstitution = fiBank,
                    PurchaseProfile = upToOneYearUpTo2000,
                    InterestRate = 23
                },
                new FinancialInstitutionPurchaseProfile
                {
                    FinancialInstitution = fiBank,
                    PurchaseProfile = upToOneYearAbove2000,
                    InterestRate = 22
                },
                new FinancialInstitutionPurchaseProfile
                {
                    FinancialInstitution = fiBank,
                    PurchaseProfile = upToTwoYearsUpTo2000,
                    InterestRate = 22
                },
                new FinancialInstitutionPurchaseProfile
                {
                    FinancialInstitution = fiBank,
                    PurchaseProfile = upToTwoYearsAbove2000,
                    InterestRate = 21
                },
                new FinancialInstitutionPurchaseProfile
                {
                    FinancialInstitution = fiBank,
                    PurchaseProfile = upToThreeYearsUpTo2000,
                    InterestRate = 21
                },
                new FinancialInstitutionPurchaseProfile
                {
                    FinancialInstitution = fiBank,
                    PurchaseProfile = upToThreeYearsAbove2000,
                    InterestRate = 20
                }
            };

            FinancialInstitution uniCredit = new FinancialInstitution
            {
                Name = "UniCredit",
                MonthlyTax = 2m,
                UserName = "UniCredit",
                IsApproved = true
            };

            uniCredit.FinancialInstitutionPurchaseProfiles = new List<FinancialInstitutionPurchaseProfile>()
            {
                new FinancialInstitutionPurchaseProfile
                {
                    FinancialInstitution = uniCredit,
                    PurchaseProfile = upToOneYearUpTo2000,
                    InterestRate = 26
                },
                new FinancialInstitutionPurchaseProfile
                {
                    FinancialInstitution = uniCredit,
                    PurchaseProfile = upToOneYearAbove2000,
                    InterestRate = 25
                },
                new FinancialInstitutionPurchaseProfile
                {
                    FinancialInstitution = uniCredit,
                    PurchaseProfile = upToTwoYearsUpTo2000,
                    InterestRate = 25
                },
                new FinancialInstitutionPurchaseProfile
                {
                    FinancialInstitution = uniCredit,
                    PurchaseProfile = upToTwoYearsAbove2000,
                    InterestRate = 24
                },
                new FinancialInstitutionPurchaseProfile
                {
                    FinancialInstitution = uniCredit,
                    PurchaseProfile = upToThreeYearsUpTo2000,
                    InterestRate = 24
                },
                new FinancialInstitutionPurchaseProfile
                {
                    FinancialInstitution = uniCredit,
                    PurchaseProfile = upToThreeYearsAbove2000,
                    InterestRate = 23
                }
            };

            FinancialInstitution allianz = new FinancialInstitution
            {
                Name = "Allianz",
                MonthlyTax = 2.5m,
                UserName = "Allianz",
                IsApproved = true
            };

            allianz.FinancialInstitutionPurchaseProfiles = new List<FinancialInstitutionPurchaseProfile>()
            {
                new FinancialInstitutionPurchaseProfile
                {
                    FinancialInstitution = allianz,
                    PurchaseProfile = upToOneYearUpTo2000,
                    InterestRate = 27
                },
                new FinancialInstitutionPurchaseProfile
                {
                    FinancialInstitution = allianz,
                    PurchaseProfile = upToOneYearAbove2000,
                    InterestRate = 26
                },
                new FinancialInstitutionPurchaseProfile
                {
                    FinancialInstitution = allianz,
                    PurchaseProfile = upToTwoYearsUpTo2000,
                    InterestRate = 26
                },
                new FinancialInstitutionPurchaseProfile
                {
                    FinancialInstitution = allianz,
                    PurchaseProfile = upToTwoYearsAbove2000,
                    InterestRate = 25
                },
                new FinancialInstitutionPurchaseProfile
                {
                    FinancialInstitution = allianz,
                    PurchaseProfile = upToThreeYearsUpTo2000,
                    InterestRate = 25
                },
                new FinancialInstitutionPurchaseProfile
                {
                    FinancialInstitution = allianz,
                    PurchaseProfile = upToThreeYearsAbove2000,
                    InterestRate = 24
                }
            };

            var userManager = new UserManager<User>(new UserStore<User>(context));
            userManager.Create(fiBank, "123123");
            userManager.Create(uniCredit, "123123");
            userManager.Create(allianz, "123123");
            userManager.AddToRole(fiBank.Id, GlobalConstants.FinancialInstitutionRole);
            userManager.AddToRole(uniCredit.Id, GlobalConstants.FinancialInstitutionRole);
            userManager.AddToRole(allianz.Id, GlobalConstants.FinancialInstitutionRole);

            context.SaveChanges();
        }

        private void SeedProducts(POSCreditRepaymentsDbContext context)
        {
            if (context.Products.Any())
            {
                return;
            }

            context.Products.Add(new Product
            {
                Name = "Laptop ASUS G750JZ-T4039D",
                Description = @"<strong>Type:</strong> LAPTOP <br/>
                                <strong>RAM MEMORY:</strong> 8 GB<br/>
                                <strong>HARD DRIVE:</strong> 1000 GB<br/>
                                <strong>PROCESSOR TYPE:</strong> INTEL CORE i7-4700HQ<br/>
                                <strong>SCREEN SIZE:</strong> 17.3<br/>
                                <strong>PROCESSOR SPEED:</strong> 2.40 - 3.40 GHz<br/>
                                <strong>GRAPHIC VIDEO CARD:</strong> NVIDIA GEFORCE GTX 880M",
                Price = 2579,
                ImageUrl = "/Content/Images/1.png"
            });

            context.Products.Add(new Product
            {
                Name = "Laptop APPLE MB PRO MF840ZE/A",
                Description = @"<strong>TYPE:</strong> LAPTOP<br/>
                                <strong>RAM MEMORY:</strong> 8 GB<br/>
                                <strong>HARD DRIVE:</strong> 1000 GB<br/>
                                <strong>PROCESSOR TYPE:</strong> INTEL CORE i7-4700HQ<br/>
                                <strong>SCREEN SIZE:</strong> 17.3<br/>
                                <strong>PROCESSOR SPEED:</strong> 2.40 - 3.40 GHz<br/>
                                <strong>GRAPHIC VIDEO CARD:</strong> NVIDIA GEFORCE GTX 880M",
                Price = 3339,
                ImageUrl = "/Content/Images/2.png"
            });

            context.Products.Add(new Product
            {
                Name = "Laptop LENOVO YOGA 3 PRO 80HE00LVBM",
                Description = @"<strong>TYPE:</strong> LAPTOP<br/>
                                <strong>RAM MEMORY:</strong> 8 GB<br/>
                                <strong>PROCESSOR TYPE:</strong> INTEL CORE M-5Y71<br/>
                                <strong>SCREEN SIZE:</strong> 13.3 <br/>
                                <strong>PROCESSOR SPEED:</strong> 1.20 - 2.90 GHz<br/>
                                <strong>GRAPHIC VIDEO CARD:</strong> INTEL HD GRAPHICS 5300",
                Price = 2579,
                ImageUrl = "/Content/Images/3.png"
            });

            context.Products.Add(new Product
            {
                Name = "Laptop DELL Alienware 17 /656738",
                Description = @"<strong>TYPE:</strong> LAPTOP<br/>
                                <strong>RAM MEMORY:</strong> 16 GB<br/>
                                <strong>HARD DRIVE:</strong> 1000 GB<br/>
                                <strong>PROCESSOR TYPE:</strong> INTEL CORE i7-4710MQ<br/>
                                <strong>SCREEN SIZE:</strong> 17.3 <br/>
                                <strong>PROCESSOR SPEED:</strong> 2.50 - 3.50 GHz<br/>
                                <strong>GRAPHIC VIDEO CARD:</strong> NVIDIA GEFORCE GTX 880M",
                Price = 4699,
                ImageUrl = "/Content/Images/4.png"
            });

            context.Products.Add(new Product
            {
                Name = "Laptop TOSHIBA KIRA-107",
                Description = @"<strong>TYPE:</strong> ULTRABOOK<br/>
                                <strong>RAM MEMORY:</strong> 8 GB<br/>
                                <strong>PROCESSOR TYPE:</strong> INTEL CORE i7-5500U<br/>
                                <strong>SCREEN SIZE:</strong> 13.3 <br/>
                                <strong>PROCESSOR SPEED:</strong> 2.40 - 3.00 GHz<br/>
                                <strong>GRAPHIC VIDEO CARD:</strong> INTEL HD GRAPHICS 5500",
                Price = 3099,
                ImageUrl = "/Content/Images/5.png"
            });

            context.Products.Add(new Product
            {
                Name = "Laptop LENOVO G710A/59412620",
                Description = @"<strong>TYPE:</strong> LAPTOP<br/>
                                <strong>PROCESSOR TYPE:</strong> INTEL CORE i3-4000M<br/>
                                <strong>PROCESSOR SPEED:</strong> 2.40 GHz<br/>
                                <strong>RAM MEMORY:</strong> 6 GB<br/>
                                <strong>HARD DRIVE:</strong> 1000 GB<br/>
                                <strong>GRAPHIC VIDEO CARD:</strong> NVIDIA GEFORCE 820M<br/>
                                <strong>SCREEN SIZE:</strong> 17.3 ",
                Price = 999,
                ImageUrl = "/Content/Images/6.png"
            });

            context.SaveChanges();
        }

        private void SeedRoles(POSCreditRepaymentsDbContext context)
        {
            if (!context.Users.Any())
            {
                string password = "123123";

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                roleManager.Create(new IdentityRole("Admin"));
                roleManager.Create(new IdentityRole("Financial institution"));
                roleManager.Create(new IdentityRole("User"));

                var userManager = new UserManager<User>(new UserStore<User>(context));
                var admin = new User { UserName = "admin", Email = "admin@admin.admin" };
                userManager.Create(admin, password);
                userManager.AddToRole(admin.Id, GlobalConstants.AdminRole);

                context.SaveChanges();
            }
        }
    }
}