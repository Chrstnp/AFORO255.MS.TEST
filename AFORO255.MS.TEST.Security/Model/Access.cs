using System.ComponentModel.DataAnnotations;

namespace AFORO255.MS.TEST.Security.Model
{
    public class Access
    {
        [Key]
        public int id_user { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
