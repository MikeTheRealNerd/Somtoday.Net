using Newtonsoft.Json.Linq;

namespace Somtoday.Net.Entities;

public static class EntityExtensions
{
    public static T GetEntity<T>(this JToken json, SomtodayClient client) where T : Entity, new()
    {
        return Entity.Get<T>(client, json);
    }

    public static T[] GetEntities<T>(this JToken json, SomtodayClient client) where T : Entity, new()
    {
        if (json is not JArray array)
            return Array.Empty<T>();

        var result = new T[array.Count];

        for (var a = 0; a < result.Length; a++)
        {
            result[a] = array[a].GetEntity<T>(client);
        }

        return result;
    }
}
