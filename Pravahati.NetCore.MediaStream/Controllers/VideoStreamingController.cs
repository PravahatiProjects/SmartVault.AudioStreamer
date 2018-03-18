using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pravahati.NetCore.MediaStream.Service;

namespace Pravahati.NetCore.MediaStream.Controllers
{
    /// <summary>
    /// referenced from : http://anthonygiretti.com/2018/01/16/streaming-video-asynchronously-in-asp-net-core-2-with-web-api/
    /// </summary>
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class VideoStreamingController : Controller
    {
        private IVideoStreamService _streamingService;

        public VideoStreamingController(IVideoStreamService streamingService)
        {
            _streamingService = streamingService;
        }

        [HttpGet("{name}")]
        public async Task<FileStreamResult> Get(string name)
        {
            var stream = await _streamingService.GetVideoByName(name);
            return new FileStreamResult(stream, "video/mp4");
        }
    }
}