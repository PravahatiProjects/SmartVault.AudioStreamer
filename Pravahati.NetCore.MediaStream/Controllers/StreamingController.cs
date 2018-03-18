using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pravahati.NetCore.MediaStream.Service;

namespace Pravahati.NetCore.MediaStream.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class StreamingController : Controller
    {
        private IAzureVideoStreamService _streamingService;

        public StreamingController(IAzureVideoStreamService streamingService)
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