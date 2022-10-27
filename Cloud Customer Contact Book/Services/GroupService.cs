﻿using Cloud_Customer_Contact_Book.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Services;

public class GroupService
{
    private readonly ContactService _contactService;

    public async Task<List<GroupModel>> GetAll()
    {
        var result = GenerateFew(_ => new GroupModel
        {
            Id = Random.Shared.NextInt64(),
            Name = Guid.NewGuid().ToString(),
            MemberCount = Random.Shared.Next(),
        });

        return result.ToList();
    }

    public async Task<GroupModel?> Get(long groupId)
    {
        var result = new GroupModel
        {
            Id = groupId,
            Name = Guid.NewGuid().ToString(),
            MemberCount = Random.Shared.Next(),
        };

        return result;
    }

    public async Task<GroupModel> Create([FromBody] GroupCreateModel model)
    {
        var result = new GroupModel
        {
            Id = Random.Shared.NextInt64(),
            Name = model.Name,
            MemberCount = 0,
        };

        return result;
    }

    public async Task<GroupModel?> Update(long groupId, [FromBody] GroupCreateModel model)
    {
        var result = new GroupModel
        {
            Id = groupId,
            Name = model.Name,
            MemberCount = Random.Shared.Next(),
        };

        return result;
    }

    public async Task<bool> Delete(long groupId)
    {
        return true;
    }

    public async Task<List<ContactModel>> GetContacts(long groupId)
    {
        var contactIds = GenerateFew(_ => Random.Shared.NextInt64());

        return await _contactService.GetByIds(contactIds.ToArray());
    }

    private static IEnumerable<T> GenerateFew<T>(Func<int, T> generator)
    {
        var count = Random.Shared.Next(3, 10);
        return Enumerable.Range(0, count).Select(generator);
    }

    public GroupService(ContactService contactService)
    {
        _contactService = contactService;
    }
}