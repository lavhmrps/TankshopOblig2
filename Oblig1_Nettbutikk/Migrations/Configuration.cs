namespace Oblig1_Nettbutikk.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Oblig1_Nettbutikk.Models.WebShopModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Oblig1_Nettbutikk.Models.WebShopModel";
        }

        protected override void Seed(Oblig1_Nettbutikk.Models.WebShopModel context)
        {
            // Categories
            context.Categories.AddOrUpdate(new Category
            {
                Name="Tanks"                
            },
            new Category
            {
                Name ="Engines"
            },
            new Category
            {
                Name = "Guns"
            },
            new Category
            {
                Name = "Kjøkkenutstyr"
            });

            // Tanks
            context.Products.AddOrUpdate(
            new Product
            {
                Name = "Tiger 1",
                Price =500000,
                Stock=5,
                Description= "Tiger I is the common name of a German heavy tank developed in 1942 and used in World War II. The final official German designation was Panzerkampfwagen VI Tiger Ausf. E, often shortened to Tiger. The Tiger I gave the Wehrmacht its first tank which mounted a KwK 36 88mm gun in an armoured fighting vehicle. The KwK 36 is not to be confused with the earlier and similar 8.8 cm Flak 36, a different weapon designed in parallel with the KwK 36 and firing the same ammunition (\"KwK\" denotes an armored vehicle gun, while \"Flak\" denotes anti-aircraft artillery). During the course of the war, the Tiger I saw combat on all German battlefronts. It was usually deployed in independent heavy tank battalions, which proved highly effective",
                CategoryID=1
            }, new Product
            {
                Name = "Panther",
                Price = 760000,
                Stock = 5,
                Description = "he Panther was a German medium tank deployed during World War II from mid-1943 to the end of the European war in 1945. It was intended as a counter to the Soviet T-34, and as a replacement for the Panzer III and Panzer IV. While never replacing the latter, it served alongside it and the heavier Tiger I until the end of the war. While the Panther is considered one of the best tanks of World War II due to its excellent firepower and protection, it was less impressive in terms of mobility, reliability, and cost.",
                CategoryID = 1
            }, new Product
            {
                Name = "JagdPanther",
                Price = 50000,
                Stock = 5,
                Description = "The Jagdpanther was a tank destroyer built by Nazi Germany during World War II based on the chassis of the Panther tank. It entered service late in the war (1944) and saw service on the Eastern and Western Fronts. The Jagdpanther combined the very powerful 8.8 cm PaK 43 cannon of the Tiger II and the characteristically excellent armor and suspension of the Panther chassis, although it suffered from the general poor state of German ordnance production, maintenance and training in the later part of the war, which resulted in small production numbers, shortage in spare parts and poor crew readiness.",
                CategoryID = 1
            }, new Product
            {
                Name = "Sherman Firefly",
                Price = 50000,
                Stock = 5,
                Description = "The Sherman Firefly was a tank used by the United Kingdom in World War II. It was based on the US M4 Sherman but fitted with the powerful 3-inch (76.2 mm) calibre British 17-pounder anti-tank gun as its main weapon. Originally conceived as a stopgap until future British tank designs came into service, the Sherman Firefly became the most common vehicle with the 17-pounder in the war.",
                CategoryID = 1
            }, new Product
            {
                Name = "Churchill Tank",
                Price = 50000,
                Stock = 5,
                Description = "The Tank, Infantry, Mk IV (A22) was a British heavy infantry tank used in the Second World War, best known for its heavy armour, large longitudinal chassis with all-around tracks with multiple bogies, and its use as the basis of many specialist vehicles. It was one of the heaviest Allied tanks of the war.",
                CategoryID = 1
            }, new Product
            {
                Name = "Light Tank Mk VI",
                Price = 50000,
                Stock = 5,
                Description = "The Tank, Light, Mk VI was a British light tank, produced by Vickers-Armstrong in the late 1930s, which saw service during World War II.",
                CategoryID = 1
            }, new Product
            {
                Name = "M4 Sherman",
                Price = 50000,
                Stock = 5,
                Description = "The M4 Sherman, officially Medium Tank, M4, was the most numerous battle tank used by the United States and some other Western Allies in World War II. It proved to be reliable and mobile. In spite of being outclassed in guns and armor thickness by German medium and heavy tanks late in the war, the M4 Sherman was cheaper to produce, more mechanically reliable, more capable of withstanding hostile terrain, faster, and more likely to get the first shot off in combat owing to the fast rotation of the turret.Thousands were distributed through the Lend - Lease program to the British Commonwealth and Soviet Union.The tank was named after the American Civil War General William Tecumseh Sherman by the British.",
                CategoryID = 1
            }, new Product
            {
                Name = "M26 Pershing",
                Price = 50000,
                Stock = 5,
                Description = "The Pershing was a medium tank of the United States Army. It was designated a heavy tank when it was first designed in World War II due to its 90mm gun, and its armor. The tank is named after General of the Armies John J. Pershing, who led the American Expeditionary Force in Europe in World War I. It was briefly used both in World War II and the Korean War.",
                CategoryID = 1
            }, new Product
            {
                Name = "M10 tank destroyer",
                Price = 50000,
                Stock = 5,
                Description = "The M10 tank destroyer was a United States tank destroyer of World War II based on the chassis of the M4 Sherman tank fitted with the 3-inch (76.2 mm) Gun M7. Formally 3-inch Gun Motor Carriage, M10, it was numerically the most important U.S. tank destroyer of World War II and combined a reasonably potent anti-tank weapon with a turreted platform. Despite the introduction of more-powerful types as replacements, it remained in service until the end of the war, and its chassis was later reused with a new turret to create the M36 Jackson, which used a 90mm gun instead of the 76.2mm gun.",
                CategoryID = 1
            });


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
