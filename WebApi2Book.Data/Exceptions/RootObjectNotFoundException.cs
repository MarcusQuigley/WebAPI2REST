using System;

namespace WebApi2Book.Data.Exceptions
{
    public class RootObjectNotFoundException : Exception
    {
        public RootObjectNotFoundException(string message)
            :base(message)
        {

        }
    }
}
