using AppointmentAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AppointmentAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Employee : Controller
    {

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


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Route("Single")]
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Route("Sorting")]
        public ActionResult<IEnumerable<Personel>> getPersonelBySorting()
        {

            using (var context = new MenTestContext())
            {
                var personelList = context.Personels.Where(x => x.Sorting != null).OrderBy(x => x.Sorting).ToList();


                List<Classes.PersonelModels> model = new List<Classes.PersonelModels>();

                for (int i = 0; i < personelList.Count; i++)
                {
                    Classes.PersonelModels pers = new Classes.PersonelModels();
                    pers.AppoinmentCount = personelList[i].AppoinmentCount;
                    pers.Bio = personelList[i].Bio;
                    pers.CategoryId = personelList[i].CategoryId;
                    pers.CategoryName = context.Categories.FirstOrDefault(x=>x.Id== personelList[i].CategoryId).Name;
                    pers.Id = personelList[i].Id;
                    pers.Image = personelList[i].Image;
                    pers.Name = personelList[i].Name;
                    pers.OnlineStatus = personelList[i].OnlineStatus;
                    pers.Sorting = personelList[i].Sorting;
                    pers.Star = personelList[i].Star;
                    pers.Surname = personelList[i].Surname;
                    pers.Title = personelList[i].Title;
                    model.Add(pers);
                }

                return Ok(model);

            }

        }





    }
}
