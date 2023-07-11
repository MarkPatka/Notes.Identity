using Microsoft.AspNetCore.Mvc;
using Notes.Identity.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Notes.Identity.Models;

public class RegisterViewModel
{
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = string.Empty;

    public string ReturnUrl { get; set; } = string.Empty;

    public string? ReturnUrlHidden
    {
        get => ReturnUrl.SerializeForHidden();
        set => ReturnUrl = value?.DeserializeForHidden(ReturnUrl) ?? string.Empty;
    }
}