using Kolokwium.Exceptions;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Services
{
    public class SqlServerMusicDbService : IMusicDbService
    {
        private readonly MusicDbContext _context;
        public SqlServerMusicDbService(MusicDbContext context)
        {
            _context = context;
        }
        public MusicLabel GetMusicLabel(int id)
        {
            var musicLabel = _context.MusicLabels
                                     .Include(m => m.Albums)
                                     .SingleOrDefault(m => m.IdMusicLabel == id);

            if(musicLabel == null)
            {
                throw new MusicLabelDoesNotExistsException($"Music label with an id={id} does not exists");
            }

            musicLabel.Albums = musicLabel.Albums.OrderByDescending(m1 => m1.PublishDate).ToList();
            return musicLabel;
        }

        public void RemoveMusician(int id)
        {
            var musician = _context.Musicians
                                 .Include(m => m.MusicianTracks)
                                 .SingleOrDefault(m => m.IdMusician == id);

            if(musician == null)
            {
                throw new MusicianDoesNotExistsException($"Musician with an id={id} does not exists");
            }
            if(!_context.Tracks.Any(t => t.MusicianTracks.Any(mt => mt.IdMusician==id) && t.IdMusicAlbum != null))
            {
                throw new MusicianRelasedAnAlbumException($"Musician with an id={id} released at least a single album");
            }

            _context.MusicianTracks.RemoveRange(musician.MusicianTracks);
            _context.Musicians.Remove(musician);
            _context.SaveChanges();
        }
    }
}
