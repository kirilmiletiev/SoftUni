namespace IRunes.Services
{
    using Contracts;
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class HashService : IHashService
    {
        public string Hash(string stringToHash)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                return hash;
            }
        }
    }
}