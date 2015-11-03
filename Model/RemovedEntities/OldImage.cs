using System;
using Nettbutikk.Model;

namespace Model.RemovedEntities
{
    public class OldImage : Image
    {
        public int AdminId { get; set; }
        public DateTime Changed { get; set; }
    }
}
