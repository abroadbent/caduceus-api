using System;
using System.Security.Cryptography;

namespace Api.Utilities
{
    public static class Encryption
    {
		/// <summary>
		/// Hashes the password from (https://stackoverflow.com/questions/4181198/how-to-hash-a-password/10402129#10402129).
		/// </summary>
		/// <returns>The hashed password.</returns>
		/// <param name="password">Password.</param>
		public static string HashPassword(string password)
        {
			byte[] salt;
			new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

			var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
			byte[] hash = pbkdf2.GetBytes(20);

			byte[] hashBytes = new byte[36];
			Array.Copy(salt, 0, hashBytes, 0, 16);
			Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

		/// <summary>
		/// Validates a hashed password from (https://stackoverflow.com/questions/4181198/how-to-hash-a-password/10402129#10402129).
		/// </summary>
		/// <param name="hashedPassword">Hashed Password.</param>
		public static bool ValidateHashedPassword(string password, string hashedPassword)
        {
			/* Extract the bytes */
			byte[] hashBytes = Convert.FromBase64String(hashedPassword);

			/* Get the salt */
			byte[] salt = new byte[16];
			Array.Copy(hashBytes, 0, salt, 0, 16);
			
            /* Compute the hash on the password the user entered */
			var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
			byte[] hash = pbkdf2.GetBytes(20);
			
            /* Compare the results */
            for (int i = 0; i < 20; i++) 
            {
                if (hashBytes[i + 16] != hash[i]) {
                    return false;
                }
            }

            return true;
        }
    }
}
