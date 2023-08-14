using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurityPlus.Database
{
    public static class Validator
    {

        public static bool ValidateRole(string role)
        {
            var validRoles = Enum.GetNames(typeof(ApplicationRoles));
            // Convert the input role to lowercase for case-insensitive comparison
            role = role.ToLower();

            // Check if the provided role is one of the valid roles
            return Array.Exists(validRoles, validRole => validRole == role);
        }
    }
}
