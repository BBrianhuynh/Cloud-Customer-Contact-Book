using Cloud_Customer_Contact_Book.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupsController : ControllerBase
{
    private readonly GroupService _groupService;

    /// <summary>
    /// Returns group
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GroupModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _groupService.GetAll();

        return Ok(result);
    }

    /// <summary>
    /// Returns group with ID
    /// </summary>
    /// <param name="groupId">GroupId</param>
    /// <returns></returns>
    [HttpGet("{groupId:long}")]
    [ProducesResponseType(typeof(GroupModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(long groupId)
    {
        var result = await _groupService.Get(groupId);
        return result == default ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Updates Group if ID exists
    /// Otherwise return a 404 if ID does not exist
    /// </summary>
    /// <param name="model">Model</param>
    [HttpPost]
    [ProducesResponseType(typeof(GroupModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Post([FromBody] GroupCreateModel model)
    {
        var result = await _groupService.Create(model);
        return Ok(result);
    }

    /// <summary>
    /// Puts data into API to create a new group
    /// </summary>
    /// <param name="groupId">GroupId</param>
    /// <param name="model">Model</param>
    [HttpPut("{groupId:long}")]
    [ProducesResponseType(typeof(GroupModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(long groupId, [FromBody] GroupCreateModel model)
    {
        var result = await _groupService.Update(groupId, model);

        return result == default ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Deletes group with specified ID
    /// </summary>
    /// <param name="groupId">GroupId</param>
    [HttpDelete("{groupId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(long groupId)
    {
        return await _groupService.Delete(groupId) ? Ok() : NotFound();
    }

    /// <summary>
    /// Returns group ID from contacts
    /// </summary>
    /// <param name="groupId"></param>
    /// <returns></returns>
    [HttpGet("{groupId:long}/Contacts")]
    [ProducesResponseType(typeof(IEnumerable<long>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetContacts(long groupId)
    {
        var result = await _groupService.GetContacts(groupId);

        return Ok(result);
    }

    public GroupsController(GroupService groupService)
    { 
        _groupService = groupService;
    }
}