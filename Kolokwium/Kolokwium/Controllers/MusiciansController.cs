using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.Exceptions;
using Kolokwium.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [Route("api/musician")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        private readonly IMusicDbService _dbService;
        public MusiciansController(IMusicDbService dbService)
        {
            _dbService = dbService;
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult RemoveMusician(int id)
        {
            try
            {
                _dbService.RemoveMusician(id);
                return NoContent();
            }catch(MusicianDoesNotExistsException exc)
            {
                return NotFound(exc.Message);
            }
            catch(MusicianRelasedAnAlbumException exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}