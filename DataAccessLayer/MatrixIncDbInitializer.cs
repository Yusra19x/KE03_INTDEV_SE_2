using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class MatrixIncDbInitializer
    {
        public static void Initialize(MatrixIncDbContext context)
        {
            // Look for any customers.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            // TODO: Hier moet ik nog wat namen verzinnen die betrekking hebben op de matrix.
            // - Denk aan de m3 boutjes, moertjes en ringetjes.
            // - Denk aan namen van schepen
            // - Denk aan namen van vliegtuigen            
            var customers = new Customer[]
            {
                new Customer { Name = "Neo", Address = "123 Elm St" , Active=true},
                new Customer { Name = "Morpheus", Address = "456 Oak St", Active = true },
                new Customer { Name = "Trinity", Address = "789 Pine St", Active = true }
            };
            context.Customers.AddRange(customers);

            var orders = new Order[]
            {
                new Order { Customer = customers[0], OrderDate = DateTime.Parse("2021-01-01")},
                new Order { Customer = customers[0], OrderDate = DateTime.Parse("2021-02-01")},
                new Order { Customer = customers[1], OrderDate = DateTime.Parse("2021-02-01")},
                new Order { Customer = customers[2], OrderDate = DateTime.Parse("2021-03-01")}
            };  
            context.Orders.AddRange(orders);

            var products = new Product[]
            {
                new Product { Name = "Nebuchadnezzar", Description = "Het hovercraft-schip van Morpheus en zijn crew.", Image = "nebuchadnezzar.jpg", Category = "Voertuigen", Brand = "MatrixFleet", Color = "Grijs", Material = "Titanium", Weight = 15000, Stock = 2, PurchasePrice = 8000.00m, SellingPrice = 10000.00m, VAT = 21, Active = true },
                new Product { Name = "Jack-in Chair", Description = "Stoel gebruikt om mensen in te pluggen in de Matrix via een nekpoort.", Image = "jack-in-chair.jpg", Category = "Apparatuur", Brand = "NeuralNet Industries", Color = "Zwart", Material = "Staal", Weight = 45, Stock = 10, PurchasePrice = 300.00m, SellingPrice = 499.99m, VAT = 21, Active = true },
                new Product { Name = "EMP Blaster", Description = "Electro-Magnetic Pulse wapen tegen Sentinels.", Image = "emp-blaster.jpg", Category = "Wapens", Brand = "ZionTech", Color = "Zilver", Material = "Metaal", Weight = 60, Stock = 5, PurchasePrice = 120.00m, SellingPrice = 180.00m, VAT = 21, Active = true },
                new Product { Name = "Red Pill", Description = "Symbolisch: opent de ogen van mensen voor de echte wereld.", Image = "red-pill.jpg", Category = "Farmaceutica", Brand = "RealityLabs", Color = "Rood", Material = "Gelatine capsule", Weight = 0.05, Stock = 100, PurchasePrice = 1.00m, SellingPrice = 2.50m, VAT = 9, Active = true },
                new Product { Name = "Sentinel Drone", Description = "Mechanisch beest gebruikt door de machines om op te jagen.", Image = "sentinel-drone.jpg", Category = "Vijandige Eenheden", Brand = "Machine Core", Color = "Metaalgrijs", Material = "Composietlegering", Weight = 500, Stock = 1, PurchasePrice = 15000.00m, SellingPrice = 20000.00m, VAT = 21, Active = true }
            };
            context.Products.AddRange(products);

            var parts = new Part[]
            {
                new Part { Name = "Tandwiel", Description = "Overdracht van rotatie in bijvoorbeeld de motor of luikmechanismen"},
                new Part { Name = "M5 Boutje", Description = "Bevestiging van panelen, buizen of interne modules"},
                new Part { Name = "Hydraulische cilinder", Description = "Openen/sluiten van zware luchtsluizen of bewegende onderdelen"},
                new Part { Name = "Koelvloeistofpomp", Description = "Koeling van de motor of elektronische systemen."}
            };
            context.Parts.AddRange(parts);

            var stockItems = new Stock[]
            {
                new Stock { Name = "Nebuchadnezzar", StockAmount = 2 },
                new Stock { Name = "Jack-in Chair", StockAmount = 10 },
                new Stock { Name = "EMP Blaster", StockAmount = 5 },
                new Stock { Name = "Red Pill", StockAmount = 100 },
                new Stock { Name = "Sentinel Drone", StockAmount = 1 }
            };

            context.Stock.AddRange(stockItems);

            context.SaveChanges();

            context.Database.EnsureCreated();
        }
    }
}
