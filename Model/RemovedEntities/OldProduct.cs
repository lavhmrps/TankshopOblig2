using System;

namespace Nettbutikk.Model.RemovedEntities
{
    public class OldProduct : Product, IChangedEntity
    {
        public Admin Changer { get; set; }
        public DateTime Changed { get; set; }
    }
}
