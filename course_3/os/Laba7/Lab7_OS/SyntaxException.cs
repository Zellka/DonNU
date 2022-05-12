using System;

namespace Laba7.Exceptions
{
    internal class SyntaxException : Exception
    {
        public SyntaxException(string message):
            base(message)
        { }
    }
}
