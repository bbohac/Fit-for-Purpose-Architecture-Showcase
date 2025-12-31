namespace MinimalApi.Domain;

public sealed class ShortUrl
{
  public ShortUrl(string code, string originalUrl)
  {
    Code = code;
    OriginalUrl = originalUrl;
    CreatedAt = DateTime.UtcNow;
  }

  public string Code { get; }
  public string OriginalUrl { get; }
  public DateTime CreatedAt { get; }
}
