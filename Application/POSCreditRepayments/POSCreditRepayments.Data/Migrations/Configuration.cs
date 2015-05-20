using System.Data.Entity.Migrations;
using System.Linq;
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
            this.SeedProducts(context);
            this.SeedFinancialInstitutions(context);
        }

        private void SeedFinancialInstitutions(POSCreditRepaymentsDbContext context)
        {
            if (context.FinancialInstitutions.Any())
            {
                return;
            }

            context.FinancialInstitutions.Add(new FinancialInstitution
            {
                Name = "FiBank",
                InterestRate = 23
            });

            context.FinancialInstitutions.Add(new FinancialInstitution
            {
                Name = "UniCredit",
                InterestRate = 26
            });

            context.FinancialInstitutions.Add(new FinancialInstitution
            {
                Name = "Allianz",
                InterestRate = 28
            });
        }

        private void SeedProducts(POSCreditRepaymentsDbContext context)
        {
            if (context.Products.Any())
            {
                return;
            }

            context.Products.Add(new Product
            {
                Name = "À‡ÔÚÓÔ ASUS G750JZ-T4039D",
                Description = @"<strong>“»œ:</strong> À¿œ“Œœ <br/>
                                <strong> ¿œ¿÷»“≈“ RAM:</strong> 8 GB<br/>
                                <strong> ¿œ¿÷»“≈“ HDD:</strong> 1000 GB<br/>
                                <strong>“»œ œ–Œ÷≈—Œ–:</strong> INTEL CORE i7-4700HQ<br/>
                                <strong>–¿«Ã≈– Õ¿ ≈ –¿Õ¿ ¬ INCH:</strong> 17.3<br/>
                                <strong>◊≈—“Œ“¿ Õ¿ œ–Œ÷≈—Œ–¿:</strong> 2.40 - 3.40 GHz<br/>
                                <strong>“»œ √–¿‘»◊Õ¿  ¿–“¿:</strong> NVIDIA GEFORCE GTX 880M",
                Price = 2579,
                ImageUrl = "/Content/Images/1.png"
            });

            context.Products.Add(new Product
            {
                Name = "À‡ÔÚÓÔ APPLE MB PRO MF840ZE/A",
                Description = @"<strong>“»œ:</strong> À¿œ“Œœ<br/>
                                <strong> ¿œ¿÷»“≈“ RAM:</strong> 8 GB<br/>
                                <strong> ¿œ¿÷»“≈“ HDD:</strong> 1000 GB<br/>
                                <strong>“»œ œ–Œ÷≈—Œ–:</strong> INTEL CORE i7-4700HQ<br/>
                                <strong>–¿«Ã≈– Õ¿ ≈ –¿Õ¿ ¬ INCH:</strong> 17.3<br/>
                                <strong>◊≈—“Œ“¿ Õ¿ œ–Œ÷≈—Œ–¿:</strong> 2.40 - 3.40 GHz<br/>
                                <strong>“»œ √–¿‘»◊Õ¿  ¿–“¿:</strong> NVIDIA GEFORCE GTX 880M",
                Price = 3339,
                ImageUrl = "/Content/Images/2.png"
            });

            context.Products.Add(new Product
            {
                Name = "À‡ÔÚÓÔ LENOVO YOGA 3 PRO 80HE00LVBM",
                Description = @"<strong>“»œ:</strong> À¿œ“Œœ<br/>
                                <strong> ¿œ¿÷»“≈“ RAM:</strong> 8 GB<br/>
                                <strong>“»œ œ–Œ÷≈—Œ–:</strong> INTEL CORE M-5Y71<br/>
                                <strong>–¿«Ã≈– Õ¿ ≈ –¿Õ¿ ¬ INCH:</strong> 13.3 <br/>
                                <strong>◊≈—“Œ“¿ Õ¿ œ–Œ÷≈—Œ–¿:</strong> 1.20 - 2.90 GHz<br/>
                                <strong>“»œ √–¿‘»◊Õ¿  ¿–“¿:</strong> INTEL HD GRAPHICS 5300",
                Price = 2579,
                ImageUrl = "/Content/Images/3.png"
            });

            context.Products.Add(new Product
            {
                Name = "À‡ÔÚÓÔ DELL Alienware 17 /656738",
                Description = @"<strong>“»œ:</strong> À¿œ“Œœ<br/>
                                <strong> ¿œ¿÷»“≈“ RAM:</strong> 16 GB<br/>
                                <strong> ¿œ¿÷»“≈“ HDD:</strong> 1000 GB<br/>
                                <strong>“»œ œ–Œ÷≈—Œ–:</strong> INTEL CORE i7-4710MQ<br/>
                                <strong>–¿«Ã≈– Õ¿ ≈ –¿Õ¿ ¬ INCH:</strong> 17.3 <br/>
                                <strong>◊≈—“Œ“¿ Õ¿ œ–Œ÷≈—Œ–¿:</strong> 2.50 - 3.50 GHz<br/>
                                <strong>“»œ √–¿‘»◊Õ¿  ¿–“¿:</strong> NVIDIA GEFORCE GTX 880M",
                Price = 4699,
                ImageUrl = "/Content/Images/4.png"
            });

            context.Products.Add(new Product
            {
                Name = "À‡ÔÚÓÔ TOSHIBA KIRA-107",
                Description = @"<strong>“»œ:</strong> ”À“–¿¡” <br/>
                                <strong> ¿œ¿÷»“≈“ RAM:</strong> 8 GB<br/>
                                <strong>“»œ œ–Œ÷≈—Œ–:</strong> INTEL CORE i7-5500U<br/>
                                <strong>–¿«Ã≈– Õ¿ ≈ –¿Õ¿ ¬ INCH:</strong> 13.3 <br/>
                                <strong>◊≈—“Œ“¿ Õ¿ œ–Œ÷≈—Œ–¿:</strong> 2.40 - 3.00 GHz<br/>
                                <strong>“»œ √–¿‘»◊Õ¿  ¿–“¿:</strong> INTEL HD GRAPHICS 5500",
                Price = 3099,
                ImageUrl = "/Content/Images/5.png"
            });

            context.Products.Add(new Product
            {
                Name = "À‡ÔÚÓÔ LENOVO G710A/59412620",
                Description = @"<strong>“»œ:</strong> À¿œ“Œœ<br/>
                                <strong>“»œ œ–Œ÷≈—Œ–:</strong> INTEL CORE i3-4000M<br/>
                                <strong>◊≈—“Œ“¿ Õ¿ œ–Œ÷≈—Œ–¿:</strong> 2.40 GHz<br/>
                                <strong> ¿œ¿÷»“≈“ RAM:</strong> 6 GB<br/>
                                <strong> ¿œ¿÷»“≈“ HDD:</strong> 1000 GB<br/>
                                <strong>“»œ √–¿‘»◊Õ¿  ¿–“¿:</strong> NVIDIA GEFORCE 820M<br/>
                                <strong>–¿«Ã≈– Õ¿ ≈ –¿Õ¿ ¬ INCH:</strong> 17.3 ",
                Price = 999,
                ImageUrl = "/Content/Images/6.png"
            });

            context.SaveChanges();
        }
    }
}
