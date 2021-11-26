using System;

namespace MedProject.BusinessLogic.Exceptions
{
    public class MedException : Exception
    {
        public int StatusCode { get; set; } = 400;

        public MedException()
        {
        }

        public MedException(string message) : base(message)
        {
        }

        public MedException(string message, int statusCode) : base(message)
        {
            this.StatusCode = statusCode;
        }
    }
}
