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
    /// <param name="firstName">firstName</param>
    /// <param name="lastName">lastName</param>
    /// <param name="phoneNumber">phoneNumber</param>
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

    private object GenerateFew(Func<object, ContactModel> p)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns customer with the same ID
    /// </summary>
    /// <param name="contactId">ContactId</param>
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
    /// <param name="model">Model</param>
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
    /// <param name="contactId">ContactId</param>
    /// <param name="model">Model</param>
    [HttpPut("{contactId:long}")]
    [ProducesResponseType(typeof(ContactModel), StatusCodes.Status200OK)]
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
    /// <param name="contactId">ContactId</param>
    [HttpDelete("{contactId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<IActionResult> Delete(long contactId)
    {
        return Task.FromResult<IActionResult>(Ok());
    }
}