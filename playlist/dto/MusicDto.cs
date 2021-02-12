using playlist.dto.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist.dto
{
    public class MusicDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public GenreMusicDto GenreMusic { get; set; }
    }
}
