using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend.Models;

public class User
{
    [JsonIgnore]
    public int UserId {get; set;}

    public string? FirstName {get; set;}

    public string? LastName {get; set;}

    [Required]
    public string? UserName {get; set;}

    [Required]
    public string? Password {get; set;}

    public string? FavoriteAnimal {get; set;}

    public bool ShowButton { get; set; }
}