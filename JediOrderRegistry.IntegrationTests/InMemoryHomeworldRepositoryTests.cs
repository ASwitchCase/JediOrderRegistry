using JediOrderRegistry.Api.Models;
using JediOrderRegistry.Api.Repositories;

namespace JediOrderRegistry.IntegrationTests;

public class InMemoryHomeworldRepositoryTests
{
    private readonly InMemoryHomeworldRepository _repository = new();

    [Fact]
    public async Task AddAsync_ShouldAddHomeworldToRepository()
    {
        // Arrange
        var homeworld = new Homeworld 
        { 
            Name = "Tatooine", 
            System = "Tatoo",
            Sector = "Arkanis"
        };

        // Act
        var result = await _repository.AddAsync(homeworld);

        // Assert
        Assert.NotEqual(Guid.Empty, result.Id);
        Assert.Equal("Tatooine", result.Name);
    }

    [Fact]
    public async Task AddAsync_ShouldGenerateIdIfEmpty()
    {
        // Arrange
        var homeworld = new Homeworld 
        { 
            Name = "Naboo", 
            System = "Naboo",
            Sector = "Chommell"
        };
        var originalId = homeworld.Id;

        // Act
        var result = await _repository.AddAsync(homeworld);

        // Assert
        Assert.NotEqual(originalId, result.Id);
        Assert.NotEqual(Guid.Empty, result.Id);
    }

    [Fact]
    public async Task GetOneAsync_ShouldReturnHomeworldWhenExists()
    {
        // Arrange
        var homeworld = new Homeworld 
        { 
            Name = "Coruscant", 
            System = "Coruscant",
            Sector = "Core",
            Population = 1000000000000
        };
        var added = await _repository.AddAsync(homeworld);

        // Act
        var result = await _repository.GetOneAsync(added.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(added.Id, result.Id);
        Assert.Equal("Coruscant", result.Name);
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
    public async Task GetAllAsync_ShouldReturnAllHomeworlds()
    {
        // Arrange
        var hw1 = new Homeworld { Name = "Dagobah", System = "Dagobah", Sector = "Outer Rim" };
        var hw2 = new Homeworld { Name = "Kashyyyk", System = "Kashyyyk", Sector = "Mytaranor" };
        
        await _repository.AddAsync(hw1);
        await _repository.AddAsync(hw2);

        // Act
        var result = await _repository.GetAllAsync();

        // Assert
        var worlds = result.ToList();
        Assert.Equal(2, worlds.Count);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnEmptyWhenNoHomeworlds()
    {
        // Act
        var result = await _repository.GetAllAsync();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateHomeworldWhenExists()
    {
        // Arrange
        var homeworld = new Homeworld 
        { 
            Name = "Geonosis", 
            System = "Geonosis",
            Sector = "Outer Rim",
            Population = 100000000
        };
        var added = await _repository.AddAsync(homeworld);
        added.Climate = "Desert";

        // Act
        var result = await _repository.UpdateAsync(added);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Desert", result.Climate);
        var retrieved = await _repository.GetOneAsync(added.Id);
        Assert.Equal("Desert", retrieved!.Climate);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNullWhenNotExists()
    {
        // Arrange
        var homeworld = new Homeworld 
        { 
            Id = Guid.NewGuid(),
            Name = "Unknown", 
            System = "Unknown",
            Sector = "Unknown"
        };

        // Act
        var result = await _repository.UpdateAsync(homeworld);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNullWhenIdIsEmpty()
    {
        // Arrange
        var homeworld = new Homeworld 
        { 
            Name = "Unknown", 
            System = "Unknown",
            Sector = "Unknown"
        };

        // Act
        var result = await _repository.UpdateAsync(homeworld);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveHomeworldWhenExists()
    {
        // Arrange
        var homeworld = new Homeworld 
        { 
            Name = "Mustafar", 
            System = "Mustafar",
            Sector = "Outer Rim"
        };
        var added = await _repository.AddAsync(homeworld);

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
