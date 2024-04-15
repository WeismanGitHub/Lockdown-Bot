using Microsoft.AspNetCore.Mvc;

namespace Server.Api;

[ApiController]
[Route("Api/[controller]")]
public abstract class CustomBase : ControllerBase { }
