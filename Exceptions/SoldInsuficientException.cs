using System;
namespace lab8ex1
{
    public class SoldInsuficientException:Exception
    {
        public SoldInsuficientException()
        {
        }
        public SoldInsuficientException(string message) : base(message)
        {
        }

        public SoldInsuficientException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
