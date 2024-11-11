using Microsoft.AspNetCore.Mvc;
using Staffifyr.Application.Services;
using Staffifyr.Core.Entities;
using Staffifyr.Core.Repositories;
using Staffifyr.Core.ValueObjects;
using Staffifyr.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddSingleton<IPersonnelRepository, InMemoryPersonnelRepository>();
builder.Services.AddSingleton<PersonnelService>(provider =>
    new PersonnelService(provider.GetRequiredService<IPersonnelRepository>()));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();    

app.MapGet("/personnel", async (PersonnelService personnelService) =>
{
    var personnelList = await personnelService.GetAllPersonnelAsync();

    if(personnelList is null)
    {
        return Results.NotFound();
    }

    var personnelDtoList = new List<PersonnelDto>();
    foreach (var personnel in personnelList)
    {
        var personnelMap = new PersonnelDto(
            personnel.Id,
            personnel.Name,
            personnel.DateOfBirth,
            personnel.Age,
            personnel.EmailAddress.ToString(),
            personnel.PhoneNumber.ToString(),
            personnel.Address.Street,
            personnel.Address.City,
            personnel.Address.State,
            personnel.Address.PostalCode,
            personnel.Address.Country
        );

        personnelDtoList.Add(personnelMap);
    }
    return Results.Ok(personnelDtoList);
});

app.MapGet("/personnel/{id}", async (int id, PersonnelService personnelService) =>
{
    var personnel = await personnelService.GetPersonnelByIdAsync(id);

    if (personnel is null)
    {
        return Results.NotFound();
    }

    var personnelDto = new PersonnelDto(
        personnel.Id,
        personnel.Name,
        personnel.DateOfBirth,
        personnel.Age,
        personnel.EmailAddress.ToString(),
        personnel.PhoneNumber.ToString(),
        personnel.Address.Street,
        personnel.Address.City,
        personnel.Address.State,
        personnel.Address.PostalCode,
        personnel.Address.Country
    );

    return Results.Ok(personnelDto);
});

app.MapDelete("/personnel/{id}", async (int id, PersonnelService personnelService) =>
{
    var personnel = await personnelService.GetPersonnelByIdAsync(id);
    if (personnel is null)
    {
        return Results.NotFound();
    }
    await personnelService.DeletePersonnelAsync(id);
    return Results.NoContent();
});

app.MapPut("/personnel", async ([FromBody] PersonnelDto personnelDto, PersonnelService personnelService) =>
{
    var personnel = new Personnel(
        personnelDto.Id,
        personnelDto.Name,
        personnelDto.DateOfBirth,
        new Email(personnelDto.EmailAddress),
        new PhoneNumber(personnelDto.PhoneNumber),
        new Address(personnelDto.Street, personnelDto.City, personnelDto.State, personnelDto.PostalCode, personnelDto.Country)
    );
    await personnelService.UpdatePersonnelAsync(personnel);
    return Results.NoContent();
});

app.MapPost("/personnel", async ([FromBody] PersonnelDto personnelDto, PersonnelService personnelService) =>
{
    var personnel = new Personnel(
        personnelDto.Id,
        personnelDto.Name,
        personnelDto.DateOfBirth,
        new Email(personnelDto.EmailAddress),
        new PhoneNumber(personnelDto.PhoneNumber),
        new Address(personnelDto.Street, personnelDto.City, personnelDto.State, personnelDto.PostalCode, personnelDto.Country)
    );

    await personnelService.AddPersonnelAsync(personnel);
    return Results.Created($"/personnel/{personnel.Id}", personnel);
});

SeedData(app);

app.MapDefaultEndpoints();

app.Run();

void SeedData(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var personnelService = scope.ServiceProvider.GetRequiredService<PersonnelService>();

    var dummyPersonnel = new List<Personnel>
    {
        new Personnel(1, "John Doe", new DateTime(1985, 5, 15), new Email("john.doe@example.com"), new PhoneNumber("1234567890"), new Address("123 Main St", "Anytown", "Anystate", "12345", "USA")),
        new Personnel(2, "Jane Smith", new DateTime(1990, 7, 20), new Email("jane.smith@example.com"), new PhoneNumber("0987654321"), new Address("456 Elm St", "Othertown", "Otherstate", "67890", "USA"))
    };

    foreach (var personnel in dummyPersonnel)
    {
        personnelService.AddPersonnelAsync(personnel).Wait();
    }
}

public record PersonnelDto(int Id, string Name, DateTime DateOfBirth, int age, string EmailAddress, string PhoneNumber, string Street, string City, string State, string PostalCode, string Country);