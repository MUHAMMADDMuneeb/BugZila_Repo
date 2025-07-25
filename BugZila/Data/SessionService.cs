using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Threading.Tasks;

namespace SessionCheck.Data
{
    public class SessionService
    {
        private readonly ILocalStorageService _localStorage;
       

        public SessionService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            
        }

        public async Task SetSessionAsync(int userId, int userType)
        {
            // save in protected session storage
            

            // save in browser localStorage
            await _localStorage.SetItemAsync("Id", userId);
            await _localStorage.SetItemAsync("Value", userType);
        }

      
        public async Task RemoveSessionAsync()
        {
            // Remove session key from ProtectedSessionStorage
            

            // Remove session key from LocalStorage
            await _localStorage.RemoveItemAsync("Value");
        }
    }
}
