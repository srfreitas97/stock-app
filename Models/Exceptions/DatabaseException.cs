using System;

namespace stock_app.Exceptions
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : base(message)
        {
            
        }
    }
}