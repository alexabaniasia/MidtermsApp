using MidtermsApp.Models;

namespace MidtermsApp.Services;

public class BookingService
{
    private readonly List<BookingConfirmation> _bookings = new();
    private readonly object _lock = new();

    /// <summary>We have one cart, so only one booking per date.</summary>
    public bool IsDateAvailable(DateTime date)
    {
        lock (_lock)
        {
            return !_bookings.Any(b => b.Inquiry.EventDate!.Value.Date == date.Date);
        }
    }

    public BookingConfirmation Submit(BookingInquiry inquiry)
    {
        lock (_lock)
        {
            var confirmation = new BookingConfirmation
            {
                Reference = $"MM-{inquiry.EventDate!.Value:yyyyMMdd}-{_bookings.Count + 1:D3}",
                Inquiry = inquiry,
                SubmittedAt = DateTime.Now
            };
            _bookings.Add(confirmation);
            return confirmation;
        }
    }
}