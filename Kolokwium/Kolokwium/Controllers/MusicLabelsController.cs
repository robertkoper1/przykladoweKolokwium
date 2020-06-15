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
    [Route("api/music-labels")]
    [ApiController]
    public class MusicLabelsController : ControllerBase
    {
        private readonly IMusicDbService _dbService;
        public MusicLabelsController(IMusicDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id:int")]
        public IActionResult GetMusicLabel(int id)
        {
            try
            {
                var result = _dbService.GetMusicLabel(id);
                return Ok(result);
            }catch(MusicLabelDoesNotExistsException exc)
            {
                return NotFound(exc.Message);
            }
        }
    }
}