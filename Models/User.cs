using System.ComponentModel.DataAnnotations;

namespace gradtest.Controllers
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public int Password { get; set; }
    }
}
