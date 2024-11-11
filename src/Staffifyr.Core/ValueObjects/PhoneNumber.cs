using Staffifyr.Core.Common;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Staffifyr.Core.ValueObjects;

public class PhoneNumber : ValueObject
{
    public string Number { get; private set; }

    public PhoneNumber(string number)
    {
        if (string.IsNullOrWhiteSpace(number)) throw new ArgumentException("Phone number cannot be empty", nameof(number));
        Number = number;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Number;
    }

    public override string ToString()
    {
        return Number;
    }
}
