using Cloud_Customer_Contact_Book.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactsController : ControllerBase
{
    /// <summary>
    /// Returns customer
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="phoneNumber"></param>

    [HttpGet]
    public Task<IActionResult> GetAll(string? firstName = default, string? lastName = default, string? phoneNumber = default)
    {
        var result = GenerateFew(_ => new ContactModel
        {
            Id = Random.Shared.NextInt64(),
            FirstName = firstName ?? "John",
            LastName = lastName ?? "Smith",
            PhoneNumber = phoneNumber ?? "+12345678900",
        });

        return Task.FromResult<IActionResult>(Ok(result));
    }
    /// <summary>
    /// Returns customer with the same ID
    /// </summary>
    /// <param name="contactId"></param>
    [HttpGet("{contactId:long}")]
    public Task<IActionResult> Get(long contactId)
    {
        var result = new ContactModel
        {
            Id = Random.Shared.NextInt64(),
            FirstName = "John",
            LastName = "Smith",
            PhoneNumber = "+12345678900",
        };

        return Task.FromResult<IActionResult>(Ok(result));
    }
    /// <summary>
    /// Updates customer if specificed ID exists
    /// otherwise returns a 404 if ID does not exist
    /// </summary>
    /// <param name="model"></param>
    [HttpPost]
    public Task<IActionResult> Post([FromBody] ContactCreateModel model)
    {
        var result = new ContactModel
        {
            Id = Random.Shared.NextInt64(),
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
        };

        return Task.FromResult<IActionResult>(Ok(result));
    }
    /// <summary>
    /// Puts data into API to create a new customer
    /// </summary>
    /// <param name="contactId"></param>
    /// <param name="model"></param>
    [HttpPut("{contactId:long}")]
    public Task<IActionResult> Put(long contactId, [FromBody] ContactCreateModel model)
    {
        var result = new ContactModel
        {
            Id = contactId,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
        };

        return Task.FromResult<IActionResult>(Ok(result));
    }
    /// <summary>
    /// Deletes customer with the specified ID
    /// </summary>
    /// <param name="contactId"></param>
    [HttpDelete("{contactId:long}")]
    public Task<IActionResult> Delete(long contactId)
    {
        return Task.FromResult<IActionResult>(Ok());
    }
}