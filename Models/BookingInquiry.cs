using System.ComponentModel.DataAnnotations;
using MidtermsApp.Models.Validation;

namespace MidtermsApp.Models;

public class BookingInquiry
{
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, ErrorMessage = "First name is too long.")]
    public string FirstName { get; set; } = "";

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, ErrorMessage = "Last name is too long.")]
    public string LastName { get; set; } = "";

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Enter a valid email address.")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(@"^[0-9+\-\s()]{7,20}$", ErrorMessage = "Enter a valid phone number.")]
    public string Phone { get; set; } = "";

    [Required(ErrorMessage = "Select an event type.")]
    public string? EventType { get; set; }

    [Required(ErrorMessage = "Pick an event date.")]
    [BookableDate]
    public DateTime? EventDate { get; set; }

    [Required(ErrorMessage = "Pick a start time.")]
    public string? StartTime { get; set; }

    [Required(ErrorMessage = "Enter the number of guests.")]
    [Range(10, 500, ErrorMessage = "Guests must be between 10 and 500.")]
    public int? GuestCount { get; set; }

    [Required(ErrorMessage = "Tell us where the event is.")]
    [StringLength(120, ErrorMessage = "Venue is too long.")]
    public string Venue { get; set; } = "";

    public string? PreferredFlavor { get; set; }

    [StringLength(500, ErrorMessage = "Please keep details under 500 characters.")]
    public string? Message { get; set; }
}