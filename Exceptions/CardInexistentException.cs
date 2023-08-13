using System;
namespace lab8ex1.Exceptions
{
    public class CardInexistentException: Exception
    {
        public CardInexistentException()
        {
        }

        public CardInexistentException(string message) : base(message)
        {
        }
    }
}
