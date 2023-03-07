﻿using Newtonsoft.Json.Linq;
using Somtoday.Net.Entities;

namespace Somtoday.Net;

public class SomtodayClient
{
    internal readonly HttpClient Http = new();

    public SomtodayClient()
    {
        Http.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    public async Task<Organization[]> GetOrganizationsAsync()
    {
        var result = await Http.GetAsync("https://servers.somtoday.nl/organisaties.json");
        if (!result.IsSuccessStatusCode)
            return Array.Empty<Organization>();

        var json = JToken.Parse(await result.Content.ReadAsStringAsync()).First.First.First;
        return json.GetEntities<Organization>(this);
    }
}