using AppointmentAPI.Classes;
using AppointmentAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppointmentAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class i : ControllerBase
    {

        [HttpPost]
        public IActionResult Register(Models.User userModel)
        {
            using (var context = new MenTestContext())
            {



                //context.Checks.Add(userModel.check);


                if (!context.Users.Any(x => x.Mail == userModel.Mail))
                {
                    userModel.Password = Classes.Password.Encrypt(userModel.Password);
                    context.Users.Add(userModel);
                    context.SaveChanges();


                    // string jsonString = JsonSerializer.Serialize(userModel);

                    return Ok(userModel.Id);


                }

                else
                {
                    return NotFound("Girdiğiniz mail adresi, başka bir kullanıcı tarafından kullanılmış.");
                }

                // context.Users.Add(userModel);
                // context.SaveChanges();

                // return CreatedAtAction("api/i",userModel);

            }

        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginModels loginModel)
        {
            using (var context = new MenTestContext())
            {



                Models.User homemember = context.Users.Where(x => x.Mail == loginModel.modelMail).FirstOrDefault();
                if (homemember != null)
                {
                    homemember.Password = Classes.Password.Discrypt(homemember.Password);
                }


                if (homemember != null && homemember.Password == loginModel.modelPassword)
                {
                    //return CreatedAtAction("api/i/Login",homemember);
                    return Ok(homemember.Id);
                    //register 201
                    //ok 200


                }
                else if (homemember != null && homemember.Password != loginModel.modelPassword)
                {

                    return BadRequest("Hatalı şifre girdiniz.");

                }
                else
                {

                    return BadRequest("Hatalı Mail adresi girdiniz.");
                }




            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Route("List")]
        public ActionResult<IEnumerable<Personel>> getPersonelsByCategories(int id)
        {

            using (var context = new MenTestContext())
            {


                var list = context.Personels.Where(x => x.CategoryId == id).ToList();

                return list;


            }

        }

        [HttpGet]
        [Route("Personel/{id}")]

        public ActionResult<Personel> getPersonelById(int id)
        {

            using (var context = new MenTestContext())
            {


                if (!context.Personels.Any(x => x.Id == id))
                {
                    return NotFound("Aradığınız ID'ye ait bir personel bulunamadı.");
                }

                var personel = context.Personels.Where(x => x.Id == id).FirstOrDefault();
                return personel;



            }

        }

        [HttpPost]
        [Route("Check")]
        public ResultCheckApi Check(Models.Check checkModel)
        {
            using (var context = new MenTestContext())
            {

                context.Checks.Add(checkModel);
                context.SaveChanges();
                Classes.ResultCheckApi resultRegister = new Classes.ResultCheckApi()
                {
                    appVersion = true,
                    ipAddress = true,
                    macAddress = true,
                    platformVersion = true,
                    result = ""
                };

                return resultRegister;

            }
        }

        [HttpGet]
        [Route("Categories")]
        public ActionResult<IEnumerable<Category>> getCategories()
        {
            MenTestContext context = new MenTestContext();

            var categoryList = context.Categories.ToList();

            return categoryList;
        }

        [HttpPost]
        [Route("Token")]
        public ActionResult getToken(TokenModels tokenModel)
        {
            if (tokenModel.Name == "pronist" && tokenModel.Password == "1453")
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("pronistAPITokentryingtoextendittomakeitgreaterthan128bit");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] { new Claim("Company", "Pronist") }),
                    Expires = DateTime.UtcNow.AddDays(100),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(tokenHandler.WriteToken(token));
            }

            return BadRequest();

        }

    }
}
