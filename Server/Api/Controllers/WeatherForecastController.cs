using Microsoft.AspNetCore.Mvc;

namespace Server.Api.Controllers;

public class AnalyticsController : CustomBase
{
    [HttpGet(Name = "test")]
    public string Test()
    {
        return "hello world";
    }
}
