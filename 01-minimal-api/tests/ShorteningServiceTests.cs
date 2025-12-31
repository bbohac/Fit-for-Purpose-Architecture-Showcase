using MinimalApi.Application;
using MinimalApi.Infrastructure;

namespace MinimalApi.Tests;

public sealed class ShorteningServiceTests
{
  private const string VALID_URL = "https://example.com";
  private const string INVALID_URL = "invalid";
  private const string UNKNOWN_CODE = "unknown";

  [Fact]
  public void Shorten_ValidUrl_ReturnsShortUrl()
  {
    // Arrange
    var service = new ShorteningService(new InMemoryUrlRepository());

    // Act
    var result = service.Shorten(VALID_URL);

    // Assert
    Assert.NotNull(result);
    Assert.Equal(VALID_URL, result.OriginalUrl);
    Assert.False(string.IsNullOrWhiteSpace(result.Code));
  }

  [Fact]
  public void Shorten_InvalidUrl_ThrowsArgumentException()
  {
    // Arrange
    var service = new ShorteningService(new InMemoryUrlRepository());

    // Act, Assert
    Assert.Throws<ArgumentException>(() => service.Shorten(INVALID_URL));
  }

  [Fact]
  public void Resolve_ExistingCode_ReturnsOriginalUrl()
  {
    // Arrange
    var repository = new InMemoryUrlRepository();
    var service = new ShorteningService(repository);
    var shortUrl = service.Shorten(VALID_URL);

    // Act
    var resolved = service.Resolve(shortUrl.Code);

    // Assert
    Assert.Equal(VALID_URL, resolved);
  }

  [Fact]
  public void Resolve_UnknownCode_ReturnsNull()
  {
    // Arrange
    var service = new ShorteningService(new InMemoryUrlRepository());

    // Act
    var result = service.Resolve(UNKNOWN_CODE);
  }
}
