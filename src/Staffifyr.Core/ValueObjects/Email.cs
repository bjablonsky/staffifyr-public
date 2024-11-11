using Staffifyr.Core.Common;
using System.IO;
using System.Text.RegularExpressions;

namespace Staffifyr.Core.ValueObjects;

public class Email : ValueObject
{
    public string EmailAddress { get; private set; }

    public Email(string emailAddress)
    {
        if (string.IsNullOrWhiteSpace(emailAddress)) throw new ArgumentException("Email address cannot be empty", nameof(emailAddress));
        EmailAddress = emailAddress;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return EmailAddress;
    }

    public override string ToString()
    {
        return EmailAddress;
    }
}
