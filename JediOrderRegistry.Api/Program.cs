using JediOrderRegistry.Api.Endpoints;
using JediOrderRegistry.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Register in-memory repositories (seeded for runtime)
builder.Services.AddSingleton<IHomeworldRepository>(new InMemoryHomeworldRepository(seed: true));
builder.Services.AddSingleton<IJediRepository>(new InMemoryJediRepository(seed: true));
builder.Services.AddSingleton<ILightSaberRepository>(new InMemoryLightSaberRepository(seed: true));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// Map endpoints
var homeworldRepo = app.Services.GetRequiredService<IHomeworldRepository>();
var jediRepo = app.Services.GetRequiredService<IJediRepository>();
var lightSaberRepo = app.Services.GetRequiredService<ILightSaberRepository>();

app.MapHomeWorldEndpoints(homeworldRepo);
app.MapJediEndpoints(jediRepo);
app.MapLightSaberEndpoints(lightSaberRepo);

app.Run();
