using System;

namespace PhoneNumberFormatter.Exceptions
{
    public class PhoneNumberException : Exception
    {
        public PhoneNumberException()
            :base()
        {

        }
        public PhoneNumberException(string mobile,bool ignore=true)
            :base($"{mobile} is an invalid phone number or is not supported.")
        {

        }
        public PhoneNumberException(string message)
            :base(message)
        {

        }
        public PhoneNumberException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
