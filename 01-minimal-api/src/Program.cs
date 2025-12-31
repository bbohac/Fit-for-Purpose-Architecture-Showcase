using Microsoft.AspNetCore.Mvc;
using MinimalApi.Application;
using MinimalApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IUrlRepository, InMemoryUrlRepository>();
builder.Services.AddScoped<IShorteningService, ShorteningService>();

var app = builder.Build();

app.MapPost("/shorten", (
  [FromBody] ShortenRequest request,
  IShorteningService shorteningService) =>
{
  if (string.IsNullOrWhiteSpace(request.Url))
  {
    return Results.BadRequest("Url is required.");
  }

  try
  {
    var shortUrl = shorteningService.Shorten(request.Url);
    return Results.Ok(new ShortenResponse(shortUrl.Code, shortUrl.OriginalUrl));
  }
  catch (ArgumentException ex)
  {
    return Results.BadRequest(ex.Message);
  }
});

app.MapGet("/{code}", (string code, IShorteningService shorteningService) =>
{
  var url = shorteningService.Resolve(code);
  if (url is null)
  {
    return Results.NotFound();
  }

  return Results.Redirect(url);
});

app.Run();

record ShortenRequest(string Url);
record ShortenResponse(string Code, string Url);
