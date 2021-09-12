namespace dotnet6MinimalAPI.Services;
public interface IMinimalApiService
{
    string CheckDotNet(bool dotnet);
}

public class MinimalApiService : IMinimalApiService
{
    public string CheckDotNet(bool dotnet)
    {
            return $"Selected: " + dotnet;
    }
}