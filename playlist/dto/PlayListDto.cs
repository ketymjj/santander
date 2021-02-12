using System.Collections.Generic;

namespace playlist.dto
{
    public class PlayListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SingerDto> Singers  { get; set; }
    }
}
