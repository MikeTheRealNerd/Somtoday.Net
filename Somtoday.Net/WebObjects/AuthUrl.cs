using Newtonsoft.Json.Linq;

namespace Somtoday.Net.WebObjects;

public class AuthUrl : WebObject
{
    protected override string? UpdateUrl => null;

    public string Description { get; private set; }

    public string Url { get; private set; }

    public string DomainHint { get; private set; }

    protected override void UpdateFromJson(JToken json)
    {
        Description = (string)json["omschrijving"];
        Url = (string)json["url"];
        DomainHint = (string)json["domain_hint"];
    }
}
