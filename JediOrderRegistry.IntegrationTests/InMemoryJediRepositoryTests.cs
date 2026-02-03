using JediOrderRegistry.Api.Models;
using JediOrderRegistry.Api.Repositories;

namespace JediOrderRegistry.IntegrationTests;

public class InMemoryJediRepositoryTests
{
    private readonly InMemoryJediRepository _repository = new();

    [Fact]
    public async Task AddAsync_ShouldAddJediToRepository()
    {
        // Arrange
        var jedi = new JediModel 
        { 
            Name = "Luke Skywalker", 
            Rank = "Jedi Knight",
            MidichlorianCount = 14500
        };

        // Act
        var result = await _repository.AddAsync(jedi);

        // Assert
        Assert.NotEqual(Guid.Empty, result.Id);
        Assert.Equal("Luke Skywalker", result.Name);
    }

    [Fact]
    public async Task AddAsync_ShouldGenerateIdIfEmpty()
    {
        // Arrange
        var jedi = new JediModel 
        { 
            Name = "Yoda", 
            Rank = "Grand Master"
        };
        var originalId = jedi.Id;

        // Act
        var result = await _repository.AddAsync(jedi);

        // Assert
        Assert.NotEqual(originalId, result.Id);
        Assert.NotEqual(Guid.Empty, result.Id);
    }

    [Fact]
    public async Task GetOneAsync_ShouldReturnJediWhenExists()
    {
        // Arrange
        var jedi = new JediModel 
        { 
            Name = "Obi-Wan Kenobi", 
            Rank = "Master"
        };
        var added = await _repository.AddAsync(jedi);

        // Act
        var result = await _repository.GetOneAsync(added.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(added.Id, result.Id);
        Assert.Equal("Obi-Wan Kenobi", result.Name);
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
    public async Task GetAllAsync_ShouldReturnAllJedi()
    {
        // Arrange
        var jedi1 = new JediModel { Name = "Anakin Skywalker", Rank = "Knight" };
        var jedi2 = new JediModel { Name = "Ahsoka Tano", Rank = "Knight" };
        
        await _repository.AddAsync(jedi1);
        await _repository.AddAsync(jedi2);

        // Act
        var result = await _repository.GetAllAsync();

        // Assert
        var jediList = result.ToList();
        Assert.Equal(2, jediList.Count);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnEmptyWhenNoJedi()
    {
        // Act
        var result = await _repository.GetAllAsync();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateJediWhenExists()
    {
        // Arrange
        var jedi = new JediModel 
        { 
            Name = "Qui-Gon Jinn", 
            Rank = "Master",
            MidichlorianCount = 13600
        };
        var added = await _repository.AddAsync(jedi);
        added.Rank = "Grand Master";

        // Act
        var result = await _repository.UpdateAsync(added);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Grand Master", result.Rank);
        var retrieved = await _repository.GetOneAsync(added.Id);
        Assert.Equal("Grand Master", retrieved!.Rank);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNullWhenNotExists()
    {
        // Arrange
        var jedi = new JediModel 
        { 
            Id = Guid.NewGuid(),
            Name = "Unknown", 
            Rank = "Apprentice"
        };

        // Act
        var result = await _repository.UpdateAsync(jedi);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNullWhenIdIsEmpty()
    {
        // Arrange
        var jedi = new JediModel 
        { 
            Name = "Unknown", 
            Rank = "Apprentice"
        };

        // Act
        var result = await _repository.UpdateAsync(jedi);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveJediWhenExists()
    {
        // Arrange
        var jedi = new JediModel { Name = "Mace Windu", Rank = "Master" };
        var added = await _repository.AddAsync(jedi);

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
