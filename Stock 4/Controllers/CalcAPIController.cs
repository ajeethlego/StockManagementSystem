using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stock_4.Models;
using System.Text;

namespace Stock_4.Controllers
{

    public class CalcAPIController : Controller
    {
        Uri ApiHolidayAddress = new Uri("https://localhost:7291/api");
        HttpClient client;

        public CalcAPIController()
        {
            client = new HttpClient();
            client.BaseAddress = ApiHolidayAddress;
        }
        public IActionResult ApiCalcIndex()
        {
            List<CalcAPI> api_CalcLocals = new List<CalcAPI>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/calc").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                api_CalcLocals = JsonConvert.DeserializeObject<List<CalcAPI>>(data);
            }
            return View(api_CalcLocals);
        }

        public IActionResult ApiCalcCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ApiCalcCreate(CalcAPI item)
        {
            string data = JsonConvert.SerializeObject(item);
            StringContent Content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/calc", Content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ApiCalcIndex");
            }
            return View();
        }

        public ActionResult ApiCalcDelete(int id)
        {
            //API_HolidayLocal Deleteitem = new API_HolidayLocal();
            //HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/holidays" + id).Result;

            //if (response.IsSuccessStatusCode)

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7291/api");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync(client.BaseAddress + "/calc/" + id.ToString());
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
