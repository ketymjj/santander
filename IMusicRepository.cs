using System.Collections.Generic;

public interface IMusicRepository
{
	IEnumerable<SingerDto> GetMusics(string playListName, string singerName, string musicName);
}