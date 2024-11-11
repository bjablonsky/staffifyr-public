using Staffifyr.Core.Common;
using System.Reflection.Emit;

namespace Staffifyr.Core.ValueObjects;

public class Address : ValueObject
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string PostalCode { get; private set; }
    public string Country { get; private set; }

    public Address(string street, string city, string state, string postalCode, string country)
    {
        if (string.IsNullOrWhiteSpace(street)) throw new ArgumentException("Street cannot be empty", nameof(street));
        if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("City cannot be empty", nameof(city));
        if (string.IsNullOrWhiteSpace(state)) throw new ArgumentException("State cannot be empty", nameof(state));
        if (string.IsNullOrWhiteSpace(postalCode)) throw new ArgumentException("Postal code cannot be empty", nameof(postalCode));
        if (string.IsNullOrWhiteSpace(country)) throw new ArgumentException("Country cannot be empty", nameof(country));

        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return State;
        yield return PostalCode;
        yield return Country;        
    }
}
