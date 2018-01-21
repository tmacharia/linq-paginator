using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Paginator.Exceptions
{
    public class NullCollectionException : Exception
    {
        private readonly string _message = string.Empty;
        private string _param = string.Empty;
        
        public NullCollectionException(string paramName)
        {
            _param = paramName;
            _message = $"Source collection cannot be null.\nNull parameter: '{ParamName}'";
            _message += $"\n{Tips}";
        }

        public override string Message => _message;
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
