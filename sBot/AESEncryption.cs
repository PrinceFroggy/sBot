using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Utility class that handles encryption
/// </summary>
public static class AESEncryption
{
    /// <summary>
    /// Encrypts a string
    /// </summary>
    /// <param name="PlainText">Text to be encrypted</param>
    /// <param name="Password">Password to encrypt with</param>
    /// <param name="Salt">Salt to encrypt with</param>
    /// <param name="HashAlgorithm">Can be either SHA1 or MD5</param>
    /// <param name="PasswordIterations">Number of iterations to do</param>
    /// <param name="InitialVector">Needs to be 16 ASCII characters long</param>
    /// <param name="KeySize">Can be 128, 192, or 256</param>
    /// <returns>An encrypted string</returns>
    public static string Encrypt(string PlainText, string Password, string Salt, string HashAlgorithm, int PasswordIterations, string InitialVector, int KeySize)
    {
        try
        {
            byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
            byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);
            byte[] PlainTextBytes = Encoding.UTF8.GetBytes(PlainText);
            PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(Password, SaltValueBytes, HashAlgorithm, PasswordIterations);
            byte[] KeyBytes = DerivedPassword.GetBytes(KeySize / 8);
            RijndaelManaged SymmetricKey = new RijndaelManaged();
            SymmetricKey.Mode = CipherMode.CBC;
            byte[] CipherTextBytes = null;
            using (ICryptoTransform Encryptor = SymmetricKey.CreateEncryptor(KeyBytes, InitialVectorBytes))
            {
                using (MemoryStream MemStream = new MemoryStream())
                {
                    using (CryptoStream CryptoStream = new CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write))
                    {
                        CryptoStream.Write(PlainTextBytes, 0, PlainTextBytes.Length);
                        CryptoStream.FlushFinalBlock();
                        CipherTextBytes = MemStream.ToArray();
                        MemStream.Close();
                        CryptoStream.Close();
                    }
                }
            }
            return Convert.ToBase64String(CipherTextBytes);
        }
        catch (Exception a)
        {
            throw a;
        }
    }

    /// <summary>
    /// Decrypts a string
    /// </summary>
    /// <param name="CipherText">Text to be decrypted</param>
    /// <param name="Password">Password to decrypt with</param>
    /// <param name="Salt">Salt to decrypt with</param>
    /// <param name="HashAlgorithm">Can be either SHA1 or MD5</param>
    /// <param name="PasswordIterations">Number of iterations to do</param>
    /// <param name="InitialVector">Needs to be 16 ASCII characters long</param>
    /// <param name="KeySize">Can be 128, 192, or 256</param>
    /// <returns>A decrypted string</returns>
    public static string Decrypt(string CipherText, string Password, string Salt, string HashAlgorithm, int PasswordIterations, string InitialVector, int KeySize)
    {
        try
        {
            byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
            byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);
            byte[] CipherTextBytes = Convert.FromBase64String(CipherText);
            PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(Password, SaltValueBytes, HashAlgorithm, PasswordIterations);
            byte[] KeyBytes = DerivedPassword.GetBytes(KeySize / 8);
            RijndaelManaged SymmetricKey = new RijndaelManaged();
            SymmetricKey.Mode = CipherMode.CBC;
            byte[] PlainTextBytes = new byte[CipherTextBytes.Length];
            int ByteCount = 0;
            using (ICryptoTransform Decryptor = SymmetricKey.CreateDecryptor(KeyBytes, InitialVectorBytes))
            {
                using (MemoryStream MemStream = new MemoryStream(CipherTextBytes))
                {
                    using (CryptoStream CryptoStream = new CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read))
                    {

                        ByteCount = CryptoStream.Read(PlainTextBytes, 0, PlainTextBytes.Length);
                        MemStream.Close();
                        CryptoStream.Close();
                    }
                }
            }
            return Encoding.UTF8.GetString(PlainTextBytes, 0, ByteCount);
        }
        catch
        {
            return "";
        }

    }
}