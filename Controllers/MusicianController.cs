using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using kolokwium.Models;
using kolokwium.Services;

namespace kolokwium.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicianController : Controller
    {
        private readonly IDbService _dbService;


        public MusicianController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMusicians(int id)
        {
            var result = await _dbService.GetMusicians(id);
            return Ok(result);
        }

    }
}
