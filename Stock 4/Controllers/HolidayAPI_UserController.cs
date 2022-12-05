using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stock_4.Models;
using System.Text;

namespace Stock_4.Controllers
{
    public class HolidayAPI_UserController : Controller
    {
        Uri ApiHolidayAddress = new Uri("https://localhost:44341/api");
        HttpClient client;

        public HolidayAPI_UserController()
        {
            client = new HttpClient();
            client.BaseAddress = ApiHolidayAddress;
        }
        public IActionResult ApiHolidayUserIndex()
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
    }
}
