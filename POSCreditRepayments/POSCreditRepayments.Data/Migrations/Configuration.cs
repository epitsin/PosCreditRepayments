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
        }

        protected void SeedProducts(POSCreditRepaymentsDbContext context)
        {
            if (context.Products.Any())
            {
                return;
            }

            context.Products.Add(new Product
            {
                Name = "кЮОРНО ASUS G750JZ-T4039D",
                Description = @"рхо: кюорно
                                йюоюжхрер RAM: 8 GB
                                йюоюжхрер HDD: 1000 GB
                                рхо опнжеянп: INTEL CORE i7-4700HQ
                                пюглеп мю ейпюмю б INCH: 17.3
                                веярнрю мю опнжеянпю: 2.40 - 3.40 GHz
                                рхо цпютхвмю йюпрю: NVIDIA GEFORCE GTX 880M",
                Price = 2579,
                ImageUrl = "/Content/Images/1.png"
            });

            context.Products.Add(new Product
            {
                Name = "кЮОРНО APPLE MB PRO MF840ZE/A",
                Description = @"рхо: кюорно
                                йюоюжхрер RAM: 8 GB
                                йюоюжхрер HDD: 1000 GB
                                рхо опнжеянп: INTEL CORE i7-4700HQ
                                пюглеп мю ейпюмю б INCH: 17.3
                                веярнрю мю опнжеянпю: 2.40 - 3.40 GHz
                                рхо цпютхвмю йюпрю: NVIDIA GEFORCE GTX 880M",
                Price = 3339,
                ImageUrl = "/Content/Images/2.png"
            });

            context.Products.Add(new Product
            {
                Name = "кЮОРНО LENOVO YOGA 3 PRO 80HE00LVBM",
                Description = @"рхо: кюорно
йюоюжхрер RAM: 8 GB
рхо опнжеянп: INTEL CORE M-5Y71
пюглеп мю ейпюмю б INCH: 13.3 
веярнрю мю опнжеянпю: 1.20 - 2.90 GHz
рхо цпютхвмю йюпрю: INTEL HD GRAPHICS 5300",
                Price = 2579,
                ImageUrl = "/Content/Images/3.png"
            });

            context.Products.Add(new Product
            {
                Name = "кЮОРНО DELL Alienware 17 /656738",
                Description = @"рхо: кюорно
йюоюжхрер RAM: 16 GB
йюоюжхрер HDD: 1000 GB
рхо опнжеянп: INTEL CORE i7-4710MQ
пюглеп мю ейпюмю б INCH: 17.3 
веярнрю мю опнжеянпю: 2.50 - 3.50 GHz
рхо цпютхвмю йюпрю: NVIDIA GEFORCE GTX 880M",
                Price = 4699,
                ImageUrl = "/Content/Images/4.png"
            });

            context.Products.Add(new Product
            {
                Name = "кЮОРНО TOSHIBA KIRA-107",
                Description = @"рхо: скрпюасй
йюоюжхрер RAM: 8 GB
рхо опнжеянп: INTEL CORE i7-5500U
пюглеп мю ейпюмю б INCH: 13.3 
веярнрю мю опнжеянпю: 2.40 - 3.00 GHz
рхо цпютхвмю йюпрю: INTEL HD GRAPHICS 5500",
                Price = 3099,
                ImageUrl = "/Content/Images/5.png"
            });

            context.SaveChanges();
        }
    }
}
