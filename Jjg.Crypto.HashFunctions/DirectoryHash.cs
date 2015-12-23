using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Jjg.Crypto.HashFunctions
{
    /// <summary>
    /// Generates the hash value for a directory and all sub-directories.
    /// </summary>
    public static class DirectoryHash
    {
        /// <summary>
        /// Generates a SHA512 hash value for a directory and all sub-directories.
        /// </summary>
        /// <param name="path">Top level folder for which the hash value will be generated.</param>
        /// <returns>The hash value of the file converted to a string.</returns>
        public static string Generate(string path)
        {
            string hashValue = string.Empty;
            try
            {
                List<string> files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).OrderBy(p => p).ToList();
                SHA512 sha = SHA512.Create();
                for(int i = 0;i < files.Count; i++)
                {
                    string file = files[i];
                    string relativePath = file.Substring(path.Length + 1);
                    byte[] pathBytes = Encoding.UTF8.GetBytes(relativePath.ToLower());
                    sha.TransformBlock(pathBytes, 0, pathBytes.Length, pathBytes, 0);
                    byte[] contentBytes = File.ReadAllBytes(file);
                    if (i == files.Count - 1)
                        sha.TransformFinalBlock(contentBytes, 0, contentBytes.Length);
                    else
                        sha.TransformBlock(contentBytes, 0, contentBytes.Length, contentBytes, 0);
                }
                hashValue = BitConverter.ToString(sha.Hash).Replace("-", string.Empty);
            }
            catch(Exception ex)
            {

            }
            return hashValue;
        }
    }
}
