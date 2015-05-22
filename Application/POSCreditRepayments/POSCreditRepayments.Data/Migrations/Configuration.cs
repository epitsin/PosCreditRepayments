using System.Data.Entity.Migrations;
using System.Linq;
using POSCreditRepayments.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using POSCreditRepayments.Common;

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


            FinancialInstitution fiBank = new FinancialInstitution
            {
                Name = "FiBank",
                InterestRate = 23,
                MonthlyTax = 1.5,
                UserName = "FiBank",
                IsApproved = true
            };

            FinancialInstitution uniCredit = new FinancialInstitution
            {
                Name = "UniCredit",
                InterestRate = 26,
                MonthlyTax = 2,
                UserName = "UniCredit",
                IsApproved = true
            };

            FinancialInstitution allianz = new FinancialInstitution
            {
                Name = "Allianz",
                InterestRate = 28,
                MonthlyTax = 2.5,
                UserName = "Allianz",
                IsApproved = true
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