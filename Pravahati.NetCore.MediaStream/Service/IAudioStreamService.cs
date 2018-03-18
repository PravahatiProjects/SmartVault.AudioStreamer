using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pravahati.NetCore.MediaStream.Service
{
    public interface IAudioStreamService
    {
        Task<Stream> GetAudioByName(string name);
    }
}
