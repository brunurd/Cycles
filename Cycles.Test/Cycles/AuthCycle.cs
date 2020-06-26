using System;

namespace Cycles.Test.Cycles
{
    public enum AuthState
    {
        NotLogged,
        LoginError,
        Logged,
        Logout,
    }

    public struct User
    {
        public string username;
        public string name;
        public string error;
        public bool isLogged;
    }

    public class AuthCycle : Cycle<AuthState, User>
    {
        public const string VALID_USERNAME = "lildoe";
        public const string VALID_PASSWORD = "roundandround";
        public const string ERROR_MESSAGE = "Invalid username or password.";
        
        public event Action<User> OnSuccess;
        public event Action<User> OnError;
        public event Action<User> OnLogout;

        public AuthState State => CurrentState;
        
        public AuthCycle()
        {
            AddState(AuthState.NotLogged, null);
            AddState(AuthState.Logged, user => { OnSuccess?.Invoke(user); });
            AddState(AuthState.LoginError, user => { OnError?.Invoke(user); });
            AddState(AuthState.Logout, user => { OnLogout?.Invoke(user); });
            
            SetState(AuthState.NotLogged, default);
        }

        public async void Login(string username, string password)
        {
            if (string.IsNullOrEmpty(password) || password != VALID_PASSWORD)
            {
                ErrorHandler(ERROR_MESSAGE);
                return;
            }

            if (string.IsNullOrEmpty(username) || username != VALID_USERNAME)
            {
                ErrorHandler(ERROR_MESSAGE);
                return;
            }

            SetState(AuthState.Logged, new User
            {
                name = "John Doe",
                username = VALID_USERNAME,
                isLogged = true,
            });
        }

        public void Logout()
        {
            SetState(AuthState.Logout, default);
        }

        private void ErrorHandler(string message)
        {
            SetState(AuthState.LoginError, new User
            {
                error = message,
            });
        }
    }
}