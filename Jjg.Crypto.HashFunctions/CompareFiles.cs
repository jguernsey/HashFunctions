using System;

namespace Jjg.Crypto.HashFunctions
{
    public static class CompareFiles
    {
        /// <summary>
        /// Compare two files to determine if their hash values are identical.
        /// </summary>
        /// <param name="newFile">New or potentially modified file.</param>
        /// <param name="oldFile">Original or baseline file to compare the new file to.</param>
        /// <returns>Boolean</returns>
        public static bool Compare(string newFile, string oldFile)
        {
            bool equal = false;
            try
            {
                string hashA = newFile.ToHash();
                string hashB = oldFile.ToHash();
                if(hashA.Length == hashB.Length)
                {
                    int i = 0;
                    while((i < hashA.Length) && (hashA[i] == hashB[i]))
                    {
                        i += 1;
                    }
                    if(i == hashA.Length)
                    {
                        equal = true;
                    }
                }
            }
            catch(Exception ex)
            {
                equal = false;
            }
            return equal;
        }
    }
}
