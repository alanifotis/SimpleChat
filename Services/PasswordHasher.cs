using System.Security.Authentication;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;

namespace SimpleChat.Services;

public class  PasswordHasher()
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 1_000_000;

    private readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;

    public string Hash(string password) {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);

        return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
    }

    public bool Decrypt(string password, string passwordHash) {
        string[] parts = passwordHash.Split('-');
        byte[] hash = Convert.FromHexString(parts[0]);
        byte[] salt = Convert.FromHexString(parts[1]);

        byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);

        return CryptographicOperations.FixedTimeEquals(hash, inputHash);
    }

}