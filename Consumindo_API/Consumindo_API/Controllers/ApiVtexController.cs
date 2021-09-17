using Consumindo_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Consumindo_API.Controllers
{
    public class ApiVtexController : Controller
    {
        private readonly IConfiguration _configuration;

        public ApiVtexController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: ApiVtexController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SkuGet(string key,string token)
        {
            var endPoint = _configuration.GetSection("API_Vtex").Value;

            var uri = string.Format(endPoint, 1, 10);

            var skus = GetSku(uri, key, token);
            

            return StatusCode(200,skus);
        }

        private IList<Sku> GetSku(string uri,string key, string token)
        {
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                client.Headers.Add("X-VTEX-API-AppKey", key);
                client.Headers.Add("X-VTEX-API-AppToken", token);

                var response = client.DownloadString(uri);

                var skus = JsonConvert.DeserializeObject<IList<Sku>>(response);

                return skus;
            }
        }

        // GET: ApiVtexController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApiVtexController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApiVtexController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApiVtexController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApiVtexController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApiVtexController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApiVtexController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
