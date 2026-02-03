using System;
using JediOrderRegistry.Api.Models;
using JediOrderRegistry.Api.Repositories;

namespace JediOrderRegistry.Api.Endpoints;

public static class HomeWorldEndpoints
{
    public static void MapHomeWorldEndpoints(this IEndpointRouteBuilder routes, IHomeworldRepository repository)
    {
        var group = routes.MapGroup("/api/homeworlds").WithTags("HomeWorlds");

        group.MapGet("/", GetAllHomeWorlds(repository))
        .WithName("GetAllHomeWorlds")
        .WithSummary("Retrieves a list of all Home Worlds in the registry.");

        group.MapGet("/{id:guid}", GetHomeWorldById(repository))
        .WithName("GetHomeWorldById")
        .WithSummary("Retrieves a specific Home World by their unique identifier.");

        group.MapPost("/", CreateHomeWorld(repository))
        .WithName("CreateHomeWorld")
        .WithSummary("Creates a new Home World entry in the registry.");

        group.MapPut("/{id:guid}", UpdateHomeWorld(repository))
        .WithName("UpdateHomeWorld")
        .WithSummary("Updates an existing Home World's information.");

        group.MapDelete("/{id:guid}", DeleteHomeWorld(repository))
        .WithName("DeleteHomeWorld")
        .WithSummary("Deletes a Home World from the registry.");
    }

    private static Delegate GetAllHomeWorlds(IHomeworldRepository repository) =>
        async () =>
        {
            var homeworlds = await repository.GetAllAsync();
            return Results.Ok(homeworlds);
        };

    private static Delegate GetHomeWorldById(IHomeworldRepository repository) =>
        async (Guid id) =>
        {
            var homeworld = await repository.GetOneAsync(id);
            return homeworld == null ? Results.NotFound() : Results.Ok(homeworld);
        };

    private static Delegate CreateHomeWorld(IHomeworldRepository repository) =>
        async (Homeworld newHomeworld) =>
        {
            var created = await repository.AddAsync(newHomeworld);
            return Results.Created($"/api/homeworlds/{created.Id}", created);
        };

    private static Delegate UpdateHomeWorld(IHomeworldRepository repository) =>
        async (Guid id, Homeworld updatedHomeworld) =>
        {
            updatedHomeworld.Id = id;
            var result = await repository.UpdateAsync(updatedHomeworld);
            return result == null ? Results.NotFound() : Results.NoContent();
        };

    private static Delegate DeleteHomeWorld(IHomeworldRepository repository) =>
        async (Guid id) =>
        {
            var deleted = await repository.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        };
}