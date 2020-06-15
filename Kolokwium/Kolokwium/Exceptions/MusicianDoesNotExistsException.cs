using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Exceptions
{
    public class MusicianDoesNotExistsException : Exception
    {
        public MusicianDoesNotExistsException()
        {
        }

        public MusicianDoesNotExistsException(string message) : base(message)
        {
        }

        public MusicianDoesNotExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
