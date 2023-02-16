namespace NetCoreLogin.Services.Interfaces
{
    public interface IApiService
    {
        Task<bool> ValidateUserAsync(string username, string password);
    }
}
