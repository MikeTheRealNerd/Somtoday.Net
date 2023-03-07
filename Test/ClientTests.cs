namespace Test;

[TestClass]
public class ClientTests
{
    public static SomtodayClient Client = new();

    [TestMethod]
    public async Task GetOrganizations()
    {
        var orgs = await Client.GetOrganizationsAsync();
        if (orgs.Length == 0)
            Assert.Fail();


    }
}