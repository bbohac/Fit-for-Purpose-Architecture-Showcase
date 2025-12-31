using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var urls = new Dictionary<string, string>();

app.MapPost("/shorten", ([FromBody] ShortenRequest request) =>
{
  if (string.IsNullOrWhiteSpace(request.Url))
  {
    return Results.BadRequest("Url is required.");
  }

  var code = Guid.NewGuid().ToString("N")[..8];
  urls[code] = request.Url;

  return Results.Ok(new ShortenResponse(code, request.Url));
});

app.MapGet("/{code}", (string code) =>
{
  if (urls.TryGetValue(code, out var url))
  {
    return Results.Redirect(url);
  }

  return Results.NotFound();
});

app.Run();

record ShortenRequest(string Url);
record ShortenResponse(string Code, string Url);
