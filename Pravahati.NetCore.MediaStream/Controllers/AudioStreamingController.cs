using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pravahati.NetCore.MediaStream.Service;

namespace Pravahati.NetCore.MediaStream.Controllers
{
    [Produces("application/json")]
    [Route("api/AudioStreaming")]
    public class AudioStreamingController : Controller
    {
        private IAudioStreamService _streamingService;

        public AudioStreamingController(IAudioStreamService streamingService)
        {
            _streamingService = streamingService;
        }

        [HttpGet("{name}")]
        public async Task<FileStreamResult> Get(string name)
        {
            var stream = await _streamingService.GetAudioByName(name);
            return new FileStreamResult(stream, "audio/mp3");
        }
    }
}