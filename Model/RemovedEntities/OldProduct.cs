using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nettbutikk.Model.RemovedEntities
{
    public class OldProduct : Product
    {
        [Key]
        public new int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int OldId
        {
            get { return base.Id; }
            set { base.Id = value; }
        }
    }
}
