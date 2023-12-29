using System;
using System.IO;
using System.Text;

class StreamCipherExample
{
    static void Main()
    {
        Console.WriteLine("Hello!\nGive me any information you want to encrypt and I'll do it for you :");

        string originalData = Convert.ToString(Console.ReadLine());
        string key = "Bruninieku iela";

        // Encrypting data
        string encryptedData = Encrypt(originalData, key);
        Console.WriteLine("Encrypted Data: " + encryptedData);

        // Decrypting data
        string decryptedData = Decrypt(encryptedData, key);
        Console.WriteLine("Decrypted Data: " + decryptedData);
    }

    static string Encrypt(string data, string key)
    {
        //Putting data and key in Byte table in order manipulate it
        byte[] dataBytes = Encoding.UTF8.GetBytes(data);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

        MemoryStream encryptedStream = new MemoryStream();
        //Encrypting!!!!
        for (int i = 0; i < dataBytes.Length; i++)
        {
            encryptedStream.WriteByte((byte)(dataBytes[i] ^ keyBytes[i % keyBytes.Length]));
        }

        return Convert.ToBase64String(encryptedStream.ToArray());
    }

    static string Decrypt(string encryptedData, string key)
    {
        byte[] encryptedBytes = Convert.FromBase64String(encryptedData);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

        MemoryStream decryptedStream = new MemoryStream();

        for (int i = 0; i < encryptedBytes.Length; i++)
        {
            decryptedStream.WriteByte((byte)(encryptedBytes[i] ^ keyBytes[i % keyBytes.Length]));
        }

        return Encoding.UTF8.GetString(decryptedStream.ToArray());
    }
}
