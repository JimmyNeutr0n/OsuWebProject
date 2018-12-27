using Back_End.Models;
using Back_End.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    public class MapController : Controller
    {
        private readonly MapService _mapService;

        public MapController(MapService mapService)
        {
            _mapService = mapService;
        }

        [Route("api/[controller]/Maps")]
        [HttpGet("[action]")]
        public async Task<IActionResult> AsyncMaps()
        {
            var data = await _mapService.AsyncGetMaps(0, 10);

            return Ok(data);
        }

        [Route("api/[controller]/InsertMap")]
        [HttpGet("[action]")]
        public async Task<IActionResult> AsyncCreateMap([FromBody]MapModel model)
        {
            await _mapService.AsyncInsert(model);

            return Ok();
        }
    }
}
