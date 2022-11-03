using Cloud_Customer_Contact_Book.Models;
using CloudDatabase;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Services;

public class ContactService
{
    private readonly CloudContactBookContext context;

    public ContactService (CloudContactBookContext context)
    {
        this.context = context;
    }

    public async Task<List<ContactModel>> GetAll(string? firstName = default, string? lastName = default, string? phoneNumber = default)
    {
        var list = await context.Contacts.ToListAsync();
        var result = GenerateFew(_ => new ContactModel
        {
            Id = Random.Shared.NextInt64(),
            FirstName = firstName ?? "John",
            LastName = lastName ?? "Smith",
            PhoneNumber = phoneNumber ?? "+12345678900",
        });
        return list.Select(x => new ContactModel { Id = x.Id, FirstName = x.Name}).ToList();
    }

    public async Task<List<ContactModel>> GetByIds(params long[] ids)
    {
        var result = ids.Select(id => new ContactModel
        {
            Id = id,
            FirstName = "John",
            LastName = "Smith",
            PhoneNumber = "+12345678900",
        });

        return result.ToList();
    }

    public async Task<ContactModel> Create(ContactCreateModel model)
    {
        var result = new ContactModel
        {
            Id = Random.Shared.NextInt64(),
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
        };

        return result;
    }

    public async Task<ContactModel?> Update(long contactId, ContactCreateModel model)
    {
        var result = new ContactModel
        {
            Id = contactId,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
        };

        return result;
    }

    public async Task<bool> Delete(long contactId)
    {
        return true;
    }

    private static IEnumerable<T> GenerateFew<T>(Func<int, T> generator)
    {
        var count = Random.Shared.Next(3, 10);
        return Enumerable.Range(0, count).Select(generator);
    }
}