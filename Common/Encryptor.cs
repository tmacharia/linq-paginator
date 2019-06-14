using Common.Primitives;
using Common.Structs;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Common
{
    public class Encryptor : IEncryptor
    {
        private static readonly RSACryptoServiceProvider cryptoServiceProvider = new RSACryptoServiceProvider();

        public string GetMD5(string plaintext)
        {
            byte[] bytes = GeneralUtils.md5.ComputeHash(plaintext.ToByteArray());

            return BitConverter.ToString(bytes)
                               .Replace("-", string.Empty)
                               .ToLower(Constants.Culture);
        }
        public string Encrypt(string plainText) =>
                      cryptoServiceProvider.Encrypt(plainText.ToByteArray(), RSAEncryptionPadding.Pkcs1).ToBase64String();

        public string Decrypt(string cipherText) =>
                      cryptoServiceProvider.Decrypt(cipherText.FromBase64ToArray(), RSAEncryptionPadding.Pkcs1).ConvertToString();

        public string Encrypt(string plainText, string certificatePath)
        {
            byte[] bytes = plainText.ToByteArray();

            // Load X509 Certificate from file
            X509Certificate2 certificate = new X509Certificate2(certificatePath);
            
            // Use certificate to get RSA algorithm to use with it
            RSA pub_key = certificate.GetRSAPublicKey();
            
            // Use PKCS padding mode instead of OAEP
            RSAEncryptionPadding padding = RSAEncryptionPadding.Pkcs1;
            
            byte[] final = pub_key.Encrypt(bytes, padding);

            return final.ToBase64String();
        }
        public string Decrypt(string cipherText, string certificatePath)
        {
            byte[] hash = cipherText.FromBase64ToArray();

            // Load X509 Certificate from file
            var cer = X509Certificate.CreateFromSignedFile(certificatePath);
            
            X509Certificate2 certificate = new X509Certificate2(certificatePath,string.Empty);
            // Use certificate to get RSA algorithm to use with it
            RSA pub_key = certificate.GetRSAPublicKey();
            // Use PKCS padding mode instead of OAEP
            RSAEncryptionPadding padding = RSAEncryptionPadding.Pkcs1;

            byte[] final = pub_key.Decrypt(hash, padding);
            
            return hash.ConvertToString();
        }
    }
}