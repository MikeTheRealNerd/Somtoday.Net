using Newtonsoft.Json.Linq;

namespace Somtoday.Net.Entities;

public class Organization : Entity
{
    protected override string? UpdateUrl => null;

    public string Uuid { get; private set; }

    public string Name { get; private set; }

    public string Place { get; private set; }

    public AuthUrl[] AuthUrls { get; private set; }

    protected override void UpdateFromJson(JToken json)
    {
        Uuid = (string)json["uuid"];
        Name = (string)json["naam"];
        Place = (string)json["plaats"];

        AuthUrls = json["oidcurls"].GetEntities<AuthUrl>(Client);
    }
}
