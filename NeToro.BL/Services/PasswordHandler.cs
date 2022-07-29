using System;
using NeToro.BL.Contracts;

namespace NeToro.BL.Services
{
    public class PasswordHandler : IPasswordHandler
    {
        public (string password, string salt) GeneratorPassword(string salt,string password)
        {
            int saltSubstringLength = (int)Math.Ceiling(1.0 * salt.Length / 2);
            int passwordSubstringLength = (int)Math.Ceiling(1.0 * password.Length / 2);
            
            string passwordHashed = salt.Substring(0, saltSubstringLength)
                                   + password.Substring(0, passwordSubstringLength)
                                   + salt.Substring(saltSubstringLength)
                                   + password.Substring(passwordSubstringLength);

            return (passwordHashed, salt);
        }
    }
}
