using Staffifyr.Core.Common;
using Staffifyr.Core.ValueObjects;

namespace Staffifyr.Core.Entities;

public class Personnel : Entity
{
    public string Name { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public Email EmailAddress { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public Address Address { get; private set; }

    public int Age => CalculateAge(DateOfBirth);

    public Personnel(int id, string name, DateTime dateOfBirth, Email emailAddress, PhoneNumber phoneNumber, Address address)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty", nameof(name));
        if (dateOfBirth == default) throw new ArgumentException("Date of birth cannot be empty", nameof(dateOfBirth));
        if (dateOfBirth > DateTime.UtcNow) throw new ArgumentException("Date of birth cannot be in the future", nameof(dateOfBirth));

        Id = id;
        Name = name;
        DateOfBirth = dateOfBirth;
        EmailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
        PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty", nameof(name));
        Name = name;
    }

    public void UpdateDateOfBirth(DateTime dateOfBirth)
    {
        if (dateOfBirth == default) throw new ArgumentException("Date of birth cannot be empty", nameof(dateOfBirth));
        if (dateOfBirth > DateTime.UtcNow) throw new ArgumentException("Date of birth cannot be in the future", nameof(dateOfBirth));
        DateOfBirth = dateOfBirth;
    }

    public void UpdateEmail(Email emailAddress)
    {
        EmailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
    }

    public void UpdatePhoneNumber(PhoneNumber phoneNumber)
    {
        PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
    }

    public void UpdateAddress(Address address)
    {
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }

    private int CalculateAge(DateTime dateOfBirth)
    {
        var today = DateTime.Today;
        var age = today.Year - dateOfBirth.Year;
        if (dateOfBirth.Date > today.AddYears(-age))
        {
            age--;
        }
        return age;
    }
}
