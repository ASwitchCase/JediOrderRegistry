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

        // Lightsaber IDs
        public static readonly Guid AnakinSaberId = Guid.Parse("33333333-3333-3333-3333-333333333333");
        public static readonly Guid LukeSaberId = Guid.Parse("44444444-4444-4444-4444-444444444444");

        // Jedi IDs
        public static readonly Guid LukeId = Guid.Parse("55555555-5555-5555-5555-555555555555");
        public static readonly Guid ObiWanId = Guid.Parse("66666666-6666-6666-6666-666666666666");

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
            }
        };
    }
}
