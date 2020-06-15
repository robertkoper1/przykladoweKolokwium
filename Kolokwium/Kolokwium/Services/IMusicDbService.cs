using Kolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public interface IMusicDbService
    {
        MusicLabel GetMusicLabel(int id);
        void RemoveMusician(int id);
    }
}
