using playlist.domain.repositories;
using playlist.dto.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist.usecase
{

    public interface IGetMusicsUseCase
    {
        Task<IEnumerable<dto.MusicDto>> Execult(string playListName, string singerName, string musicName, GenreMusicDto? genreMusicDto);
    }

    public class GetMusics: IGetMusicsUseCase
    {
        private readonly IMusicRepository _musicRepository;
        public GetMusics(IMusicRepository musicRepository)
        {
            this._musicRepository = musicRepository;
        }

        public async Task<IEnumerable<dto.MusicDto>> Execult(string playListName, string singerName, string musicName, GenreMusicDto? genreMusicDto)
        {
            if (!IsParamsValid(playListName, singerName, musicName, genreMusicDto))
            {
                throw new Exception("You must select a playListName or singerName or musicName");
            }

            return await this._musicRepository.GetMusicsAsync(playListName, singerName, musicName, (int?)genreMusicDto.Value);
        }

        private bool IsParamsValid(string playListName, string singerName, string musicName, GenreMusicDto? genreMusicDto)
        {
            return !string.IsNullOrEmpty(playListName) || !string.IsNullOrEmpty(singerName) || !string.IsNullOrEmpty(musicName) || genreMusicDto != null;
        }
    }
}
