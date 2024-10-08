using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.Json;
using MCTG.Server.Http;

namespace MCTG.Server.Endpoints
{
    internal class UserEndpoint
    {
        private Dictionary<string, User> users;
        private Dictionary<string, string> sessions;

        public UserEndpoint(Dictionary<string, User> users, Dictionary<string, string> sessions)
        {
            this.users = users;
            this.sessions = sessions;
        }

        public void HandleRequest(HttpRequest request, HttpResponse response)
        {
            if (request.Method == "POST" && request.Path == "/users")
            {
                HandleUserRegistration(request.Body, response);
            }
            else if (request.Method == "POST" && request.Path == "/sessions")
            {
                HandleUserLogin(request.Body, response);
            }
            else
            {
                response.WriteResponse("HTTP/1.0 404 Not Found", "<html><body>Benutzer nicht vorhanden!</body></html>");
            }
        }

        private void HandleUserRegistration(string requestBody, HttpResponse response)
        {
            var newUser = JsonSerializer.Deserialize<User>(requestBody);
            if (newUser != null && !users.ContainsKey(newUser.Username))
            {
                users[newUser.Username] = newUser;
                response.WriteResponse("HTTP/1.0 201 Created", "<html><body>Benutzer registriert.</body></html>");
            }
            else
            {
                response.WriteResponse("HTTP/1.0 400 Bad Request", "<html><body>Benutzer existiert bereits!</body></html>");
            }
        }

        private void HandleUserLogin(string requestBody, HttpResponse response)
        {
            var loginUser = JsonSerializer.Deserialize<User>(requestBody);
            if (loginUser != null && users.TryGetValue(loginUser.Username, out var existingUser) &&
                existingUser.Password == loginUser.Password)
            {
                var token = GenerateToken();
                sessions[token] = loginUser.Username;
                response.WriteResponse("HTTP/1.0 200 OK", $"<html><body>Benutzer angemeldet, Token: {token}</body></html>");
            }
            else
            {
                response.WriteResponse("HTTP/1.0 401 Unauthorized", "<html><body>Ungültige Anmeldedaten!</body></html>");
            }
        }

        private string GenerateToken()
        {
            var tokenData = new byte[32];
            RandomNumberGenerator.Fill(tokenData);
            using var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(tokenData);
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}
