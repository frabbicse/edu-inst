namespace UserSegment.Services.Implementation
{
    public class LoginService
    {
        // Simulate user fetch and verification
        public bool ValidateUser(string username, string password)
        {
            // Replace with your user store logic
            return username == "admin" && password == "password";
        }
    }
}