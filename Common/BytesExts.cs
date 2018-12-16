using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common
{
    public static class BytesExts
    {
        /// <summary>
        /// Converts a <see cref="byte[]"/> to its equivalent <see cref="string"/> of
        /// text using UTF encoding.
        /// </summary>
        /// <param name="bytes">byte array</param>
        /// <returns>
        /// <see cref="string"/> of text
        /// </returns>
        public static string ConvertToString(this byte[] bytes) => Constants.Encoding.GetString(bytes);
        /// <summary>
        /// Converts a stream of <see cref="byte[]"/> to a Base64 encoded
        /// <see cref="string"/> of text.
        /// </summary>
        /// <param name="bytes">Byte array</param>
        /// <returns>Base64 encoded <see cref="string"/></returns>
        public static string ToBase64String(this byte[] bytes) => Convert.ToBase64String(bytes);
        /// <summary>
        /// Converts a <see cref="byte[]"/> to a <see cref="Stream"/>
        /// </summary>
        /// <param name="bytes">Array of bytes to convert</param>
        /// <returns>A stream</returns>
        public static Stream ToStream(this byte[] bytes) => bytes.IsNotNull() ? new MemoryStream(bytes) : null;
    }
}
