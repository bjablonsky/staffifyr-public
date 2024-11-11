namespace Staffifyr.Web.UI;

public class PersonnelApiClient(HttpClient httpClient)
{
    public async Task<PersonnelDto[]> GetAllPersonnelAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<PersonnelDto>? staff = null;

        await foreach (var personnel in httpClient.GetFromJsonAsAsyncEnumerable<PersonnelDto>("/personnel", cancellationToken))
        {
            if (staff?.Count >= maxItems)
            {
                break;
            }
            if (personnel is not null)
            {
                staff ??= [];
                staff.Add(personnel);
            }
        }

        return staff?.ToArray() ?? [];
    }

    public async Task<PersonnelDto?> GetPersonnelByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<PersonnelDto>($"/personnel/{id}", cancellationToken);
    }

    public async Task AddPersonnelAsync(PersonnelDto personnel, CancellationToken cancellationToken = default)
    {
        await httpClient.PostAsJsonAsync("/personnel", personnel, cancellationToken);
    }

    public async Task UpdatePersonnelAsync(PersonnelDto personnel, CancellationToken cancellationToken = default)
    {
        await httpClient.PutAsJsonAsync("/personnel", personnel, cancellationToken);
    }

    public async Task DeletePersonnelAsync(int id, CancellationToken cancellationToken = default)
    {
        await httpClient.DeleteAsync($"/personnel/{id}", cancellationToken);
    }
}

public class PersonnelDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int Age { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
}
