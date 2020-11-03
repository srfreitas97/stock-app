using System;

namespace stock_app.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public int Id { get; set; }
        public ProductNotFoundException(string message,int id) : base(message)
        {
            Id = id;
        }
    }
}