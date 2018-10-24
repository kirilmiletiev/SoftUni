namespace IRunes.Services
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using Contracts;

    public class HashService : IHashService
    {
        public string Hash(string hashToString)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(hashToString));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                return hash;
            }
        }
    }
}