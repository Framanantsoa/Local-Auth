using System.ComponentModel.DataAnnotations;

namespace DTO;

public class InfoUpdateDto : UserInfoDto
{
    public DateOnly? naissance {get; set;}
    public string nouveauMotDePasse { get; set; }
}
