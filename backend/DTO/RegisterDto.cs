using System.ComponentModel.DataAnnotations;
using Validations;

namespace DTO;

public class RegisterDto : UserInfoDto
{
    public DateOnly? naissance {get; set;}
}
