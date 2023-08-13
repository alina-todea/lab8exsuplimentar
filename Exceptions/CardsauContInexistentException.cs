using System;
namespace lab8ex1.Exceptions
{
    public class CardsauContInexistentException: Exception
    {
        public CardsauContInexistentException()
        {
        }
        public CardsauContInexistentException(string message) : base(message)
        {

        }
    }
}
