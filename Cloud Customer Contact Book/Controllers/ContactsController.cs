using Cloud_Customer_Contact_Book.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactsController : ControllerBase
{
    private readonly ContactService _contactService;
    /// <summary>
    /// Returns customer
    /// </summary>
    /// <param name="firstName">firstName</param>
    /// <param name="lastName">lastName</param>
    /// <param name="phoneNumber">phoneNumber</param>
    [HttpGet]
    public async Task<IActionResult> GetAll(string? firstName = default, string? lastName = default, string? phoneNumber = default)
    {
        var result = await _contactService.GetAll(firstName, lastName, phoneNumber);
        return Ok(result);
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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(long contactId)
    {
        var result = await _contactService.GetByIds(contactId);

        return result.Count == 0 ? NotFound() : Ok(result[0]);
    }
    /// <summary>
    /// Updates customer if specificed ID exists
    /// otherwise returns a 404 if ID does not exist
    /// </summary>
    /// <param name="model">Model</param>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ContactCreateModel model)
    {
        var result = await _contactService.Create(model);

        return Ok(result);
    }
    /// <summary>
    /// Puts data into API to create a new customer
    /// </summary>
    /// <param name="contactId">ContactId</param>
    /// <param name="model">Model</param>
    [HttpPut("{contactId:long}")]
    [ProducesResponseType(typeof(ContactModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Put(long contactId, [FromBody] ContactCreateModel model)
    {
        var result = await _contactService.Update(contactId, model);

        return result == default ? NotFound() : Ok(result);
    }
    /// <summary>
    /// Deletes customer with the specified ID
    /// </summary>
    /// <param name="contactId">ContactId</param>
    [HttpDelete("{contactId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(long contactId)
    {
        var result = await _contactService.Delete(contactId);
        return result ? Ok() : NotFound();
    }
}