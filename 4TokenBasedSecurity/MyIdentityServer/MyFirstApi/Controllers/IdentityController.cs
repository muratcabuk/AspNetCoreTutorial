using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MyFirstApi.Controllers
{

    [Authorize]
    [Produces("application/json")]
    [Route("identity")]
    public class IdentityController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult
                 (

                //bağlanan kişinin bilgilerini geri döndürüyor.
                //tabii ki api nin yapacağı işe göre başka bilgiler dönmesi gerekiyor.
                //buraya gelirken identityserver dan clientid ve clietsecret ını almış olması gerekiyor buraya gelirken.
                //ağer bilgiler boş geliyorsa developer login ekranına yönlendirilebilir.
                //eğer ilgili bilgiler geliyor ancak yetkili değilse yöeticinizle görüşünüz gibi bir bilgi döndürülebilir.
                from c in User.Claims select new { c.Type, c.Value }
                );


        }



    }
}