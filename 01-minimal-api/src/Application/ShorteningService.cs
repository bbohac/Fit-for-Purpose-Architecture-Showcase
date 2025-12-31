using MinimalApi.Domain;
using MinimalApi.Infrastructure;

namespace MinimalApi.Application;

public sealed class ShorteningService : IShorteningService
{
  private readonly IUrlRepository _repository;

  public ShorteningService(IUrlRepository repository) =>
    _repository = repository;

  public ShortUrl Shorten(string url)
  {
    if (!Uri.TryCreate(url, UriKind.Absolute, out var uri) ||
      (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
    {
      throw new ArgumentException("Inalid URL format.", nameof(url));
    }

    var code = _repository.Add(url);
    return new ShortUrl(code, url);
  }

  public string? Resolve(string code) =>
    string.IsNullOrWhiteSpace(code) ? null : _repository.Get(code);
}
