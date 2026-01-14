using Application.Interfaces;
using Application.Services;

namespace Application.Tests;

public sealed class ShorteningServiceTests
{
    private sealed class FakeRepository : IUrlRepository
    {
        private readonly Dictionary<string, string> _storage = [];

        public string Add(string url)
        {
            var code = "testcode";
            _storage[code] = url;

            return code;
        }

        public string? Get(string code) => _storage.TryGetValue(code, out var url) ? url : null;
    }

    [Fact]
    public void Shorten_ReturnsShortUrl_WhenUrlIsValid()
    {
        // Arrange
        var repo = new FakeRepository();
        var service = new ShorteningService(repo);

        // Act
        var result = service.Shorten("https://example.com");

        // Assert
        Assert.Equal("testcode", result.Code);
        Assert.Equal("https://example.com", result.OriginalUrl);
        Assert.True(result.CreatedAt <= DateTime.UtcNow);
    }

    [Theory]
    [InlineData("invalid-url")]
    [InlineData("ftp://example.com")]
    [InlineData("")]
    [InlineData("   ")]
    public void Shorten_ThrowsArgumentException_WhenUrlIsInvalid(string url)
    {
        // Arrange
        var repo = new FakeRepository();
        var service = new ShorteningService(repo);

        // Act, Assert
        Assert.Throws<ArgumentException>(() => service.Shorten(url));
    }

    [Fact]
    public void Resolve_ReturnsUrl_WhenCodeExists()
    {
        // Arrange
        var repo = new FakeRepository();
        var service = new ShorteningService(repo);

        // Act
        service.Shorten("https://example.com");
        var result = service.Resolve("testcode");

        // Assert
        Assert.Equal("https://example.com", result);
    }

    [Fact]
    public void Resolve_ReturnsNull_WhenCodeDoesNotExist()
    {
        // Arrange
        var repo = new FakeRepository();
        var service = new ShorteningService(repo);

        // Act
        var result = service.Resolve("unknown");

        // Assert
        Assert.Null(result);
    }
}
