namespace ProductPrice.Abstractions.Services.Security
{
    public interface ISha512Service
    {
        string Calculate(string str);
    }
}