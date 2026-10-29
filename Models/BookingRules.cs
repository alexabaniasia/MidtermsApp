namespace MidtermsApp.Models;

/// <summary>Business rules for cart bookings, shared by validation, UI and services.</summary>
public static class BookingRules
{
    public const int MinDaysAhead = 3;
    public const int MaxDaysAhead = 730;
    public const int MinGuests = 10;
    public const int MaxGuests = 500;

    public static DateTime EarliestDate => DateTime.Today.AddDays(MinDaysAhead);
    public static DateTime LatestDate => DateTime.Today.AddDays(MaxDaysAhead);

    public static readonly string[] EventTypes =
    {
        "Birthday Party", "Wedding", "Corporate Event", "School or Community Event", "Other"
    };

    public static readonly string[] TimeSlots =
    {
        "10:00 AM", "11:00 AM", "12:00 PM", "1:00 PM", "2:00 PM",
        "3:00 PM", "4:00 PM", "5:00 PM", "6:00 PM", "7:00 PM"
    };
}