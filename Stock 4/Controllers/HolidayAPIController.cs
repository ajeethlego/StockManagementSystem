using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stock_4.Models;
using System.Text;

namespace Stock_4.Controllers
{
    
    public class HolidayAPIController : Controller
    {
        Uri ApiHolidayAddress = new Uri("https://localhost:44341/api");
        HttpClient client;

        public HolidayAPIController()
        {
            client = new HttpClient();
            client.BaseAddress = ApiHolidayAddress;
        }
        public IActionResult ApiHolidayIndex()
        {
            List<API_HolidayLocal> api_HolidayLocals = new List<API_HolidayLocal>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/holidays").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                api_HolidayLocals = JsonConvert.DeserializeObject<List<API_HolidayLocal>>(data);
            }
            return View(api_HolidayLocals);
        }

        public IActionResult ApiHolidayCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ApiHolidayCreate(API_HolidayLocal item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent Content=new StringContent(data,Encoding.UTF8,"application/json");

            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/holidays",Content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ApiHolidayIndex");
            }
            return View();
        }

        public IActionResult ApiHolidayEdit(int id)
        {
            API_HolidayLocal Edititem = new API_HolidayLocal();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/holidays"+id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                Edititem = JsonConvert.DeserializeObject<API_HolidayLocal>(data);
            }
            return View("ApiHolidayCreate",Edititem);
        }

        [HttpPost]
        public IActionResult ApiHolidayEdit(API_HolidayLocal Edititem)
        {
            string data = JsonConvert.SerializeObject(Edititem);
            StringContent Content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/holidays"+Edititem.Id, Content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ApiHolidayIndex");
            }
            return View("ApiHolidayCreate",Edititem);
        }

        public ActionResult ApiHolidayDelete(int id)
        {
            //API_HolidayLocal Deleteitem = new API_HolidayLocal();
            //HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/holidays" + id).Result;

            //if (response.IsSuccessStatusCode)

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44341/api");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync(client.BaseAddress + "/holidays/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ApiHolidayIndex");
                }
            }

            return RedirectToAction("ApiHolidayIndex");
        }


    }
}
