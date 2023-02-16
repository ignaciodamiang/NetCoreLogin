using System.Text.Json;
using NetCoreLogin.Models;
using NetCoreLogin.Services.Interfaces;

namespace NetCoreLogin.Services
{
    public class ApiService : IApiService
    {
        private readonly IWebHostEnvironment _environment;

        public ApiService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            var filePath = Path.Combine(_environment.ContentRootPath, "users.json");

        using (var streamReader = new StreamReader(filePath))
        {
            var jsonData = await streamReader.ReadToEndAsync();
            var users = JsonSerializer.Deserialize<List<User>>(jsonData);

            var user = users.FirstOrDefault(u => u.Email == email && u.Password == password);

            return user != null;
        }

        }
    }
}