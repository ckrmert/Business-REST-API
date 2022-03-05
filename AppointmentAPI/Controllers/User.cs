using AppointmentAPI.Classes;
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

    [Route("api/v1/[controller]")]
    [ApiController]
    public class User : Controller
    {

        MenTestContext context = new MenTestContext();

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(Models.User userModel)
        {
            using (var context = new MenTestContext())
            {

                //context.Checks.Add(userModel.check);


                if (!context.Users.Any(x => x.Mail == userModel.Mail))
                {
                    //userModel.Password = Classes.Password.Encrypt(userModel.Password);
                    context.Users.Add(userModel);
                    context.SaveChanges();


                    // string jsonString = JsonSerializer.Serialize(userModel);

                    return Ok(userModel);


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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginModels loginModel)
        {
            using (var context = new MenTestContext())
            {



                Models.User homemember = context.Users.Where(x => x.Mail == loginModel.modelMail).FirstOrDefault();
                /*
                if (homemember != null)
                {
                    homemember.Password = Classes.Password.Discrypt(homemember.Password);
                }
                */


                if (homemember != null && homemember.Password == loginModel.modelPassword)
                {
                    //return CreatedAtAction("api/i/Login",homemember);
                    return Ok(homemember);
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
        [Route("EditProfile")]
        public ActionResult EditProfile(int id)
        {
            var model = context.Users.Where(x => x.Id == id).FirstOrDefault();
            model.Password = null;

            if (model != null)
            {
                return Ok(model);
            }

            else
            {
                return BadRequest("Kullanıcı bulunamadı.");
            }

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("EditProfile")]
        public ActionResult EditProfile(EditProfileModels model)
        {
            var willbeupdated = context.Users.Where(x => x.Id == model.Id).FirstOrDefault();
            //willbeupdated.Mail = model.Mail;
            willbeupdated.Name = model.Name;
            willbeupdated.Surname = model.Surname;
            willbeupdated.Phone = model.Phone;
            // willbeupdated.Password = model.Password;
            context.SaveChanges();

            return Ok(willbeupdated);

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("EditPassword")]
        public ActionResult EditPassword(Classes.EditPasswordModels model)
        {
            var willbeupdated = context.Users.Where(x=>x.Id==model.userId).FirstOrDefault();

            willbeupdated.Password = model.newPassword; // kripto'dan sıkıntı çıkabilir.
            context.SaveChanges();

            return Ok("Şifreniz güncellendi.");

        }


    }
}
