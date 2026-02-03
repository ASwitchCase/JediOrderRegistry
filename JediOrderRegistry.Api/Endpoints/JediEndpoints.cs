using System;
using JediOrderRegistry.Api.Models;
using JediOrderRegistry.Api.Repositories;

namespace JediOrderRegistry.Api.Endpoints;

public static class JediEndpoints
{
    public static void MapJediEndpoints(this IEndpointRouteBuilder routes, IJediRepository repository)
    {
        var group = routes.MapGroup("/api/jedi").WithTags("Jedi");

        group.MapGet("/", GetAllJedi(repository))
        .WithName("GetAllJedi")
        .WithSummary("Retrieves a list of all Jedi in the registry.");

        group.MapGet("/{id:guid}", GetJediById(repository))
        .WithName("GetJediById")
        .WithSummary("Retrieves a specific Jedi by their unique identifier.");

        group.MapPost("/", CreateJedi(repository))
        .WithName("CreateJedi")
        .WithSummary("Creates a new Jedi entry in the registry.");

        group.MapPut("/{id:guid}", UpdateJedi(repository))
        .WithName("UpdateJedi")
        .WithSummary("Updates an existing Jedi's information.");

        group.MapDelete("/{id:guid}", DeleteJedi(repository))
        .WithName("DeleteJedi")
        .WithSummary("Deletes a Jedi from the registry.");
    }

    private static Delegate GetAllJedi(IJediRepository repository) =>
        async () =>
        {
            var jedi = await repository.GetAllAsync();
            return Results.Ok(jedi);
        };

    private static Delegate GetJediById(IJediRepository repository) =>
        async (Guid id) =>
        {
            var jedi = await repository.GetOneAsync(id);
            return jedi == null ? Results.NotFound() : Results.Ok(jedi);
        };

    private static Delegate CreateJedi(IJediRepository repository) =>
        async (JediModel newJedi) =>
        {
            var created = await repository.AddAsync(newJedi);
            return Results.Created($"/api/jedi/{created.Id}", created);
        };

    private static Delegate UpdateJedi(IJediRepository repository) =>
        async (Guid id, JediModel updatedJedi) =>
        {
            updatedJedi.Id = id;
            var result = await repository.UpdateAsync(updatedJedi);
            return result == null ? Results.NotFound() : Results.NoContent();
        };

    private static Delegate DeleteJedi(IJediRepository repository) =>
        async (Guid id) =>
        {
            var deleted = await repository.DeleteAsync(id);
            return deleted ? Results.NoContent() : Results.NotFound();
        };
}
