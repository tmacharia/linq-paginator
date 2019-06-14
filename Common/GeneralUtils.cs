using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;

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

        /// <summary>
        /// Reflects all the properties in a model of generic <see cref="Type"/> that must be
        /// a <see cref="class"/> and returns a <see cref="IDictionary{string, string}"/> pairs 
        /// collection mapped in the following way:
        /// 
        /// Key: PropertyName,
        /// Value: PropertyValue
        /// </summary>
        /// <typeparam name="T">Type of model</typeparam>
        /// <param name="model">Model to reflect</param>
        /// <returns></returns>
        public static IDictionary<string, string> ToDictionary<T>(this T model)
            where T : class
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            Dictionary<string, string> pairs = new Dictionary<string, string>();
            PropertyDescriptor[] props = typeof(T).GetPropertyDescriptors();
            for (int i = 0; i < props.Length; i++)
            {
                string name = props[i].Name;
                pairs.Add(name, model.GetPropertyValue<T, string>(name));
            }
            return pairs;
        }
        public static string BytesToString(this long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }
    }
}