using System;
using JediOrderRegistry.Api.Models;
using JediOrderRegistry.Api.Repositories;

namespace JediOrderRegistry.Api.Endpoints;

public static class LightSaberEndpoints
{
    public static void MapLightSaberEndpoints(this IEndpointRouteBuilder routes, ILightSaberRepository repository)
    {
        var group = routes.MapGroup("/api/lightsabers").WithTags("LightSabers");

        group.MapGet("/", GetAllLightSabers(repository))
        .WithName("GetAllLightSabers")
        .WithSummary("Retrieves all lightsabers in the registry.");

        group.MapGet("/{id:guid}", GetLightSaberById(repository))
        .WithName("GetLightSaberById")
        .WithSummary("Retrieves a specific lightsaber by its unique identifier.");

        group.MapPost("/", CreateLightSaber(repository))
        .WithName("CreateLightSaber")
        .WithSummary("Creates a new lightsaber in the registry.");

        group.MapPut("/{id:guid}", UpdateLightSaber(repository))
        .WithName("UpdateLightSaber")
        .WithSummary("Updates an existing lightsaber's information.");

        group.MapDelete("/{id:guid}", DeleteLightSaber(repository))
        .WithName("DeleteLightSaber")
        .WithSummary("Deletes a lightsaber from the registry by its unique identifier.");
    }

    private static Delegate GetAllLightSabers(ILightSaberRepository repository) =>
        async () =>
        {
            var sabers = await repository.GetAllAsync();
            return Results.Ok(sabers);
        };

    private static Delegate GetLightSaberById(ILightSaberRepository repository) =>
        async (Guid id) =>
        {
            var saber = await repository.GetOneAsync(id);
            return saber == null ? Results.NotFound() : Results.Ok(saber);
        };

    private static Delegate CreateLightSaber(ILightSaberRepository repository) =>
        async (LightSaber newLightSaber) =>
        {
            var created = await repository.AddAsync(newLightSaber);
            return Results.Created($"/api/lightsabers/{created.Id}", created);
        };

    private static Delegate UpdateLightSaber(ILightSaberRepository repository) =>
        async (Guid id, LightSaber updatedLightSaber) =>
        {
            updatedLightSaber.Id = id;
            var result = await repository.UpdateAsync(updatedLightSaber);
            return result == null ? Results.NotFound() : Results.NoContent();
        };

    private static Delegate DeleteLightSaber(ILightSaberRepository repository) =>
        async (Guid id) =>
        {
            var deleted = await repository.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        };
}
