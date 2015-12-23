using System;

namespace Jjg.Crypto.HashFunctions
{
    public static class CompareFolders
    {
        /// <summary>
        /// Compare two folders to determine if their hash values are identical.
        /// </summary>
        /// <param name="newFile">New or potentially modified folder.</param>
        /// <param name="oldFile">Original or baseline folder to compare the new or modified folder to.</param>
        /// <returns>Boolean</returns>
        public static bool Compare(string newFolder, string oldFolder)
        {
            bool equal = false;
            try
            {
                string hashA = DirectoryHash.Generate(newFolder);
                string hashB = DirectoryHash.Generate(oldFolder);
                if (hashA.Length == hashB.Length)
                {
                    int i = 0;
                    while ((i < hashA.Length) && (hashA[i] == hashB[i]))
                    {
                        i += 1;
                    }
                    if (i == hashA.Length)
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
