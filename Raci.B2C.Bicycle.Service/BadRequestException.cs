using System;

namespace Raci.B2C.Bicycle.Service
{
    public class BadRequestException : Exception
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string msg) : base(msg)
        {
        }
    }
}