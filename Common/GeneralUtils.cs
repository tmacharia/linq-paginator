using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public static class GeneralUtils
    {
        public static MD5 md5 = MD5.Create();
        /// <summary>
        /// Checks if an object is not null
        /// </summary>
        /// <param name="value">Object to check</param>
        /// <returns>true or false</returns>
        public static bool IsNotNull(this object value) => value != null;
        /// <summary>
        /// Checks if an object is null
        /// </summary>
        /// <param name="value"><see cref="object"/> to check</param>
        /// <returns></returns>
        public static bool IsNull(this object value) => value == null;
        /// <summary>
        /// Serializes an object of generic type to JSON <see cref="string"/>
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">Object/Model/Item to serialize</param>
        /// <returns>JSON text</returns>
        public static string ToJson<T>(this T value) where T : class
                => JsonConvert.SerializeObject(value);
        /// <summary>
        /// Deserializes JSON formatted <see cref="string"/> of text to a strongly typed
        /// generic of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">Type to deserialize to</typeparam>
        /// <param name="json">JSON text</param>
        /// <returns></returns>
        public static T DeserializeTo<T>(this string json)
                => JsonConvert.DeserializeObject<T>(json,
                    new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        /// <summary>
        /// Converts a decimal number to an integer
        /// </summary>
        /// <param name="d">Value to convert</param>
        /// <returns>Integral equivalent</returns>
        public static int? ToInt(this object value) =>
            value.IsNotNull() ? (int?)Convert.ToInt32(value, Constants.Culture) : 0;
    }
}
