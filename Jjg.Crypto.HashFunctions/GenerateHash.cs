using System;
using System.IO;
using System.Security.Cryptography;

namespace Jjg.Crypto.HashFunctions
{
    public static class GenerateHash
    {
        /// <summary>
        /// Extension method to calculate the SHA512 hash of a given file
        /// </summary>
        /// <param name="filePath">The full path to the file for which to generate a hash value.</param>
        /// <returns>The hash value of the file converted to a string.</returns>
        public static string ToHash(this string filePath)
        {
            string hashValue = string.Empty;
            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    using (BufferedStream bufferedStream = new BufferedStream(stream, 1024 * 32))
                    {
                        SHA512Managed sha = new SHA512Managed();
                        byte[] checksum = sha.ComputeHash(bufferedStream);
                        hashValue = BitConverter.ToString(checksum).Replace("-", string.Empty);
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return hashValue;
        }
    }
}
