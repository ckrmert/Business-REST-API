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
    public class Categories : Controller
    {
        MenTestContext context = new MenTestContext();

        [HttpGet]
        [Route("List")]
        public ActionResult<IEnumerable<Models.Category>> getCategories()
        {

            var categoryList = context.Categories.ToList();



            return Ok(categoryList);
        }

    }
}
