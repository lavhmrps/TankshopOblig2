using System.ComponentModel.DataAnnotations.Schema;

namespace Nettbutikk.Model
{
    public class Admin : Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int AdminId {
            get { return Id; }
            set { Id = value; }
        }
    }
}
