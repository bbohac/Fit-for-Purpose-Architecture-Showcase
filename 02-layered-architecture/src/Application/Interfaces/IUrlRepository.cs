namespace Application.Interfaces;

public interface IUrlRepository
{
    public string Add(string url);

    public string? Get(string code);
}
