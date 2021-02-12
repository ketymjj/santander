using Npgsql;
using playlist.domain.repositories;
using playlist.dto.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist.db.repositories
{
    public class MusicRepository : IMusicRepository
    {
        public async Task<IEnumerable<dto.MusicDto>> GetMusicsAsync(string playListName, string singerName, string musicName, int? genderMusicId)
        {
            var cs = "postgres://postgres:teste@localhost:5432/playlist";

            using var con = new NpgsqlConnection(cs);

            var query = @"select m.*, s.*, p.* 
                            from singer as s
                            left join music as p on s.id = m.singer_id
                            left join playlist p on p.singer_id = s.id
                            where p.name = @playListName
                            or m.gender_id = @gender_id
                            or m.name = @musicname
                            or s.name = @singerName";

            con.Open();

            var cmd = new NpgsqlCommand(query, con);

            cmd.Parameters.AddWithValue("playListName", playListName);

            if(genderMusicId == null)
            {
                cmd.Parameters.AddWithValue("gender_id", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("gender_id", genderMusicId);
            }

          
            cmd.Parameters.AddWithValue("musicname", musicName);
            cmd.Parameters.AddWithValue("singerName", singerName);

            var dr = await cmd.ExecuteReaderAsync();
            var musics = new List<dto.MusicDto>();

            while (dr.Read())
            {
                musics.Add(new dto.MusicDto 
                {
                    Id = (int) dr["m.di"],
                    Name = dr["m.name"].ToString(),
                    GenreMusic = (GenreMusicDto) Convert.ToInt32(dr["m.name"])
                });
            }

            return musics;
        }
    }
}
