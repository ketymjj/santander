using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using playlist.dto.enums;
using playlist.usecase;

namespace playlist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        IGetMusicsUseCase getMusicsUseCase;
        public MusicController(IGetMusicsUseCase getMusicsUseCase)
        {
            this.getMusicsUseCase = getMusicsUseCase;
        }

        [HttpGet("{playListName}/{singerName}/{musicName}/{genreId}")]
        public async Task<ActionResult> GetMusic(string playListName, string singerName, string musicName, int? genreId)
        {

            var gender = genreId == null ? null : (GenreMusicDto?)genreId;

           var result = await this.getMusicsUseCase.Execult(playListName, singerName, musicName, gender);

           return Ok(result);

        }
    }
}
