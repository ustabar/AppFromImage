using Microsoft.JSInterop;

namespace EShopApp.Services
{
    public class AuthService
    {
        private readonly IJSRuntime _jsRuntime;
        public event Action? AuthStateChanged;
        
        private bool _isLoggedIn = false;
        private string _currentUser = "";
        
        public bool IsLoggedIn => _isLoggedIn;
        public string CurrentUser => _currentUser;
        
        public AuthService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        
        public async Task LoginAsync(string username)
        {
            _isLoggedIn = true;
            _currentUser = username;
            AuthStateChanged?.Invoke();
            await ShowNotificationAsync($"Welcome {username}!", "success");
        }
        
        public async Task LogoutAsync()
        {
            _isLoggedIn = false;
            _currentUser = "";
            AuthStateChanged?.Invoke();
            await ShowNotificationAsync("Successfully logged out", "info");
        }
        
        // Synchronous methods for compatibility
        public void Login(string username)
        {
            _isLoggedIn = true;
            _currentUser = username;
            AuthStateChanged?.Invoke();
        }
        
        public void Logout()
        {
            _isLoggedIn = false;
            _currentUser = "";
            AuthStateChanged?.Invoke();
        }
        
        private async Task ShowNotificationAsync(string message, string type)
        {
            try
            {
                await _jsRuntime.InvokeVoidAsync("showNotification", message, type);
            }
            catch
            {
                // Ignore JS errors during notification
            }
        }
    }
}