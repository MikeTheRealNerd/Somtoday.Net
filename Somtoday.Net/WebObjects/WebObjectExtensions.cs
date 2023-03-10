using Newtonsoft.Json.Linq;

namespace Somtoday.Net.WebObjects;

public static class WebObjectExtensions
{
    public static T GetEntity<T>(this JToken json, SomtodayClient client) where T : WebObject, new()
    {
        return WebObject.Get<T>(client, json);
    }

    public static T[] GetEntities<T>(this JToken json, SomtodayClient client) where T : WebObject, new()
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
