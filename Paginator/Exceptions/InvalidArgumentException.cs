using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paginator.Exceptions
{
    /// <summary>
    /// Paginator.Exceptions.InvalidArgumentException is thrown when invalid or wrong arguments
    /// are passed into the .ToPaginate() function. 
    /// 
    /// Common scenario include using negative <see cref="int"/> numbers as 'page or itemsperpage' 
    /// request arguments. This is a logical error and cannot be processed.
    /// </summary>
    public class InvalidArgumentException : Exception
    {
        private readonly string _message = string.Empty;

        /// <summary>
        /// Exception thrown when certain arguments are logically in-correct for processing
        /// to take place.
        /// 
        /// </summary>
        /// <param name="argumentNames">String array of parameter names that are invalid.</param>
        public InvalidArgumentException(params string[] argumentNames)
        {
            _message = "Arguments '";

            for (int i = 0; i < argumentNames.Length; i++)
            {
                _message += argumentNames[i] + ", ";
            }

            _message = _message.TrimEnd(',',' ');
            _message += $"' cannot be negative. Only use positive/integers greater or equal to 0.";
        }
        /// <summary>
        /// Message generated/displayed when exception of type <see cref="InvalidArgumentException"/>
        /// is thrown.
        /// </summary>
        public override string Message
        {
            get
            {
                return _message;
            }
        }
    }
}
