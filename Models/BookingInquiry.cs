using System.ComponentModel.DataAnnotations;

namespace MidtermsApp.Models;

public class BookingInquiry
{
    [Required(ErrorMessage = "First name is required.")]
    public string FirstName { get; set; } = "";

    [Required(ErrorMessage = "Last name is required.")]
    public string LastName { get; set; } = "";

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Enter a valid email address.")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Pick an event date.")]
    public DateTime? EventDate { get; set; }

    [Required(ErrorMessage = "Select the estimated guests.")]
    public string? Guests { get; set; }

    public string? Message { get; set; }
}