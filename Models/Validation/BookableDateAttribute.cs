using System.ComponentModel.DataAnnotations;

namespace MidtermsApp.Models.Validation;

/// <summary>Rejects dates in the past, too soon to prepare for, or too far ahead.</summary>
[AttributeUsage(AttributeTargets.Property)]
public class BookableDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        if (value is not DateTime date)
            return ValidationResult.Success; // [Required] handles empty values

        var members = new[] { context.MemberName ?? nameof(BookingInquiry.EventDate) };
        var today = DateTime.Today;

        if (date.Date < today)
            return new ValidationResult("The event date can't be in the past.", members);

        if (date.Date < BookingRules.EarliestDate)
            return new ValidationResult($"Please book at least {BookingRules.MinDaysAhead} days ahead so we can prepare.", members);

        if (date.Date > BookingRules.LatestDate)
            return new ValidationResult("We take bookings up to 2 years ahead.", members);

        return ValidationResult.Success;
    }
}