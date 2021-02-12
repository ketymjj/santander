using playlist.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist.domain.repositories
{
    public interface IMusicRepository
    {
        Task<IEnumerable<MusicDto>> GetMusicsAsync(string playListName, string singerName, string musicName, int? genderMusicId);
    }
}
