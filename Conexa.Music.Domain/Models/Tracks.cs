using System;
using System.Collections.Generic;
using System.Text;

namespace Conexa.Music.Domain.Models
{
    public class Tracks
    {
        public string href { get; set; }
        public List<Item> items { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
        public int offset { get; set; }
        public object previous { get; set; }
        public int total { get; set; }
    }
}
