using System;
namespace lab8ex1
{
    public class SumaInvalidaException:Exception
    {
        public SumaInvalidaException()
        {
        }
        public SumaInvalidaException(string message) : base(message)
        {
        }

        public SumaInvalidaException(string message, Exception inner) : base(message, inner)
        {
        }

       
        }
    }

