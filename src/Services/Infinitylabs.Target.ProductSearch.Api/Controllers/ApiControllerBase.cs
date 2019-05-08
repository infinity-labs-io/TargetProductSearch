using Microsoft.AspNetCore.Mvc;

namespace InfinityLabs.Target.ProductSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase {}
}