using System;
using System.Collections.Generic;
using JediOrderRegistry.Api.Models;

namespace JediOrderRegistry.Api.Repositories
{
    internal static class SeedData
    {
        // Homeworld IDs
        public static readonly Guid TatooineId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        public static readonly Guid NabooId = Guid.Parse("22222222-2222-2222-2222-222222222222");
        public static readonly Guid DagobahId = Guid.Parse("33333333-3333-3333-3333-333333333333");
        public static readonly Guid HothId = Guid.Parse("44444444-4444-4444-4444-444444444444");
        public static readonly Guid EndorId = Guid.Parse("55555555-5555-5555-5555-555555555555");
        public static readonly Guid MustaferId = Guid.Parse("66666666-6666-6666-6666-666666666666");
        public static readonly Guid GenosisId = Guid.Parse("77777777-7777-7777-7777-777777777777");
        public static readonly Guid CoruscantId = Guid.Parse("88888888-8888-8888-8888-888888888888");
        public static readonly Guid KaminoId = Guid.Parse("99999999-9999-9999-9999-999999999999");
        public static readonly Guid UTapauId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        public static readonly Guid YavinId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        public static readonly Guid ScarifId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");

        // Lightsaber IDs
        public static readonly Guid AnakinSaberId = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");
        public static readonly Guid LukeSaberId = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee");
        public static readonly Guid YodaSaberId = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");
        public static readonly Guid MaceSaberId = Guid.Parse("11111111-2222-3333-4444-555555555555");
        public static readonly Guid FemaleSaberId = Guid.Parse("11111111-2222-3333-4444-666666666666");
        public static readonly Guid Ventress1SaberId = Guid.Parse("11111111-2222-3333-4444-777777777777");
        public static readonly Guid Ventress2SaberId = Guid.Parse("11111111-2222-3333-4444-888888888888");
        public static readonly Guid AsajjSaberId = Guid.Parse("11111111-2222-3333-4444-999999999999");
        public static readonly Guid CulpSaberId = Guid.Parse("11111111-2222-3333-4444-aaaaaaaaaaaa");
        public static readonly Guid Starkiller1SaberId = Guid.Parse("11111111-2222-3333-4444-bbbbbbbbbbbb");
        public static readonly Guid Starkiller2SaberId = Guid.Parse("11111111-2222-3333-4444-cccccccccccc");
        public static readonly Guid KyloSaberId = Guid.Parse("11111111-2222-3333-4444-dddddddddddd");

        // Jedi IDs
        public static readonly Guid LukeId = Guid.Parse("11111111-3333-5555-7777-999999999999");
        public static readonly Guid ObiWanId = Guid.Parse("22222222-4444-6666-8888-aaaaaaaaaaaa");
        public static readonly Guid YodaId = Guid.Parse("33333333-5555-7777-9999-bbbbbbbbbbbb");
        public static readonly Guid MaceId = Guid.Parse("44444444-6666-8888-aaaa-cccccccccccc");
        public static readonly Guid AhsokaId = Guid.Parse("55555555-7777-9999-bbbb-dddddddddddd");
        public static readonly Guid KitFistoId = Guid.Parse("66666666-8888-aaaa-cccc-eeeeeeeeeeee");
        public static readonly Guid PloKoonId = Guid.Parse("77777777-9999-bbbb-dddd-ffffffffffff");
        public static readonly Guid ColemanId = Guid.Parse("88888888-aaaa-cccc-eeee-111111111111");
        public static readonly Guid DepaId = Guid.Parse("99999999-bbbb-dddd-ffff-222222222222");
        public static readonly Guid SargestId = Guid.Parse("aaaaaaaa-cccc-eeee-1111-333333333333");
        public static readonly Guid EvanPiellId = Guid.Parse("bbbbbbbb-dddd-ffff-2222-444444444444");
        public static readonly Guid StormanId = Guid.Parse("cccccccc-eeee-1111-3333-555555555555");

