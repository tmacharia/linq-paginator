using Common.Attributes;
using System.ComponentModel;
using System.Reflection;

namespace Common
{
    public static class AttributesExts
    {
        public static string GetSymbolAttribute<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            SymbolAttribute[] attributes = (SymbolAttribute[])fi.GetCustomAttributes(
                typeof(SymbolAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Symbol;
            else return source.ToString();
        }
        public static string DescriptionAttr<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
    }
}