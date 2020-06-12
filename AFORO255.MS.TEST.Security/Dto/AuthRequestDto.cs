using System.ComponentModel.DataAnnotations;

namespace AFORO255.MS.TEST.Security.Dto
{
    public class AuthRequestDto
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
