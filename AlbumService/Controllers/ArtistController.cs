using Microsoft.AspNetCore.Mvc;

namespace AlbumService.Controllers
{
    [Route("api/a/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        public ArtistController()
        {

        }

        [HttpPost]
        public ActionResult TestInboundCOnnection()
        {
            Console.WriteLine("--> Inbound POST # Album Service");
            return Ok("Inbound test of from Artist controller");
        }
    }
}