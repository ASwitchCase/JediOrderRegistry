using JediOrderRegistry.Api.Endpoints;
using JediOrderRegistry.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Register in-memory repositories
builder.Services.AddSingleton<IHomeworldRepository, InMemoryHomeworldRepository>();
builder.Services.AddSingleton<IJediRepository, InMemoryJediRepository>();
builder.Services.AddSingleton<ILightSaberRepository, InMemoryLightSaberRepository>();

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
