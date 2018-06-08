namespace ProductPrice.Abstractions.Services.Security.AccessToken
{
    public interface IAccessTokenService
    {
        TPayload GetPayload<TPayload>(string accessToken) where TPayload : Payload;
        void Verify(string accessToken, string key);
        string Create<TPayload>(TPayload payload, string key) where TPayload : Payload;
    }
}