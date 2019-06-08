using System;

namespace Lopak.Application.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string text)
            : base($" \"{text}\".")
        {
        }
    }
}