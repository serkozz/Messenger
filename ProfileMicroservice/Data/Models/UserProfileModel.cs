using System.ComponentModel.DataAnnotations;

namespace ProfileMicroservice.Data.Models;

public class UserProfileModel
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? LastName { get; set; }
    
    [MaxLength(250)]
    public string? Bio { get; set; }
}