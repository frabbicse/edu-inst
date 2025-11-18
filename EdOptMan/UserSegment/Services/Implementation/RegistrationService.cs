using UserSegment.Models;
using System.Collections.Generic;
using System.Linq;

namespace UserSegment.Services.Implementation
{
    public class RegistrationService
    {
        private static readonly List<RegisterModel> _users = new();

        public bool RegisterUser(RegisterModel model)
        {
            if (_users.Any(u => u.Username == model.Username))
                return false; // Username already exists

            _users.Add(model);
            return true;
        }
    }
}