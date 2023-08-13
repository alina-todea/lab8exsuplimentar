using System;
namespace lab8ex1
{
    public class ContInexistentException:Exception
    {
        public ContInexistentException()
        {
        }

        public ContInexistentException(string message) : base(message)
        {
        }

        public ContInexistentException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
