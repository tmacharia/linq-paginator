using System;

namespace Exceptional
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
            :base()
        {

        }
        public NotFoundException(Type type)
        {
            new NotFoundException(type.Name);
        }
        public NotFoundException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
        public NotFoundException(string name)
            : base(name + " not found.")
        {

        }
    }
}
