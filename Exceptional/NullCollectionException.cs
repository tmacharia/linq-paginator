using System;
using System.Text;

namespace Exceptional
{
    public class NullCollectionException : Exception
    {
        private readonly StringBuilder _message = new StringBuilder();
        private string _param = string.Empty;
        
        public NullCollectionException(string paramName)
        {
            _param = paramName;
            _message.Append($"Source collection cannot be null.\nNull parameter: '{ParamName}'");
            _message.Append($"\n{Tips}");
        }

        public override string Message => _message.ToString();
        public string ParamName => _param;
        public string Tips
        {
            get
            {
                return $"Tips:\n\n1. Check if '{ParamName}' collection is null before calling .ToPaginate() method.\n2. Initialize your collection before using it to call .ToPaginate() method.";
            }
        }
    }
}
