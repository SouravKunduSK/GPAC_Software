namespace GPAC_Software.Models
{
    public static class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<AppDbContext>();

            if (!context.CorporateCustomers.Any())
            {
                context.CorporateCustomers.AddRange(
                    new CorporateCustomer { Name = "Corporate A", Details = "Details A" },
                    new CorporateCustomer { Name = "Corporate B", Details = "Details B" }
                );
            }

            if (!context.IndividualCustomers.Any())
            {
                context.IndividualCustomers.AddRange(
                    new IndividualCustomer { Name = "Individual A", Details = "Details A" },
                    new IndividualCustomer { Name = "Individual B", Details = "Details B" }
                );
            }

            if (!context.ProductServices.Any())
            {
                context.ProductServices.AddRange(
                    new ProductService { Name = "Product A", Unit = "kg" },
                    new ProductService { Name = "Product B", Unit = "liters" }
                );
            }

            context.SaveChanges();
        }
    }

}