        public static readonly List<Homeworld> Homeworlds = new()
        {
            new Homeworld
            {
                Id = TatooineId,
                Name = "Tatooine",
                System = "Tatoo",
                Sector = "Arkanis",
                Population = 200000000,
                Climate = "Desert",
                PrimarySpecies = "Human",
                Gravity = 1.15
            },
            new Homeworld
            {
                Id = NabooId,
                Name = "Naboo",
                System = "Naboo",
                Sector = "Chommell",
                Population = 5200000000,
                Climate = "Temperate",
                PrimarySpecies = "Human",
                Gravity = 1.07
            },
            new Homeworld
            {
                Id = DagobahId,
                Name = "Dagobah",
                System = "Dagoba",
                Sector = "Outer Rim",
                Population = 50000,
                Climate = "Swamp",
                PrimarySpecies = "Unknown",
                Gravity = 0.88
            },
            new Homeworld
            {
                Id = HothId,
                Name = "Hoth",
                System = "Oth",
                Sector = "Outer Rim",
                Population = 0,
                Climate = "Frozen",
                PrimarySpecies = "N/A",
                Gravity = 1.10
            },
            new Homeworld
            {
                Id = EndorId,
                Name = "Endor",
                System = "Endor",
                Sector = "Outer Rim",
                Population = 30000000,
                Climate = "Forest",
                PrimarySpecies = "Ewok",
                Gravity = 0.85
            },
            new Homeworld
            {
                Id = MustaferId,
                Name = "Mustafar",
                System = "Mustafar",
                Sector = "Outer Rim",
                Population = 100000,
                Climate = "Volcanic",
                PrimarySpecies = "Human",
                Gravity = 1.27
            },
            new Homeworld
            {
                Id = GenosisId,
                Name = "Geonosis",
                System = "Geonosis",
                Sector = "Outer Rim",
                Population = 100000000,
                Climate = "Desert",
                PrimarySpecies = "Geonosian",
                Gravity = 0.86
            },
            new Homeworld
            {
                Id = CoruscantId,
                Name = "Coruscant",
                System = "Coruscant",
                Sector = "Core",
                Population = 1000000000000,
                Climate = "Temperate",
                PrimarySpecies = "Human",
                Gravity = 1.01
            },
            new Homeworld
            {
                Id = KaminoId,
                Name = "Kamino",
                System = "Kamino",
                Sector = "Outer Rim",
                Population = 1000000000,
                Climate = "Aquatic",
                PrimarySpecies = "Kaminoan",
                Gravity = 0.98
            },
            new Homeworld
            {
                Id = UTapauId,
                Name = "Utapau",
                System = "Utapau",
                Sector = "Outer Rim",
                Population = 95000000,
                Climate = "Arid",
                PrimarySpecies = "Utapauan",
                Gravity = 0.92
            },
            new Homeworld
            {
                Id = YavinId,
                Name = "Yavin",
                System = "Yavin",
                Sector = "Outer Rim",
                Population = 0,
                Climate = "Jungle",
                PrimarySpecies = "N/A",
                Gravity = 0.75
            },
            new Homeworld
            {
                Id = ScarifId,
                Name = "Scarif",
                System = "Scarif",
                Sector = "Outer Rim",
                Population = 50000000,
                Climate = "Tropical",
                PrimarySpecies = "Human",
                Gravity = 0.89
            }
        };

