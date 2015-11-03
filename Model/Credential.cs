using System.ComponentModel.DataAnnotations;

namespace Nettbutikk.Model
{    // PersonId / password combination
    public class Credential
    {
        [Key]
        public string Email { get; set; }
        public byte[] Password { get; set; }
    }
}
