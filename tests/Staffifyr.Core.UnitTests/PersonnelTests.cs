using System;
using Staffifyr.Core.Entities;
using Staffifyr.Core.ValueObjects;
using Xunit;

namespace Staffifyr.Core.UnitTests;

public class PersonnelTests
{
    [Fact]
    public void ShouldCreatePersonnel()
    {
        // Arrange
        var id = 1;
        var name = "John Doe";
        var dateOfBirth = new DateTime(1985, 5, 15);
        var email = new Email("john.doe@example.com");
        var phoneNumber = new PhoneNumber("1234567890");
        var address = new Address("123 Main St", "Anytown", "Anystate", "12345", "USA");

        // Act
        var personnel = new Personnel(id, name, dateOfBirth, email, phoneNumber, address);

        // Assert
        Assert.Equal(id, personnel.Id);
        Assert.Equal(name, personnel.Name);
        Assert.Equal(dateOfBirth, personnel.DateOfBirth);
        Assert.Equal(email, personnel.EmailAddress);
        Assert.Equal(phoneNumber, personnel.PhoneNumber);
        Assert.Equal(address, personnel.Address);
    }

    [Fact]
    public void ShouldUpdateName()
    {
        // Arrange
        var personnel = CreateSamplePersonnel();
        var newName = "Jane Doe";

        // Act
        personnel.UpdateName(newName);

        // Assert
        Assert.Equal(newName, personnel.Name);
    }

    [Fact]
    public void ShouldUpdateDateOfBirth()
    {
        // Arrange
        var personnel = CreateSamplePersonnel();
        var newDateOfBirth = new DateTime(1990, 7, 20);

        // Act
        personnel.UpdateDateOfBirth(newDateOfBirth);

        // Assert
        Assert.Equal(newDateOfBirth, personnel.DateOfBirth);
    }

    [Fact]
    public void ShouldUpdateEmail()
    {
        // Arrange
        var personnel = CreateSamplePersonnel();
        var newEmail = new Email("jane.doe@example.com");

        // Act
        personnel.UpdateEmail(newEmail);

        // Assert
        Assert.Equal(newEmail, personnel.EmailAddress);
    }

    [Fact]
    public void ShouldUpdatePhoneNumber()
    {
        // Arrange
        var personnel = CreateSamplePersonnel();
        var newPhoneNumber = new PhoneNumber("0987654321");

        // Act
        personnel.UpdatePhoneNumber(newPhoneNumber);

        // Assert
        Assert.Equal(newPhoneNumber, personnel.PhoneNumber);
    }

    [Fact]
    public void ShouldUpdateAddress()
    {
        // Arrange
        var personnel = CreateSamplePersonnel();
        var newAddress = new Address("456 Elm St", "Othertown", "Otherstate", "67890", "USA");

        // Act
        personnel.UpdateAddress(newAddress);

        // Assert
        Assert.Equal(newAddress, personnel.Address);
    }

    private Personnel CreateSamplePersonnel()
    {
        return new Personnel(
            1,
            "John Doe",
            new DateTime(1985, 5, 15),
            new Email("john.doe@example.com"),
            new PhoneNumber("1234567890"),
            new Address("123 Main St", "Anytown", "Anystate", "12345", "USA")
        );
    }
}