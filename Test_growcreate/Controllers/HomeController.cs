using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Test_growcreate.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(String address)
        { 
            string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/json?address={0}&key=AIzaSyBIeDWTn7QhIeRzokoz7VndonQANW4-Wdg", Uri.EscapeDataString(address));

            WebRequest request = WebRequest.Create(requestUri);
            WebResponse response = request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();
            JObject o = JObject.Parse(json);
            ViewBag.Lat=(string)o["results"][0]["geometry"]["location"]["lat"];
            ViewBag.Lng=(string)o["results"][0]["geometry"]["location"]["lng"];
            
            return View();
        }
    }
   
}