using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Xml.Linq;

namespace Course_work._Window_program
{
    public enum Color
    {
        White,
        Black,
        Red,
        Green,
        Blue,
        Yellow
    }
    internal static class ExampleData
    {
        internal static void Seed(MyDbContext context)
        {
            var configuration = new DbMigrationsConfiguration<MyDbContext>
            {
                AutomaticMigrationsEnabled = true,
                AutomaticMigrationDataLossAllowed = true
            };

            var migrator = new DbMigrator(configuration);
            migrator.Update();

            // Adding data for GlassType
            var glassType = new GlassType("Heat Resistant Glass", 12.5m, "Transparent");
            context.GlassTypes.Add(glassType);

            // Adding data for PlasticType
            var plasticType = new PlasticType("Polycarbonate", 8m, "Black");
            context.PlasticTypes.Add(plasticType);

            // Adding data for WindowOrder
            var order1 = new WindowOrder
            {
                NumberOfSections =2,
                Width = 100,
                Height = 200,
                GlassColor = "Transparent",
                FrameColor = "White",
                FrameMaterial = "Polycarbonate",
                GlassMaterial = "Heat Resistant Glass",
                WindowChambers = 2,
                NumberOfOpeningSections = 1,
                AddressOfOrder = "123 Main St",
                DateOfOrder = DateTime.Now,
                OrderCompleted = false,
                TotalCash = 1500.00m
            };
            context.WindowOrders.Add(order1);

            var order2 = new WindowOrder
            {
                NumberOfSections =3,
                Width = 150,
                Height = 250,
                GlassColor = "Transparent",
                FrameColor = "White",
                FrameMaterial = "Polycarbonate",
                GlassMaterial = "Heat Resistant Glass",
                WindowChambers = 3,
                NumberOfOpeningSections = 2,
                AddressOfOrder = "456 Elm St",
                DateOfOrder = DateTime.Now,
                OrderCompleted = true,
                TotalCash = 2000.00m
            };
            context.WindowOrders.Add(order2);

            context.SaveChanges();
        }
    }


}


