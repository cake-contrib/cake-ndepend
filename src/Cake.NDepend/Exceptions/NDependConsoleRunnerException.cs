using System;

namespace Cake.NDepend.Exceptions
{
    public class NDependConsoleRunnerException : Exception
    {
        internal NDependConsoleRunnerException(string message) : base(message)
        {
        }
    }
}