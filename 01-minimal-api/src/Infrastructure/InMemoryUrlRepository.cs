using System.Collections.Concurrent;

namespace MinimalApi.Infrastructure;

public sealed class InMemoryUrlRepository : IUrlRepository
{
  private readonly ConcurrentDictionary<string, string> _storage = new();

  public string Add(string originalUrl)
  {
    var code = Guid.NewGuid().ToString("N")[..8];
    _storage[code] = originalUrl;

    return code;
  }

  public string? Get(string code) =>
    _storage.TryGetValue(code, out var url) ? url : null;
}
