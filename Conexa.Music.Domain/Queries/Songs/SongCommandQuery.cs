using Conexa.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conexa.Music.Domain.Queries.Songs
{
    public class SongCommandQuery : Command
    {
        public string City { get; protected set; }
    }
}
