namespace Common
{
    public interface IEncryptor
    {
        /// <summary>
        /// Generates the MD5 hash of the specified <see cref="string"/> text.
        /// </summary>
        /// <param name="plaintext">Text to convert.</param>
        /// <returns>MD5 hash</returns>
        string GetMD5(string plaintext);
        /// <summary>
        /// Encrypts a <see cref="string"/> of plaintext using RSA algorithm
        /// into ciphertext
        /// </summary>
        /// <param name="plainText">Block of text to encrypt</param>
        /// <returns>
        ///     Base64 encoded ciphertext
        /// </returns>
        string Encrypt(string plainText);
        string Decrypt(string cipherText);
        /// <summary>
        /// Encrypts a block of text using RSA algorithm from the public key 
        /// in the certificate file provided.
        /// </summary>
        /// <param name="plainText">Block of text to encrypt</param>
        /// <param name="certificatePath">File path to the Public Key Certificate
        /// on the current machine.
        /// </param>
        /// <returns>
        ///     Base64 encoded ciphertext
        /// </returns>
        string Encrypt(string plainText, string certificatePath);
        string Decrypt(string cipherText, string certicatePath);
    }
}