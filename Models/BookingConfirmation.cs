namespace MidtermsApp.Models;

public class BookingConfirmation
{
    public string Reference { get; init; } = "";
    public BookingInquiry Inquiry { get; init; } = new();
    public DateTime SubmittedAt { get; init; }
}