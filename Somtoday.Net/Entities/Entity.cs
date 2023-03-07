using Newtonsoft.Json.Linq;

namespace Somtoday.Net.Entities;

public abstract class Entity
{
    public SomtodayClient Client { get; set; }

    protected abstract string? UpdateUrl { get; }

    protected abstract void UpdateFromJson(JToken json);

    public async Task<bool> UpdateData()
    {
        if (UpdateUrl == null)
            return false;

        var result = await Client.Http.GetAsync(UpdateUrl);
        if (!result.IsSuccessStatusCode)
            return false;

        UpdateFromJson(JObject.Parse(await result.Content.ReadAsStringAsync()));
        return true;
    }

    internal static T Get<T>(SomtodayClient client, JToken json) where T : Entity, new()
    {
        var entity = new T();
        entity.Client = client;
        entity.UpdateFromJson(json);
        return entity;
    }
}
