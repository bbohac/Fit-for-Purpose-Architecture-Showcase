using System.Collections.Concurrent;
using Application.Interfaces;

namespace Infrastructure.Persistence;

public sealed class InMemoryUrlRepository : IUrlRepository
{
    private readonly ConcurrentDictionary<string, string> _storage = new();

    public string Add(string url)
    {
        var code = Guid.NewGuid().ToString("N")[..8];
        _storage[code] = url;

        return code;
    }

    public string? Get(string code) => _storage.TryGetValue(code, out var url) ? url : null;
}
