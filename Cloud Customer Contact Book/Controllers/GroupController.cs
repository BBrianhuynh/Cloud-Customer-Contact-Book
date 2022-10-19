using Cloud_Customer_Contact_Book.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupsController : ControllerBase
{
    /// <summary>
    /// Returns group
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GroupModel>), StatusCodes.Status200OK)]
    public Task<IActionResult> GetAll()
    {
        var result = GenerateFew(_ => new GroupModel
        {
            Id = Random.Shared.NextInt64(),
            Name = Guid.NewGuid().ToString(),
            MemberCount = Random.Shared.Next(),
        });

        return Task.FromResult<IActionResult>(Ok(result));
    }
    /// <summary>
    /// Returns group with ID
    /// </summary>
    /// <param name="groupId">GroupId</param>
    /// <returns></returns>
    [HttpGet("{groupId:long}")]
    [ProducesResponseType(typeof(GroupModel), StatusCodes.Status200OK)]
    public Task<IActionResult> Get(long groupId)
    {
        var result = new GroupModel
        {
            Id = Random.Shared.NextInt64(),
            Name = Guid.NewGuid().ToString(),
            MemberCount = Random.Shared.Next(),
        };

        return Task.FromResult<IActionResult>(Ok(result));
    }
    /// <summary>
    /// Updates Group if ID exists
    /// Otherwise return a 404 if ID does not exist
    /// </summary>
    /// <param name="model">Model</param>
    [HttpPost]
    [ProducesResponseType(typeof(GroupModel), StatusCodes.Status200OK)]
    public Task<IActionResult> Post([FromBody] GroupCreateModel model)
    {
        var result = new GroupModel
        {
            Id = Random.Shared.NextInt64(),
            Name = model.Name,
            MemberCount = 0,
        };

        return Task.FromResult<IActionResult>(Ok(result));
    }
    /// <summary>
    /// Puts data into API to create a new group
    /// </summary>
    /// <param name="groupId">GroupId</param>
    /// <param name="model">Model</param>
    [HttpPut("{groupId:long}")]
    [ProducesResponseType(typeof(GroupModel), StatusCodes.Status200OK)]
    public Task<IActionResult> Put(long groupId, [FromBody] GroupCreateModel model)
    {
        var result = new GroupModel
        {
            Id = groupId,
            Name = model.Name,
            MemberCount = Random.Shared.Next(),
        };

        return Task.FromResult<IActionResult>(Ok(result));
    }
    /// <summary>
    /// Deletes group with specified ID
    /// </summary>
    /// <param name="groupId">GroupId</param>
    [HttpDelete("{groupId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<IActionResult> Delete(long groupId)
    {
        return Task.FromResult<IActionResult>(Ok());
    }
    /// <summary>
    /// Returns group ID from contacts
    /// </summary>
    /// <param name="groupId"></param>
    /// <returns></returns>
    [HttpGet("{groupId:long}/Contacts")]
    [ProducesResponseType(typeof(IEnumerable<long>), StatusCodes.Status200OK)]
    public Task<IActionResult> GetContacts(long groupId)
    {
        var result = GenerateFew(_ => Random.Shared.NextInt64());

        return Task.FromResult<IActionResult>(Ok(result));
    }

    private static IEnumerable<T> GenerateFew<T>(Func<int, T> generator)
    {
        var count = Random.Shared.Next(3, 10);
        return Enumerable.Range(0, count).Select(generator);
    }
}