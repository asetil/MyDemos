using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public static class AesEncryption
{
    // Key should be 32 bytes for AES-256
    private static readonly byte[] Key = Encoding.UTF8.GetBytes("ThisIsASecretKey1234567890123456"); // 32 bytes
    // IV should be 16 bytes for AES
    private static readonly byte[] IV = Encoding.UTF8.GetBytes("ThisIsAnInitVect"); // 16 bytes

    public static byte[] Encrypt(string plainText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return msEncrypt.ToArray();
                }
            }
        }
    }

    public static string Decrypt(byte[] cipherText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using (var msDecrypt = new MemoryStream(cipherText))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}

public class LoadTest
{
    public static async Task RunLoadTest(int numberOfRequests)
    {
        List<Task> tasks = new List<Task>();
        Stopwatch stopwatch = Stopwatch.StartNew();

        for (int i = 0; i < numberOfRequests; i++)
        {
            tasks.Add(Task.Run(() =>
            {
                string id = $"ID-{Guid.NewGuid()}"; // Generate a unique ID
                //id = i.ToString();
                var encryptedId = AesEncryption.Encrypt(id);
                var decryptedId = AesEncryption.Decrypt(encryptedId);
            }));
        }

        await Task.WhenAll(tasks);

        stopwatch.Stop();
        Console.WriteLine($"Total Time for {numberOfRequests} Requests: {stopwatch.ElapsedMilliseconds} ms");
    }
}