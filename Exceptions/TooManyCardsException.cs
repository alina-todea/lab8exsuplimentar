using System;
namespace lab8ex1
{
    public class TooManyCardsException:Exception
    {
        public TooManyCardsException()
        {
        }
        public TooManyCardsException(string message) : base(message)
        {
            
        }

        public TooManyCardsException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
