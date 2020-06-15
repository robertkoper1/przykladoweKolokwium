using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Exceptions
{
    public class MusicLabelDoesNotExistsException : Exception
    {
        public MusicLabelDoesNotExistsException(string message) : base
            (message)
        {

        }
        public MusicLabelDoesNotExistsException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public MusicLabelDoesNotExistsException()
        {

        }
    }
}
