# Jedi Order Registry

A .NET 10.0 REST API for managing the Jedi Order, including Jedi profiles, their lightsabers, and their homeworlds.

## Project Overview

This project demonstrates a clean architecture approach with:
- **ASP.NET Core Minimal APIs** for lightweight HTTP endpoints
- **Repository Pattern** with in-memory data stores for persistence
- **Async/Await** for non-blocking operations
- **Comprehensive Unit Tests** using xUnit

## Architecture

### Project Structure

```
JediOrderRegistry/
├── JediOrderRegistry.Api/              # Main API project
│   ├── Models/                         # Domain models
│   │   ├── JediModel.cs               # Jedi entity
│   │   ├── LightSaber.cs              # LightSaber entity
│   │   └── Homeworld.cs               # Homeworld entity
│   ├── Repositories/                  # Data access layer
│   │   ├── Interfaces/
│   │   │   ├── IJediRepository.cs
│   │   │   ├── ILightSaberRepository.cs
│   │   │   └── IHomeworldRepository.cs
│   │   ├── InMemoryJediRepository.cs
│   │   ├── InMemoryLightSaberRepository.cs
│   │   └── InMemoryHomeworldRepository.cs
│   ├── Endpoints/                     # API route handlers
│   │   ├── JediEndpoints.cs
│   │   ├── LightSaberEndpoints.cs
│   │   └── HomeWorldEndpoints.cs
│   ├── Program.cs                     # Application entry point
│   └── appsettings.json              # Configuration
├── JediOrderRegistry.IntegrationTests/ # Test project
│   ├── InMemoryJediRepositoryTests.cs
│   ├── InMemoryLightSaberRepositoryTests.cs
│   └── InMemoryHomeworldRepositoryTests.cs
└── JediOrderRegistry.sln              # Solution file
```

## Models

### JediModel
Represents a Jedi in the registry.

**Properties:**
- `Id` (Guid) - Unique identifier
- `Name` (string, required) - Jedi's name
- `Rank` (string, required) - Rank (e.g., "Master", "Knight", "Apprentice")
- `Lightsaber` (Guid?) - Reference to a LightSaber
- `MidichlorianCount` (int) - Midi-chlorian count
- `Species` (string?) - Species type
- `Homeworld` (Guid?) - Reference to a Homeworld
- `Age` (int) - Age in years
- `YearsOfService` (int) - Years in the Jedi Order
- `Master` (Guid?) - Reference to master Jedi
- `Padawan` (Guid?) - Reference to apprentice Jedi
- `CurrentAssignment` (string?) - Current mission or post
- `IsActive` (bool) - Whether actively serving

### LightSaber
Represents a lightsaber weapon.

**Properties:**
- `Id` (Guid) - Unique identifier
- `Name` (string, required) - Lightsaber name
- `Color` (string, required) - Blade color
- `CrystalType` (string, required) - Type of crystal used
- `Length` (double) - Blade length in cm
- `Weight` (double) - Weight in grams
- `HiltMaterial` (string, required) - Material of the hilt
- `Manufacturer` (string, required) - Creator/manufacturer
- `YearsInUse` (int, required) - Years in service
- `OwnerId` (Guid?) - Reference to Jedi owner

### Homeworld
Represents a Jedi's homeworld.

**Properties:**
- `Id` (Guid) - Unique identifier
- `Name` (string, required) - Planet name
- `System` (string, required) - Star system
- `Sector` (string, required) - Galactic sector
- `Population` (long) - Total population
- `Climate` (string?) - Climate type(s)
- `PrimarySpecies` (string?) - Primary sentient species
- `Gravity` (double) - Gravity relative to standard

## API Endpoints

### Jedi Endpoints

**Base URL:** `/api/jedi`

#### GET /api/jedi
Retrieves all Jedi in the registry.

