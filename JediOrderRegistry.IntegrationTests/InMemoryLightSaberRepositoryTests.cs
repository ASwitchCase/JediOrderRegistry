using JediOrderRegistry.Api.Models;
using JediOrderRegistry.Api.Repositories;

namespace JediOrderRegistry.IntegrationTests;

public class InMemoryLightSaberRepositoryTests
{
    private readonly InMemoryLightSaberRepository _repository = new();

    [Fact]
    public async Task AddAsync_ShouldAddLightSaberToRepository()
    {
        // Arrange
        var lightSaber = new LightSaber 
        { 
            Name = "Anakin's Lightsaber", 
            Color = "Blue",
            CrystalType = "Kyber",
            HiltMaterial = "Durasteel",
            Manufacturer = "Jedi Temple",
            YearsInUse = 10
        };

        // Act
        var result = await _repository.AddAsync(lightSaber);

        // Assert
        Assert.NotEqual(Guid.Empty, result.Id);
        Assert.Equal("Anakin's Lightsaber", result.Name);
    }

    [Fact]
    public async Task AddAsync_ShouldGenerateIdIfEmpty()
    {
        // Arrange
        var lightSaber = new LightSaber 
        { 
            Name = "Luke's Lightsaber", 
            Color = "Green",
            CrystalType = "Kyber",
            HiltMaterial = "Durasteel",
            Manufacturer = "Obi-Wan",
            YearsInUse = 5
        };
        var originalId = lightSaber.Id;

        // Act
        var result = await _repository.AddAsync(lightSaber);

        // Assert
        Assert.NotEqual(originalId, result.Id);
        Assert.NotEqual(Guid.Empty, result.Id);
    }

    [Fact]
    public async Task GetOneAsync_ShouldReturnLightSaberWhenExists()
    {
        // Arrange
        var lightSaber = new LightSaber 
        { 
            Name = "Yoda's Lightsaber", 
            Color = "Green",
            CrystalType = "Kyber",
            HiltMaterial = "Durasteel",
            Manufacturer = "Jedi Temple",
            YearsInUse = 900
        };
        var added = await _repository.AddAsync(lightSaber);

        // Act
        var result = await _repository.GetOneAsync(added.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(added.Id, result.Id);
        Assert.Equal("Yoda's Lightsaber", result.Name);
    }

    [Fact]
    public async Task GetOneAsync_ShouldReturnNullWhenNotExists()
    {
        // Act
        var result = await _repository.GetOneAsync(Guid.NewGuid());

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllLightSabers()
    {
        // Arrange
        var ls1 = new LightSaber 
        { 
            Name = "Red Saber 1", 
            Color = "Red",
            CrystalType = "Synth",
            HiltMaterial = "Durasteel",
            Manufacturer = "Sith",
            YearsInUse = 3
        };
        var ls2 = new LightSaber 
        { 
            Name = "Red Saber 2", 
            Color = "Red",
            CrystalType = "Synth",
            HiltMaterial = "Durasteel",
            Manufacturer = "Sith",
            YearsInUse = 2
        };
        
        await _repository.AddAsync(ls1);
        await _repository.AddAsync(ls2);

        // Act
        var result = await _repository.GetAllAsync();

        // Assert
        var sabers = result.ToList();
        Assert.Equal(2, sabers.Count);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnEmptyWhenNoLightSabers()
    {
        // Act
        var result = await _repository.GetAllAsync();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateLightSaberWhenExists()
    {
        // Arrange
        var lightSaber = new LightSaber 
        { 
            Name = "Master's Saber", 
            Color = "Purple",
            CrystalType = "Kyber",
            HiltMaterial = "Durasteel",
            Manufacturer = "Custom",
            YearsInUse = 20
        };
        var added = await _repository.AddAsync(lightSaber);
        added.Color = "Silver";

        // Act
        var result = await _repository.UpdateAsync(added);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Silver", result.Color);
        var retrieved = await _repository.GetOneAsync(added.Id);
        Assert.Equal("Silver", retrieved!.Color);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNullWhenNotExists()
    {
        // Arrange
        var lightSaber = new LightSaber 
        { 
            Id = Guid.NewGuid(),
            Name = "Nonexistent", 
            Color = "Blue",
            CrystalType = "Kyber",
            HiltMaterial = "Durasteel",
            Manufacturer = "Unknown",
            YearsInUse = 0
        };

        // Act
        var result = await _repository.UpdateAsync(lightSaber);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNullWhenIdIsEmpty()
    {
        // Arrange
        var lightSaber = new LightSaber 
        { 
            Name = "Unknown", 
            Color = "Blue",
            CrystalType = "Kyber",
            HiltMaterial = "Durasteel",
            Manufacturer = "Unknown",
            YearsInUse = 0
        };

        // Act
        var result = await _repository.UpdateAsync(lightSaber);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveLightSaberWhenExists()
    {
        // Arrange
        var lightSaber = new LightSaber 
        { 
            Name = "Temporary Saber", 
            Color = "Green",
            CrystalType = "Kyber",
            HiltMaterial = "Durasteel",
            Manufacturer = "Jedi",
            YearsInUse = 1
        };
        var added = await _repository.AddAsync(lightSaber);

        // Act
        var deleted = await _repository.DeleteAsync(added.Id);

        // Assert
        Assert.True(deleted);
        var retrieved = await _repository.GetOneAsync(added.Id);
        Assert.Null(retrieved);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnFalseWhenNotExists()
    {
        // Act
        var result = await _repository.DeleteAsync(Guid.NewGuid());

        // Assert
        Assert.False(result);
    }
}