        public static readonly List<LightSaber> LightSabers = new()
        {
            new LightSaber
            {
                Id = AnakinSaberId,
                Name = "Anakin's Lightsaber",
                Color = "Blue",
                CrystalType = "Kyber",
                Length = 27.5,
                Weight = 2100,
                HiltMaterial = "Durasteel",
                Manufacturer = "Jedi Temple",
                YearsInUse = 10,
                OwnerId = ObiWanId
            },
            new LightSaber
            {
                Id = LukeSaberId,
                Name = "Luke's Lightsaber",
                Color = "Green",
                CrystalType = "Kyber",
                Length = 29.0,
                Weight = 2000,
                HiltMaterial = "Durasteel",
                Manufacturer = "Obi-Wan",
                YearsInUse = 5,
                OwnerId = LukeId
            },
            new LightSaber
            {
                Id = YodaSaberId,
                Name = "Yoda's Lightsaber",
                Color = "Green",
                CrystalType = "Kyber",
                Length = 21.5,
                Weight = 1450,
                HiltMaterial = "Durasteel",
                Manufacturer = "Jedi Temple",
                YearsInUse = 60,
                OwnerId = YodaId
            },
            new LightSaber
            {
                Id = MaceSaberId,
                Name = "Mace Windu's Lightsaber",
                Color = "Purple",
                CrystalType = "Kyber",
                Length = 28.0,
                Weight = 2050,
                HiltMaterial = "Durasteel",
                Manufacturer = "Jedi Temple",
                YearsInUse = 40,
                OwnerId = MaceId
            },
            new LightSaber
            {
                Id = FemaleSaberId,
                Name = "Ahsoka's Shoto Saber",
                Color = "White",
                CrystalType = "Kyber",
                Length = 20.0,
                Weight = 1600,
                HiltMaterial = "Aluminium",
                Manufacturer = "Ahsoka Tano",
                YearsInUse = 8,
                OwnerId = AhsokaId
            },
            new LightSaber
            {
                Id = Ventress1SaberId,
                Name = "Asajj Ventress Saber 1",
                Color = "Red",
                CrystalType = "Synthetic",
                Length = 26.0,
                Weight = 2200,
                HiltMaterial = "Durasteel",
                Manufacturer = "Unknown",
                YearsInUse = 15,
                OwnerId = null
            },
            new LightSaber
            {
                Id = Ventress2SaberId,
                Name = "Asajj Ventress Saber 2",
                Color = "Red",
                CrystalType = "Synthetic",
                Length = 26.0,
                Weight = 2200,
                HiltMaterial = "Durasteel",
                Manufacturer = "Unknown",
                YearsInUse = 15,
                OwnerId = null
            },
            new LightSaber
            {
                Id = AsajjSaberId,
                Name = "Kit Fisto's Lightsaber",
                Color = "Green",
                CrystalType = "Kyber",
                Length = 28.5,
                Weight = 1950,
                HiltMaterial = "Durasteel",
                Manufacturer = "Jedi Temple",
                YearsInUse = 30,
                OwnerId = KitFistoId
            },
            new LightSaber
            {
                Id = CulpSaberId,
                Name = "Plo Koon's Lightsaber",
                Color = "Blue",
                CrystalType = "Kyber",
                Length = 27.0,
                Weight = 2050,
                HiltMaterial = "Durasteel",
                Manufacturer = "Jedi Temple",
                YearsInUse = 45,
                OwnerId = PloKoonId
            },
            new LightSaber
            {
                Id = Starkiller1SaberId,
                Name = "Coleman Kcaj's Lightsaber",
                Color = "Blue",
                CrystalType = "Kyber",
                Length = 28.5,
                Weight = 2100,
                HiltMaterial = "Durasteel",
                Manufacturer = "Jedi Temple",
                YearsInUse = 50,
                OwnerId = ColemanId
            },
            new LightSaber
            {
                Id = Starkiller2SaberId,
                Name = "Depa Billaba's Lightsaber",
                Color = "Blue",
                CrystalType = "Kyber",
                Length = 27.5,
                Weight = 2000,
                HiltMaterial = "Durasteel",
                Manufacturer = "Jedi Temple",
                YearsInUse = 32,
                OwnerId = DepaId
            },
            new LightSaber
            {
                Id = KyloSaberId,
                Name = "Sargest Tapal's Lightsaber",
                Color = "Blue",
                CrystalType = "Kyber",
                Length = 28.0,
                Weight = 2100,
                HiltMaterial = "Durasteel",
                Manufacturer = "Jedi Temple",
                YearsInUse = 28,
                OwnerId = SargestId
            }
        };