**Response:** 200 OK
```json
[
  {
    "id": "550e8400-e29b-41d4-a716-446655440000",
    "name": "Luke Skywalker",
    "rank": "Jedi Knight",
    "midichlorianCount": 14500,
    "isActive": true
  }
]
```

#### GET /api/jedi/{id}
Retrieves a specific Jedi by ID.

**Parameters:**
- `id` (guid) - Jedi's unique identifier

**Response:** 
- 200 OK - Returns the Jedi object
- 404 Not Found - Jedi does not exist

#### POST /api/jedi
Creates a new Jedi entry.

**Request Body:**
```json
{
  "name": "Obi-Wan Kenobi",
  "rank": "Master",
  "midichlorianCount": 13600,
  "species": "Human",
  "age": 45,
  "yearsOfService": 25,
  "isActive": true
}
```

**Response:** 201 Created
- Location header: `/api/jedi/{id}`
- Returns created Jedi object with generated ID

#### PUT /api/jedi/{id}
Updates an existing Jedi.

**Parameters:**
- `id` (guid) - Jedi's unique identifier

**Request Body:**
```json
{
  "name": "Obi-Wan Kenobi",
  "rank": "Grand Master",
  "midichlorianCount": 13600,
  "isActive": true
}
```

**Response:**
- 204 No Content - Update successful
- 404 Not Found - Jedi does not exist

#### DELETE /api/jedi/{id}
Deletes a Jedi from the registry.

**Parameters:**
- `id` (guid) - Jedi's unique identifier

**Response:**
- 204 No Content - Deletion successful
- 404 Not Found - Jedi does not exist

---

### LightSaber Endpoints

**Base URL:** `/api/lightsabers`

#### GET /api/lightsabers
Retrieves all lightsabers in the registry.

**Response:** 200 OK
```json
[
  {
    "id": "650e8400-e29b-41d4-a716-446655440000",
    "name": "Luke's Lightsaber",
    "color": "Green",
    "crystalType": "Kyber",
    "hiltMaterial": "Durasteel",
    "manufacturer": "Obi-Wan",
    "yearsInUse": 5
  }
]
```

#### GET /api/lightsabers/{id}
Retrieves a specific lightsaber by ID.

**Parameters:**
- `id` (guid) - Lightsaber's unique identifier

**Response:**
- 200 OK - Returns the lightsaber object
- 404 Not Found - Lightsaber does not exist

#### POST /api/lightsabers
Creates a new lightsaber entry.

**Request Body:**
```json
{
  "name": "Anakin's Lightsaber",
  "color": "Blue",
  "crystalType": "Kyber",
  "length": 27.5,
  "weight": 2100,
  "hiltMaterial": "Durasteel",
  "manufacturer": "Jedi Temple",
  "yearsInUse": 10,
  "ownerId": "550e8400-e29b-41d4-a716-446655440000"
}
```

**Response:** 201 Created
- Location header: `/api/lightsabers/{id}`
- Returns created lightsaber object with generated ID

#### PUT /api/lightsabers/{id}
Updates an existing lightsaber.

**Parameters:**
- `id` (guid) - Lightsaber's unique identifier

**Request Body:**
```json
{
  "name": "Anakin's Lightsaber",
  "color": "Red",
  "crystalType": "Synth",
  "hiltMaterial": "Durasteel",
  "manufacturer": "Sith",
  "yearsInUse": 15,
  "ownerId": "550e8400-e29b-41d4-a716-446655440000"
}
```

**Response:**
- 204 No Content - Update successful
- 404 Not Found - Lightsaber does not exist

#### DELETE /api/lightsabers/{id}
Deletes a lightsaber from the registry.

**Parameters:**
- `id` (guid) - Lightsaber's unique identifier

**Response:**
- 204 No Content - Deletion successful
- 404 Not Found - Lightsaber does not exist

---

### Homeworld Endpoints

**Base URL:** `/api/homeworlds`

#### GET /api/homeworlds
Retrieves all homeworlds in the registry.

