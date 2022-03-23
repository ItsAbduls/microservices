using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p=> true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "62376a87e96e3aff77aaba98",
                    Name = "IPhone x",
                    Summary = "hdl aASKjdsa a;SKDasd",
                    Description = "ajd; a;skd;ldyasgdjas ajshgdjas",
                    ImageFile = "Product-1.png",
                    Price = 77.293M,
                    Category = "Smart phone"
                },
                 new Product()
                {
                    Id = "62376a87e96e3aff77aaba99",
                    Name = "IPhone 8",
                    Summary = "hdl aASKjdsa a;SKDasd",
                    Description = "ajd; a;skd;ldyasgdjas ajshgdjas",
                    ImageFile = "Product-2.png",
                    Price = 79.293M,
                    Category = "Smart phone"
                },
                  new Product()
                {
                    Id = "62376a87e96e3aff77aaba9a",
                    Name = "Red 1",
                    Summary = "hdl aASKjdsa a;SKDasd",
                    Description = "ajd; a;skd;ldyasgdjas ajshgdjas",
                    ImageFile = "Product-4.png",
                    Price = 77.293M,
                    Category = "Cloths"
                },
                   new Product()
                {
                    Id = "62376a87e96e3aff77aaba9b",
                    Name = "Red 2",
                    Summary = "hdl aASKjdsa a;SKDasd",
                    Description = "ajd; a;skd;ldyasgdjas ajshgdjas",
                    ImageFile = "Product-5.png",
                    Price = 77.293M,
                    Category = "Cloths"
                },
            };
        }
    }
}
