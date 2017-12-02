using System;

namespace Cake.NDepend.Exceptions
{
    public class NDependSettingsOptionException : Exception
    {
        internal NDependSettingsOptionException(string message) : base(message)
        {
        }
    }
}