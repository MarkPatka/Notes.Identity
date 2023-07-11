using Notes.Identity.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Notes.Identity.Models;

public class LoginViewModel
{
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    public string ReturnUrl { get; set; } = string.Empty;

    public string? ReturnUrlHidden
    {
        get => ReturnUrl?.SerializeForHidden();
        set => ReturnUrl = value?.DeserializeForHidden(ReturnUrl) ?? string.Empty;
    }
}