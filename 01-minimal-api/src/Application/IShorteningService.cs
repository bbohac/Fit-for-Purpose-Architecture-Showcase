using MinimalApi.Domain;

namespace MinimalApi.Application;

public interface IShorteningService
{
  public ShortUrl Shorten(string url);
  public string? Resolve(string code);
}
