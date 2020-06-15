using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Exceptions
{
    public class MusicianRelasedAnAlbumException : Exception
    {
        public MusicianRelasedAnAlbumException()
        {
        }

        public MusicianRelasedAnAlbumException(string message) : base(message)
        {
        }

        public MusicianRelasedAnAlbumException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
