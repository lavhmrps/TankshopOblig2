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

            // Categories
            context.Categories.AddOrUpdate(new Category
            {
                CategoryID = 1,
                Name = "Tanks"
            },
            new Category
            {
                CategoryID = 2,
                Name = "Engines"
            },
            new Category
            {
                CategoryID = 3,
                Name = "Guns"
            },
            new Category
            {
                CategoryID = 4,
                Name = "Kjøkkenutstyr"
            });

            // Tanks
            context.Products.AddOrUpdate(
            new Product
            {
                ProductID = 1,
                Name = "Tiger 1",
                Price = 500000,
                Stock = 5,
                Description = "Tiger I is the common name of a German heavy tank developed in 1942 and used in World War II. The final official German designation was Panzerkampfwagen VI Tiger Ausf. E, often shortened to Tiger. The Tiger I gave the Wehrmacht its first tank which mounted a KwK 36 88mm gun in an armoured fighting vehicle. The KwK 36 is not to be confused with the earlier and similar 8.8 cm Flak 36, a different weapon designed in parallel with the KwK 36 and firing the same ammunition (\"KwK\" denotes an armored vehicle gun, while \"Flak\" denotes anti-aircraft artillery). During the course of the war, the Tiger I saw combat on all German battlefronts. It was usually deployed in independent heavy tank battalions, which proved highly effective",
                CategoryID = 1
            }, new Product
            {
                ProductID = 2,
                Name = "Panther",
                Price = 760000,
                Stock = 5,
                Description = "he Panther was a German medium tank deployed during World War II from mid-1943 to the end of the European war in 1945. It was intended as a counter to the Soviet T-34, and as a replacement for the Panzer III and Panzer IV. While never replacing the latter, it served alongside it and the heavier Tiger I until the end of the war. While the Panther is considered one of the best tanks of World War II due to its excellent firepower and protection, it was less impressive in terms of mobility, reliability, and cost.",
                CategoryID = 1
            }, new Product
            {
                ProductID = 3,
                Name = "JagdPanther",
                Price = 50000,
                Stock = 5,
                Description = "The Jagdpanther was a tank destroyer built by Nazi Germany during World War II based on the chassis of the Panther tank. It entered service late in the war (1944) and saw service on the Eastern and Western Fronts. The Jagdpanther combined the very powerful 8.8 cm PaK 43 cannon of the Tiger II and the characteristically excellent armor and suspension of the Panther chassis, although it suffered from the general poor state of German ordnance production, maintenance and training in the later part of the war, which resulted in small production numbers, shortage in spare parts and poor crew readiness.",
                CategoryID = 1
            }, new Product
            {
                ProductID = 4,
                Name = "Sherman Firefly",
                Price = 50000,
                Stock = 5,
                Description = "The Sherman Firefly was a tank used by the United Kingdom in World War II. It was based on the US M4 Sherman but fitted with the powerful 3-inch (76.2 mm) calibre British 17-pounder anti-tank gun as its main weapon. Originally conceived as a stopgap until future British tank designs came into service, the Sherman Firefly became the most common vehicle with the 17-pounder in the war.",
                CategoryID = 1
            }, new Product
            {
                ProductID = 5,
                Name = "Churchill Tank",
                Price = 50000,
                Stock = 5,
                Description = "The Tank, Infantry, Mk IV (A22) was a British heavy infantry tank used in the Second World War, best known for its heavy armour, large longitudinal chassis with all-around tracks with multiple bogies, and its use as the basis of many specialist vehicles. It was one of the heaviest Allied tanks of the war.",
                CategoryID = 1
            }, new Product
            {
                ProductID = 6,
                Name = "Light Tank Mk VI",
                Price = 50000,
                Stock = 5,
                Description = "The Tank, Light, Mk VI was a British light tank, produced by Vickers-Armstrong in the late 1930s, which saw service during World War II.",
                CategoryID = 1
            }, new Product
            {
                ProductID = 7,
                Name = "M4 Sherman",
                Price = 50000,
                Stock = 5,
                Description = "The M4 Sherman, officially Medium Tank, M4, was the most numerous battle tank used by the United States and some other Western Allies in World War II. It proved to be reliable and mobile. In spite of being outclassed in guns and armor thickness by German medium and heavy tanks late in the war, the M4 Sherman was cheaper to produce, more mechanically reliable, more capable of withstanding hostile terrain, faster, and more likely to get the first shot off in combat owing to the fast rotation of the turret.Thousands were distributed through the Lend - Lease program to the British Commonwealth and Soviet Union.The tank was named after the American Civil War General William Tecumseh Sherman by the British.",
                CategoryID = 1
            }, new Product
            {
                ProductID = 8,
                Name = "M26 Pershing",
                Price = 50000,
                Stock = 5,
                Description = "The Pershing was a medium tank of the United States Army. It was designated a heavy tank when it was first designed in World War II due to its 90mm gun, and its armor. The tank is named after General of the Armies John J. Pershing, who led the American Expeditionary Force in Europe in World War I. It was briefly used both in World War II and the Korean War.",
                CategoryID = 1
            }, new Product
            {
                ProductID = 9,
                Name = "M10 tank destroyer",
                Price = 50000,
                Stock = 5,
                Description = "The M10 tank destroyer was a United States tank destroyer of World War II based on the chassis of the M4 Sherman tank fitted with the 3-inch (76.2 mm) Gun M7. Formally 3-inch Gun Motor Carriage, M10, it was numerically the most important U.S. tank destroyer of World War II and combined a reasonably potent anti-tank weapon with a turreted platform. Despite the introduction of more-powerful types as replacements, it remained in service until the end of the war, and its chassis was later reused with a new turret to create the M36 Jackson, which used a 90mm gun instead of the 76.2mm gun.",
                CategoryID = 1
            });

            // Engines
            context.Products.AddOrUpdate(
            new Product
            {
                ProductID = 10,
                Name = "Wright R-975",
                Price = 47500,
                Stock = 8,
                Description = "The Wright R-975 Whirlwind was a series of nine-cylinder air-cooled radial aircraft engines built by the Wright Aeronautical division of Curtiss-Wright. These engines had a displacement of about 975 in� (16.0 L) and power ratings of 300-450 hp (225-335 kW). They were the largest members of the Wright Whirlwind engine family to be produced commercially, and they were also the most numerous.",
                CategoryID = 2
            },
             new Product
             {
                 ProductID = 11,
                 Name = "Chrysler A57 multibank",
                 Price = 68189,
                 Stock = 48,
                 Description = "Created in 1941 as America entered World War II, the A57 Multibank engine was born out of the necessity for a rear-mounted tank engine to be developed and produced, in the shortest time possible, for use in both the 109 examples built of the M3A4 Medium Tank, and the 7,499 examples built of the successor M4A4 Medium tank, each of which had lengthened hulls to accommodate them.",
                 CategoryID = 2
             },
             new Product
             {
                 ProductID = 12,
                 Name = "Ford GAA engine",
                 Price = 41688,
                 Stock = 15,
                 Description = "The Ford GAA engine is an American all-aluminum 32-valve DOHC 60-degree V8 engine engineered and produced by the Ford Motor Company just before, and during, World War II. It featured twin Stromberg NA-Y5-G carburetors, dual magnetos and twin spark plugs making up a full dual ignition system, and crossflow induction. It displaces 1,100 cu in (18 l) and puts out well over 1,000 pound-feet (1,400 N�m) of torque from idle to 2600 rpm. The factory-rated output was 525 hp (391 kW) @ 2800 rpm. In terms of its capacity, the GAA was the largest mass-produced gasoline V8 engine in the world.",
                 CategoryID = 2
             },
             new Product
             {
                 ProductID = 13,
                 Name = "Kharkiv model V-2-34",
                 Price = 198689,
                 Stock = 81,
                 Description = "The Kharkiv model V-2 was a Soviet diesel tank V-12 engine designed at the Kharkiv Locomotive Factory by Konstantin Chelpan and his team. It is found in the BT-7M (BT-8), T-34, KV, IS and IS-10 (T-10) tanks, and by extension, the vehicles based on them, such as the SU-85 and SU-100 tank destroyers based on the T-34 and the ISU-122 and ISU-152 self-propelled guns based on the IS-2. Throughout its production life, output ranged from roughly 450-700 hp. V-2 with revised hull mounts, fuel and cooling connectors and refined clutch, 1939. Used in the T-34, SU-85 and SU-100. It produced 500 hp @ 1800 RPM.",
                 CategoryID = 2
             },
             new Product
             {
                 ProductID = 14,
                 Name = "Kharkiv model V-2K",
                 Price = 61695,
                 Stock = 25,
                 Description = "The Kharkiv model V-2 was a Soviet diesel tank V-12 engine designed at the Kharkiv Locomotive Factory by Konstantin Chelpan and his team. It is found in the BT-7M (BT-8), T-34, KV, IS and IS-10 (T-10) tanks, and by extension, the vehicles based on them, such as the SU-85 and SU-100 tank destroyers based on the T-34 and the ISU-122 and ISU-152 self-propelled guns based on the IS-2. Throughout its production life, output ranged from roughly 450-700 hp. V-2 with increased injection pressure and higher engine speed, 1939. Used in the KV-1 and KV-2. It produced 600 hp.",
                 CategoryID = 2
             },
             new Product
             {
                 ProductID = 15,
                 Name = "Kharkiv model V-2",
                 Price = 41789,
                 Stock = 78,
                 Description = "The Kharkiv model V-2 was a Soviet diesel tank V-12 engine designed at the Kharkiv Locomotive Factory by Konstantin Chelpan and his team. It is found in the BT-7M (BT-8), T-34, KV, IS and IS-10 (T-10) tanks, and by extension, the vehicles based on them, such as the SU-85 and SU-100 tank destroyers based on the T-34 and the ISU-122 and ISU-152 self-propelled guns based on the IS-2. Throughout its production life, output ranged from roughly 450-700 hp. Initial production version, 1937. Used in the BT-7M (BT-8).",
                 CategoryID = 2
             });


        }
    }

}
