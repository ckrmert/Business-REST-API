using AppointmentAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Banner : Controller
    {
         MenTestContext context = new MenTestContext();

        [HttpGet]
        [Route("List")]
        public ActionResult<IEnumerable<Banner>> getBanners()
        {

            var model = context.Banners.OrderBy(x => x.Sorting).ToList();

            if (model.Count == 0)
            {
                return BadRequest("Herhangi bir veriye ulaşılamadı.");
            }

            else
            {
                return Ok(model);
            }

        }



    }
}
