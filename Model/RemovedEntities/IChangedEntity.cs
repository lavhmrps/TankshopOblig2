using System;

namespace Nettbutikk.Model.RemovedEntities
{
    internal interface IChangedEntity
    {
        Admin Changer { get; set; }
        DateTime Changed { get; set; }
    }
}