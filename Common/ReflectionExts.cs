using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Common
{
    public static class ReflectionExts
    {
        private static IDictionary<Type, List<PropertyDescriptor>> _cache =
            new ConcurrentDictionary<Type, List<PropertyDescriptor>>();

        public static PropertyDescriptor[] GetPropertyDescriptors<TClass>(this TClass @class)
            where TClass : class
        {
            PropertyDescriptorCollection collection = null;
            if (_cache.ContainsKey(typeof(TClass)))
                return _cache[typeof(TClass)].ToArray();
            else
                collection = TypeDescriptor.GetProperties(typeof(TClass));
            
            List<PropertyDescriptor> properties = new List<PropertyDescriptor>();
            for (int i = 0; i < collection.Count; i++) {
                properties.Add(collection[i]);
            }
            _cache.Add(typeof(TClass), properties);
            return _cache[typeof(TClass)].ToArray();
        }
        /// <summary>
        /// Returns the value of a specific <see cref="class"/> property using a <see cref="delegate"/>
        /// to access class properties by Reflection.
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="class">Object value of type <typeparamref name="TClass"/></param>
        /// <param name="propertyName">Property name to return value of.</param>
        /// <returns></returns>
        public static TProperty GetPropertyValue<TClass, TProperty>(this TClass @class, string propertyName)
            where TClass : class
        {
            PropertyDescriptor prop = GetDescriptor(@class, propertyName);
            if (prop != null)
            {
                object obj = prop.GetValue(@class);
                if (obj != null)
                {
                    return (TProperty)obj;
                }
            }
            return default(TProperty);
        }

        /// <summary>
        /// Sets the value of a specific <see cref="class"/> property using an <see cref="Action delegate"/> to access
        /// and assign class properties by Reflection.
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="class"></param>
        /// <param name="propertyName">Property name to assign value to.</param>
        /// <param name="newValue">Value to assign the specified property.</param>
        public static void SetPropertyValue<TClass, TValue>(this TClass @class, string propertyName, TValue newValue)
            where TClass : class
        {
            PropertyDescriptor prop = GetDescriptor(@class, propertyName);

            if (prop != null)
            {
                prop.SetValue(@class, newValue);
            }
        }

        public static PropertyDescriptor GetDescriptor<TClass>(this TClass @class, string prop)
            where TClass : class
        {
            return GetPropertyDescriptors(@class).FirstOrDefault(x => x.Name == prop);
        }
        public static IEnumerable<TAttribute> GetAttributes<TClass, TAttribute>(this TClass @class, string prop)
            where TClass : class
            where TAttribute : Attribute
        {
            List<TAttribute> attributes = new List<TAttribute>();
            var enumerator = @class.GetDescriptor(prop).Attributes.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.GetType() == typeof(TAttribute))
                    attributes.Add((TAttribute)enumerator.Current);
            }
            return attributes;
        }
    }
}