**Response:** 200 OK
```json
[
  {
    "id": "750e8400-e29b-41d4-a716-446655440000",
    "name": "Tatooine",
    "system": "Tatoo",
    "sector": "Arkanis",
    "population": 200000000,
    "climate": "Desert",
    "primarySpecies": "Human",
    "gravity": 1.15
  }
]
```

#### GET /api/homeworlds/{id}
Retrieves a specific homeworld by ID.

**Parameters:**
- `id` (guid) - Homeworld's unique identifier

**Response:**
- 200 OK - Returns the homeworld object
- 404 Not Found - Homeworld does not exist

#### POST /api/homeworlds
Creates a new homeworld entry.

**Request Body:**
```json
{
  "name": "Naboo",
  "system": "Naboo",
  "sector": "Chommell",
  "population": 5200000000,
  "climate": "Temperate",
  "primarySpecies": "Human",
  "gravity": 1.07
}
```

**Response:** 201 Created
- Location header: `/api/homeworlds/{id}`
- Returns created homeworld object with generated ID

#### PUT /api/homeworlds/{id}
Updates an existing homeworld.

**Parameters:**
- `id` (guid) - Homeworld's unique identifier

**Request Body:**
```json
{
  "name": "Coruscant",
  "system": "Coruscant",
  "sector": "Core",
  "population": 1000000000000,
  "climate": "Temperate",
  "primarySpecies": "Human",
  "gravity": 1.0
}
```

**Response:**
- 204 No Content - Update successful
- 404 Not Found - Homeworld does not exist

#### DELETE /api/homeworlds/{id}
Deletes a homeworld from the registry.

**Parameters:**
- `id` (guid) - Homeworld's unique identifier

**Response:**
- 204 No Content - Deletion successful
- 404 Not Found - Homeworld does not exist

---

## Building and Running

### Prerequisites
- .NET 10.0 SDK or later
- A terminal or command prompt

### Build the Project

```bash
dotnet build JediOrderRegistry.sln
```

### Run the API

```bash
dotnet run --project JediOrderRegistry.Api/JediOrderRegistry.Api.csproj
```

The API will start on `https://localhost:5001` (or similar, check console output for exact URL).

### Run Tests

```bash
dotnet test JediOrderRegistry.IntegrationTests
```

**Test Results:**
- 34 total tests across 3 test classes
- Full coverage of CRUD operations for all three repositories
- All tests currently passing ✓

### Test Coverage

Each repository has comprehensive tests covering:
- **Add operations** - With and without explicit ID generation
- **Get operations** - Single item retrieval and full collection retrieval
- **Update operations** - Success and failure scenarios
- **Delete operations** - Removal and NotFound handling
- **Edge cases** - Empty collections, non-existent IDs

## Technology Stack

- **Framework:** ASP.NET Core 10.0
- **Language:** C# 13
- **API Style:** Minimal APIs
- **Testing:** xUnit 2.9.3
- **Runtime:** .NET 10.0
- **Data Storage:** In-memory (ConcurrentDictionary)

## Design Patterns

### Repository Pattern
Abstracts data access through `IHomeworldRepository`, `IJediRepository`, and `ILightSaberRepository` interfaces, allowing easy swapping of storage implementations.

### Dependency Injection
All repositories are registered in the DI container and injected into endpoint handlers via `Program.cs`.

### Async/Await
All repository methods and endpoints use async/await for efficient I/O operations and scalability.

### Minimal APIs
Uses ASP.NET Core's lightweight Minimal API approach with route groups and fluent configuration.

## Future Enhancements

- [ ] Database persistence (Entity Framework Core with SQL Server/PostgreSQL)
- [ ] Authentication and Authorization
- [ ] Input validation with FluentValidation
- [ ] Swagger/OpenAPI documentation
- [ ] Logging and error handling middleware
- [ ] Pagination for large collections
- [ ] Filtering and search capabilities
- [ ] API versioning
- [ ] Docker containerization

## License

Educational project for .NET practice.
