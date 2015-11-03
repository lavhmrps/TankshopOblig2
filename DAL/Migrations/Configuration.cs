using Nettbutikk.Model;
using System.Data.Entity.Migrations;

namespace Nettbutikk.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<TankshopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TankshopDbContext";
        }

        protected override void Seed(TankshopDbContext context)
        {

            ////Postals
            //context.Postals.AddOrUpdate( new Postal {
            //    Zipcode = "0351",
            //    City = "Oslo"

            //},

            //new Postal {
            //    Zipcode = "0341",
            //    City = "Oslo"
            //});


            // Categories
            context.Categories.AddOrUpdate(new Category
            {
                CategoryId = 1,
                Name = "Tanks"
            },
            new Category
            {
                CategoryId = 2,
                Name = "Engines"
            },
            new Category
            {
                CategoryId = 3,
                Name = "Guns"
            }
            );

            // Tanks
            context.Products.AddOrUpdate(
            new Product
            {
                Id = 1,
                Name = "Tiger 1",
                Price = 500000,
                Stock = 5,
                Description = "Tiger I is the common name of a German heavy tank developed in 1942 and used in World War II. The final official German designation was Panzerkampfwagen VI Tiger Ausf. E, often shortened to Tiger. The Tiger I gave the Wehrmacht its first tank which mounted a KwK 36 88mm gun in an armoured fighting vehicle. The KwK 36 is not to be confused with the earlier and similar 8.8 cm Flak 36, a different weapon designed in parallel with the KwK 36 and firing the same ammunition (\"KwK\" denotes an armored vehicle gun, while \"Flak\" denotes anti-aircraft artillery). During the course of the war, the Tiger I saw combat on all German battlefronts. It was usually deployed in independent heavy tank battalions, which proved highly effective",
                CategoryId = 1,
                ImageUrl = "http://www.hsgalleries.com/gallery04/images/Tiger%20front1.jpg"
            }, new Product
            {
                Id = 2,
                Name = "Panther",
                Price = 760000,
                Stock = 5,
                Description = "he Panther was a German medium tank deployed during World War II from mid-1943 to the end of the European war in 1945. It was intended as a counter to the Soviet T-34, and as a replacement for the Panzer III and Panzer IV. While never replacing the latter, it served alongside it and the heavier Tiger I until the end of the war. While the Panther is considered one of the best tanks of World War II due to its excellent firepower and protection, it was less impressive in terms of mobility, reliability, and cost.",
                CategoryId = 1,
                ImageUrl = "http://aviatornut.com/images/Panther_Tank_Red_332.jpg"
            }, new Product
            {
                Id = 3,
                Name = "JagdPanther",
                Price = 50000,
                Stock = 5,
                Description = "The Jagdpanther was a tank destroyer built by Nazi Germany during World War II based on the chassis of the Panther tank. It entered service late in the war (1944) and saw service on the Eastern and Western Fronts. The Jagdpanther combined the very powerful 8.8 cm PaK 43 cannon of the Tiger II and the characteristically excellent armor and suspension of the Panther chassis, although it suffered from the general poor state of German ordnance production, maintenance and training in the later part of the war, which resulted in small production numbers, shortage in spare parts and poor crew readiness.",
                CategoryId = 1,
                ImageUrl = "http://www.themotorpool.net/v/vspfiles/photos/DRR60554-2.jpg"
            }, new Product
            {
                Id = 4,
                Name = "Sherman Firefly",
                Price = 50000,
                Stock = 5,
                Description = "The Sherman Firefly was a tank used by the United Kingdom in World War II. It was based on the US M4 Sherman but fitted with the powerful 3-inch (76.2 mm) calibre British 17-pounder anti-tank gun as its main weapon. Originally conceived as a stopgap until future British tank designs came into service, the Sherman Firefly became the most common vehicle with the 17-pounder in the war.",
                CategoryId = 1,
                ImageUrl = "http://cdn-frm-eu.wargaming.net/wot/eu/uploads/monthly_11_2014/post-507347053-0-33442400-1417183077.jpg"

            }, new Product
            {
                Id = 5,
                Name = "Churchill Tank",
                Price = 50000,
                Stock = 5,
                Description = "The Tank, Infantry, Mk IV (A22) was a British heavy infantry tank used in the Second World War, best known for its heavy armour, large longitudinal chassis with all-around tracks with multiple bogies, and its use as the basis of many specialist vehicles. It was one of the heaviest Allied tanks of the war.",
                CategoryId = 1,
                ImageUrl = "http://www.strijdbewijs.nl/hinder/C1.jpg"

            }, new Product
            {
                Id = 6,
                Name = "Light Tank Mk VI",
                Price = 50000,
                Stock = 5,
                Description = "The Tank, Light, Mk VI was a British light tank, produced by Vickers-Armstrong in the late 1930s, which saw service during World War II.",
                CategoryId = 1,
                ImageUrl = "http://modelsua.com/images/D/A72291.jpg"

            }, new Product
            {
                Id = 7,
                Name = "M4 Sherman",
                Price = 50000,
                Stock = 5,
                Description = "The M4 Sherman, officially Medium Tank, M4, was the most numerous battle tank used by the United States and some other Western Allies in World War II. It proved to be reliable and mobile. In spite of being outclassed in guns and armor thickness by German medium and heavy tanks late in the war, the M4 Sherman was cheaper to produce, more mechanically reliable, more capable of withstanding hostile terrain, faster, and more likely to get the first shot off in combat owing to the fast rotation of the turret.Thousands were distributed through the Lend - Lease program to the British Commonwealth and Soviet Union.The tank was named after the American Civil War General William Tecumseh Sherman by the British.",
                CategoryId = 1,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/c/cd/M4_Sherman_at_Utah_Beach.jpg"

            }, new Product
            {
                Id = 8,
                Name = "M26 Pershing",
                Price = 50000,
                Stock = 5,
                Description = "The Pershing was a medium tank of the United States Army. It was designated a heavy tank when it was first designed in World War II due to its 90mm gun, and its armor. The tank is named after General of the Armies John J. Pershing, who led the American Expeditionary Force in Europe in World War I. It was briefly used both in World War II and the Korean War.",
                CategoryId = 1,
                ImageUrl = "http://i.imgur.com/VskPxBB.jpg"

            }, new Product
            {
                Id = 9,
                Name = "M10 tank destroyer",
                Price = 50000,
                Stock = 5,
                Description = "The M10 tank destroyer was a United States tank destroyer of World War II based on the chassis of the M4 Sherman tank fitted with the 3-inch (76.2 mm) Gun M7. Formally 3-inch Gun Motor Carriage, M10, it was numerically the most important U.S. tank destroyer of World War II and combined a reasonably potent anti-tank weapon with a turreted platform. Despite the introduction of more-powerful types as replacements, it remained in service until the end of the war, and its chassis was later reused with a new turret to create the M36 Jackson, which used a 90mm gun instead of the 76.2mm gun.",
                CategoryId = 1,
                ImageUrl = "http://olive-drab.com/images/id_m10a1td_4is_pettit_120_20051202_700.jpg"
            });

            // Engines
            context.Products.AddOrUpdate(
            new Product
            {
                Id = 10,
                Name = "Wright R-975",
                Price = 47500,
                Stock = 8,
                Description = "The Wright R-975 Whirlwind was a series of nine-cylinder air-cooled radial aircraft engines built by the Wright Aeronautical division of Curtiss-Wright. These engines had a displacement of about 975 in� (16.0 L) and power ratings of 300-450 hp (225-335 kW). They were the largest members of the Wright Whirlwind engine family to be produced commercially, and they were also the most numerous.",
                CategoryId = 2,
                ImageUrl = "http://orig15.deviantart.net/b3da/f/2011/341/d/0/wright_continental_r975_by_sceptre63-d4ifi79.jpg"
            },
             new Product
             {
                 Id = 11,
                 Name = "Chrysler A57 multibank",
                 Price = 68189,
                 Stock = 48,
                 Description = "Created in 1941 as America entered World War II, the A57 Multibank engine was born out of the necessity for a rear-mounted tank engine to be developed and produced, in the shortest time possible, for use in both the 109 examples built of the M3A4 Medium Tank, and the 7,499 examples built of the successor M4A4 Medium tank, each of which had lengthened hulls to accommodate them.",
                 CategoryId = 2,
                 ImageUrl = "http://www.strijdbewijs.nl/tanks/sherman/bank.jpg"
             },
             new Product
             {
                 Id = 12,
                 Name = "Ford GAA engine",
                 Price = 41688,
                 Stock = 15,
                 Description = "The Ford GAA engine is an American all-aluminum 32-valve DOHC 60-degree V8 engine engineered and produced by the Ford Motor Company just before, and during, World War II. It featured twin Stromberg NA-Y5-G carburetors, dual magnetos and twin spark plugs making up a full dual ignition system, and crossflow induction. It displaces 1,100 cu in (18 l) and puts out well over 1,000 pound-feet (1,400 N�m) of torque from idle to 2600 rpm. The factory-rated output was 525 hp (391 kW) @ 2800 rpm. In terms of its capacity, the GAA was the largest mass-produced gasoline V8 engine in the world.",
                 CategoryId = 2,
                 ImageUrl = "http://www.fordgaaengine.com/GAA-03.jpg"
             },
             new Product
             {
                 Id = 13,
                 Name = "Kharkiv model V-2-34",
                 Price = 198689,
                 Stock = 81,
                 Description = "The Kharkiv model V-2 was a Soviet diesel tank V-12 engine designed at the Kharkiv Locomotive Factory by Konstantin Chelpan and his team. It is found in the BT-7M (BT-8), T-34, KV, IS and IS-10 (T-10) tanks, and by extension, the vehicles based on them, such as the SU-85 and SU-100 tank destroyers based on the T-34 and the ISU-122 and ISU-152 self-propelled guns based on the IS-2. Throughout its production life, output ranged from roughly 450-700 hp. V-2 with revised hull mounts, fuel and cooling connectors and refined clutch, 1939. Used in the T-34, SU-85 and SU-100. It produced 500 hp @ 1800 RPM.",
                 CategoryId = 2,
                 ImageUrl = "http://www.kampfpanzer.de/image/txt/v-2-34.jpg"
             },
             new Product
             {
                 Id = 14,
                 Name = "Kharkiv model V-2K",
                 Price = 61695,
                 Stock = 25,
                 Description = "The Kharkiv model V-2 was a Soviet diesel tank V-12 engine designed at the Kharkiv Locomotive Factory by Konstantin Chelpan and his team. It is found in the BT-7M (BT-8), T-34, KV, IS and IS-10 (T-10) tanks, and by extension, the vehicles based on them, such as the SU-85 and SU-100 tank destroyers based on the T-34 and the ISU-122 and ISU-152 self-propelled guns based on the IS-2. Throughout its production life, output ranged from roughly 450-700 hp. V-2 with increased injection pressure and higher engine speed, 1939. Used in the KV-1 and KV-2. It produced 600 hp.",
                 CategoryId = 2,
                 ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/f/ff/T34_engine_parola_2.jpg"
             },
             new Product
             {
                 Id = 15,
                 Name = "Kharkiv model V-2",
                 Price = 41789,
                 Stock = 78,
                 Description = "The Kharkiv model V-2 was a Soviet diesel tank V-12 engine designed at the Kharkiv Locomotive Factory by Konstantin Chelpan and his team. It is found in the BT-7M (BT-8), T-34, KV, IS and IS-10 (T-10) tanks, and by extension, the vehicles based on them, such as the SU-85 and SU-100 tank destroyers based on the T-34 and the ISU-122 and ISU-152 self-propelled guns based on the IS-2. Throughout its production life, output ranged from roughly 450-700 hp. Initial production version, 1937. Used in the BT-7M (BT-8).",
                 CategoryId = 2,
                 ImageUrl = "http://allabouttanks.com/wp-content/uploads/2015/01/v-2engine.jpg"
             });

            // Guns
            context.Products.AddOrUpdate(
            new Product
            {
                Id = 16,
                Name = "75 mm gun M2/M3",
                Price = 1568,
                Stock = 8,
                Description = "The US 75 mm gun tank gun M2 and the later M3 were the standard American tank guns of the Second World War, used primarily on the two main American medium tanks of the war, the M3 Lee (M2 or M3 gun) and the M4 Sherman (M3 gun).",
                CategoryId = 3,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/c/c5/M3_105mm_Howitzer.jpg"
            }, new Product
            {
                Id = 17,
                Name = "90 mm Gun M1/M2/M3",
                Price = 1568,
                Stock = 8,
                Description = "The 90 mm Gun M1/M2/M3 served as a primary heavy American anti-aircraft and anti-tank gun, playing a role similar to the renowned German 88 mm gun. It was 90 mm (3.5 in) in caliber, and had a 4.60 m (15 ft) barrel, 53 calibers in length. It was capable of firing a 90×600 mm R shell 17,823 m (58,474 ft) horizontally, or a maximum altitude of 10,380 m (34,060 ft).",
                CategoryId = 3,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/49/90_mm_gun_antitank_1.JPG"
            }, new Product
            {
                Id = 18,
                Name = "3-inch M1918 gun",
                Price = 1568,
                Stock = 8,
                Description = "The 3-inch M1918 gun was a United States 3-inch anti-aircraft gun that entered service in 1918 and served until it was finally superseded by the 3\" M3 gun in 1930.The M3 was subsequently replaced by the M1 90mm AA gun just prior to the opening of World War II.The M3 3\" gun was later adapted for the anti-tank role, serving as the main armament of the M10 tank destroyer during World War II.",
                CategoryId = 3,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/a/a8/Three_Inch_M-5_Gun.jpg"
            }, new Product
            {
                Id = 19,
                Name = "76 mm tank gun M1940 F-34",
                Price = 1568,
                Stock = 8,
                Description = "The 76 mm tank gun M1940 F-34 was a 76.2 mm Soviet tank gun used on the T-34/76 tank. A modified version of the gun, the 76 mm tank gun M1941 ZiS-5, was used on KV-1 tanks during World War II. Nowadays, the two versions are often referred to just by their factory designations, as \"F - 34\" and \"ZiS - 5\", respectively.",
                CategoryId = 3,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/a/a0/T-34-76_RB6.JPG"
            }, new Product
            {
                Id = 20,
                Name = "152-mm howitzer M1938 (M-10)",
                Price = 1568,
                Stock = 8,
                Description = "152-mm howitzer M1938 (M-10) was a Soviet 152.4 mm (6 inch) howitzer of World War II era. It was developed in 1937–1938 at the Motovilikha Mechanical Plant by a team headed by F. F. Petrov. Although production of the gun was stopped in 1941, it saw combat with the Red Army until the end of World War II and remained in service until the 1950s. Captured pieces were used by Wehrmacht and the Finnish Army. The latter kept the M-10 in service until 2000. In a tank-mounted variant, M-10T, the gun was mounted on the KV-2 heavy tank.",
                CategoryId = 3,
                ImageUrl = "http://upload.wikimedia.org/wikipedia/commons/1/12/122-mm_howitzer_M1938_001.jpg"
            }, new Product
            {
                Id = 21,
                Name = "85 mm air defense gun M1939 (52-K)",
                Price = 1568,
                Stock = 8,
                Description = "The 85 mm air defense gun M1939 (52-K) was an 85-mm Soviet air defense gun, developed under guidance of leading Soviet designers M. N. Loginov and G. D. Dorokhin. This gun was successfully used throughout the German-Soviet War against level bombers and other high- and medium-altitude targets. In emergencies they were utilized as powerful anti-tank weapons. The barrel of the 52-K was the basis for the family of 85-mm Soviet tank guns. Crews of 85-mm AD guns shot down 4,047 Axis aircraft. The mean quantity of 85-mm ammunition required to shoot down one enemy plane was 598 rounds. After the war some 52-Ks were refitted for peaceful purposes as anti-avalanche guns in mountainous terrain.",
                CategoryId = 3,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/0/09/85_mm_air_defense_gun_M1939_(52-K)_11.jpg"
            });



            ////OrderLines
            //context.Orderlines.AddOrUpdate(new Orderline
            //{
            //    ProductId = 20,
            //    Count = 3,
            //    OrderId = 3,

            //},

            //new Orderline
            //{
            //    ProductId = 10,
            //    Count = 2,
            //    OrderId = 3
            //},

            //new Orderline
            //{
            //    ProductId = 3,
            //    Count = 1,
            //    OrderId = 3
            //},

            //new Orderline
            //{
            //    ProductId = 10,
            //    Count = 2,
            //    OrderId = 4

            //},

            //new Orderline
            //{
            //    ProductId = 19,
            //    Count = 1,
            //    OrderId = 4

            //},

            //new Orderline
            //{
            //    ProductId = 16,
            //    Count = 1,
            //    OrderId = 5

            //},

            //new Orderline
            //{
            //    ProductId = 21,
            //    Count = 2,
            //    OrderId = 6

            //},

            //new Orderline
            //{
            //    ProductId = 9,
            //    Count = 4,
            //    OrderId = 6

            //},

            //new Orderline
            //{
            //    ProductId = 13,
            //    Count = 3,
            //    OrderId = 1

            //},


            //new Orderline
            //{
            //    ProductId = 12,
            //    Count = 2,
            //    OrderId = 1

            //},

            //new Orderline
            //{
            //    ProductId = 4,
            //    Count = 1,
            //    OrderId = 2

            //},

            //new Orderline
            //{
            //    ProductId = 12,
            //    Count = 5,
            //    OrderId = 2

            //});

        }
    }

}
