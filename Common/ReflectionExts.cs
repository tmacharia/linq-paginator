using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common
{
    public static class ReflectionExts
    {
        /// <summary>
        /// Returns the value of a specific <see cref="class"/> property using a <see cref="delegate"/>
        /// to access class properties by Reflection.
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="class">Object value of type <typeparamref name="TClass"/></param>
        /// <param name="propertyName">Property name to return value of.</param>
        /// <returns></returns>
        public static TProperty GetPropertyValue<TClass, TProperty>(this TClass @class, string propertyName)
            where TClass : class {

            Func<TClass, TProperty> getter = Delegate.CreateDelegate(
                                                        typeof(Func<TClass, TProperty>), null,
                                                            typeof(TClass).GetProperty(propertyName).GetGetMethod())
                                                        as Func<TClass, TProperty>;
            return getter(@class);
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
            where TClass : class {

            Action<TClass, TValue> setter = Delegate.CreateDelegate(
                                                     typeof(Action<TClass, TValue>), null,
                                                        typeof(TClass).GetProperty(propertyName).GetSetMethod())
                                                     as Action<TClass, TValue>;
            setter(@class, newValue);
        }
    }
}