        public static readonly List<JediModel> Jedi = new()
        {
            new JediModel
            {
                Id = LukeId,
                Name = "Luke Skywalker",
                Rank = "Jedi Knight",
                MidichlorianCount = 14500,
                Species = "Human",
                Age = 28,
                YearsOfService = 10,
                IsActive = true,
                Homeworld = TatooineId,
                Lightsaber = LukeSaberId
            },
            new JediModel
            {
                Id = ObiWanId,
                Name = "Obi-Wan Kenobi",
                Rank = "Master",
                MidichlorianCount = 13600,
                Species = "Human",
                Age = 57,
                YearsOfService = 35,
                IsActive = true,
                Homeworld = NabooId,
                Lightsaber = AnakinSaberId
            },
            new JediModel
            {
                Id = YodaId,
                Name = "Yoda",
                Rank = "Grand Master",
                MidichlorianCount = 17700,
                Species = "Yoda's Species",
                Age = 900,
                YearsOfService = 880,
                IsActive = true,
                Homeworld = DagobahId,
                Lightsaber = YodaSaberId
            },
            new JediModel
            {
                Id = MaceId,
                Name = "Mace Windu",
                Rank = "Master",
                MidichlorianCount = 14000,
                Species = "Human",
                Age = 47,
                YearsOfService = 30,
                IsActive = true,
                Homeworld = CoruscantId,
                Lightsaber = MaceSaberId
            },
            new JediModel
            {
                Id = AhsokaId,
                Name = "Ahsoka Tano",
                Rank = "Jedi Knight",
                MidichlorianCount = 13500,
                Species = "Togruta",
                Age = 32,
                YearsOfService = 20,
                IsActive = true,
                Homeworld = CoruscantId,
                Lightsaber = FemaleSaberId
            },
            new JediModel
            {
                Id = KitFistoId,
                Name = "Kit Fisto",
                Rank = "Master",
                MidichlorianCount = 13200,
                Species = "Nautolan",
                Age = 39,
                YearsOfService = 28,
                IsActive = true,
                Homeworld = CoruscantId,
                Lightsaber = AsajjSaberId
            },
            new JediModel
            {
                Id = PloKoonId,
                Name = "Plo Koon",
                Rank = "Master",
                MidichlorianCount = 13600,
                Species = "Kel Dor",
                Age = 57,
                YearsOfService = 42,
                IsActive = true,
                Homeworld = CoruscantId,
                Lightsaber = CulpSaberId
            },
            new JediModel
            {
                Id = ColemanId,
                Name = "Coleman Kcaj",
                Rank = "Master",
                MidichlorianCount = 13400,
                Species = "Human",
                Age = 61,
                YearsOfService = 48,
                IsActive = true,
                Homeworld = CoruscantId,
                Lightsaber = Starkiller1SaberId
            },
            new JediModel
            {
                Id = DepaId,
                Name = "Depa Billaba",
                Rank = "Master",
                MidichlorianCount = 13000,
                Species = "Chalactan",
                Age = 35,
                YearsOfService = 24,
                IsActive = true,
                Homeworld = CoruscantId,
                Lightsaber = Starkiller2SaberId
            },
            new JediModel
            {
                Id = SargestId,
                Name = "Sargest Tapal",
                Rank = "Master",
                MidichlorianCount = 13100,
                Species = "Aayla Secura",
                Age = 44,
                YearsOfService = 32,
                IsActive = true,
                Homeworld = CoruscantId,
                Lightsaber = KyloSaberId
            },
            new JediModel
            {
                Id = EvanPiellId,
                Name = "Evan Piell",
                Rank = "Master",
                MidichlorianCount = 13300,
                Species = "Human",
                Age = 52,
                YearsOfService = 38,
                IsActive = true,
                Homeworld = CoruscantId,
                Lightsaber = null
            },
            new JediModel
            {
                Id = StormanId,
                Name = "Stass Allie",
                Rank = "Master",
                MidichlorianCount = 13200,
                Species = "Human",
                Age = 49,
                YearsOfService = 35,
                IsActive = true,
                Homeworld = CoruscantId,
                Lightsaber = null
            }
        };
    }
}
