using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class Arks
{
    public int ArkId {get; set;}

    [Required]
    public string? Name {get; set;}

    [Required]
    public string? Content {get; set;}

    [Required]
    public string? ImgUrl {get; set;}

    [Required]
    public string? Description {get; set;}
}