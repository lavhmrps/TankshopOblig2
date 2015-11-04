using System;

namespace Nettbutikk.Model.RemovedEntities
{
    public class OldImage : Image, IChangedEntity
    {
        public Admin Changer { get; set; }
        public DateTime Changed { get; set; }
    }
}
