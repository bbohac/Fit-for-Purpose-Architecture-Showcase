namespace MinimalApi.Infrastructure;

public interface IUrlRepository
{
  public string Add(string originalUrl);
  public string? Get(string code);
}

