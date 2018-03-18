using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pravahati.NetCore.MediaStream.Service
{
    public class AudioStreamService : IAudioStreamService
    {
        private HttpClient _client;

        public AudioStreamService()
        {
            _client = new HttpClient();
        }

        public async Task<Stream> GetAudioByName(string name)
        {
            var urlBlob = string.Empty;
            switch (name)
            {
                case "sample":
                    urlBlob = "http://transom.org/wp-content/uploads/2004/03/200206.hodgman8.mp3";
                    break;
                default:
                    urlBlob = "http://transom.org/wp-content/uploads/2004/03/200206.hodgman8.mp3";
                    break;
            }
            return await _client.GetStreamAsync(urlBlob);
        }

        ~AudioStreamService()
        {
            if (_client != null)
                _client.Dispose();
        }
    }
}
