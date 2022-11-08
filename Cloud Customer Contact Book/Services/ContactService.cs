using Cloud_Customer_Contact_Book.Models;
using CloudDatabase;
using CloudDatabase.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Services;

public class ContactService
{
    private readonly CloudContactBookContext context;

    public ContactService(CloudContactBookContext context)
    {
        this.context = context;
    }

    public async Task<List<ContactModel>> GetAll(string? firstName = default, string? lastName = default, string? phoneNumber = default)
    {
        var query = context.Contacts.AsQueryable();

        if (firstName != default)
            query = query.Where(x => x.FirstName == firstName);
        if (lastName != default)
            query = query.Where(x => x.LastName == lastName);
        if (phoneNumber != default)
            query = query.Where(x => x.PhoneNumber == phoneNumber);
        var result = await query.ToListAsync();
        return result.Select(ToContactModel).ToList();
    }

    public async Task<List<ContactModel>> GetByIds(params long[] ids)
    {
        var result = await context.Contacts.Where(x => ids.Contains(x.Id)).ToListAsync();
        return result.Select(ToContactModel).ToList();
    }

    public async Task<ContactModel> Create(ContactCreateModel model)
    {
        var newContact = new Contact
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
        };
        await context.Contacts.AddAsync(newContact);
        await context.SaveChangesAsync();

        return ToContactModel(newContact);
    }

    public async Task<ContactModel?> Update(long contactId, ContactCreateModel model)
    {
        var contact = await context.Contacts.Where(x => x.Id == contactId).FirstOrDefaultAsync();

        if (contact == null)
            return null;

        contact.FirstName = model.FirstName;
        contact.LastName = model.LastName;
        contact.PhoneNumber = model.PhoneNumber;

        await context.SaveChangesAsync();

        return ToContactModel(contact);
    }

    public async Task<bool> Delete(long contactId)
    {
        var contact = await context.Contacts.Where(x => x.Id == contactId).FirstOrDefaultAsync();

        if (contact == null)
            return false;

        context.Contacts.Remove(contact);
        await context.SaveChangesAsync();
        return true;
    }

    private static ContactModel ToContactModel(Contact contact)
    {
        return new ContactModel
        {
            Id = contact.Id,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            PhoneNumber = contact.PhoneNumber,
        };
    }

}