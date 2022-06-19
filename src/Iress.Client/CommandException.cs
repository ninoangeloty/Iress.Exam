using System;
using System.Collections.Generic;
using System.Text;

namespace Iress.Client
{
    /// <summary>
    /// Exception for handling command related errors
    /// </summary>
    public class CommandException : Exception
    {
        public CommandException()
        {
        }

        public CommandException(string message)
            : base(message)
        {
        }

        public CommandException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
