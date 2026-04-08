using System.ComponentModel.DataAnnotations;

namespace ProfileMicroservice.Data.DTOs;

public class UserProfileDto
{
    [Required(ErrorMessage = "Имя пользователя обязательно")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Username должен быть от 3 до 50 символов")]
    [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username может содержать только латиницу, цифры и подчеркивание")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Имя обязательно для заполнения")]
    [StringLength(50, ErrorMessage = "Имя не может быть длиннее 50 символов")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Номер телефона обязателен")]
    [Phone(ErrorMessage = "Некорректный формат номера телефона")]
    public string PhoneNumber { get; set; } = string.Empty;

    [StringLength(50, ErrorMessage = "Фамилия не может быть длиннее 50 символов")]
    public string? LastName { get; set; }

    [StringLength(250, ErrorMessage = "О себе не более 250 символов")]
    public string? Bio { get; set; }
}