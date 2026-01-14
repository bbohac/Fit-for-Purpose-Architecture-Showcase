using Infrastructure.Persistence;

namespace Infrastructure.Tests;

public sealed class InMemoryUrlRepositoryTests
{
    [Fact]
    public void Add_ReturnsCode_AndStoresUrl()
    {
        // Arrange
        var repo = new InMemoryUrlRepository();
        var url = "https://example.com";

        // Act
        var code = repo.Add(url);
        var stored = repo.Get(code);

        // Assert
        Assert.NotNull(code);
        Assert.Equal(8, code.Length);
        Assert.Equal(url, stored);
    }

    [Fact]
    public void Get_ReturnsNull_WhenCodeDoesNotExist()
    {
        // Arrange
        var repo = new InMemoryUrlRepository();

        // Act
        var result = repo.Get("unknown");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Add_GeneratesUniqueCodes()
    {
        // Arrange
        var repo = new InMemoryUrlRepository();
        var url = "https://example.com";

        // Act
        var code1 = repo.Add(url);
        var code2 = repo.Add(url);

        // Assert
        Assert.NotEqual(code1, code2);
    }
}
