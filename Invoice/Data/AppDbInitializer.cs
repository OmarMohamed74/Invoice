using Invoice.Models;

namespace Invoice.Data
{
    public class AppDbInitializer
    {
        /* Seeding data to database if there are nothing in specific tabels,
         Fill the product details to be used in list of product */
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Product

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {

                            Name = "Billet",

                        },

                       new Product()
                        {

                            Name = "Rebar",

                        },
                       new Product()
                        {

                            Name = "Wire Rod",
                        },

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
  
