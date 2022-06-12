using kolokwium.Models;
using kolokwium.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Services
{
    public class DbService
    {
        private readonly s20373Context _dbContext;
        
        public DbService(s20373Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MusicianDTO>> GetMusicians(int id)
        {
            return await _dbContext.Musicians
                .Select(e => new MusicianDTO
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Nickname = e.Nickname,
                    MusicianTracks = e.MusicianTracks
                })
               .Where(e => e.IdMusician == id)
               // .OrderBy(e => e.Duration)
               .ToListAsync();
        }

    }
}
