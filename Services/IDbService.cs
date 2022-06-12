using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Services
{
    interface IDbService
    {
        Task<IEnumerable<object>> GetMusicians(int id);
    }
}
