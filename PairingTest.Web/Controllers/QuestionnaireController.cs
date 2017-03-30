using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using PairingTest.Web.Models;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
          /* ASYNC ACTION METHOD... IF REQUIRED... */
        public async Task<ViewResult> Index()
        {
            List<QuestionnaireViewModel> question = new List<QuestionnaireViewModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50014/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //GET Method  
                HttpResponseMessage response = await client.GetAsync("api/Questions");
                if (response.IsSuccessStatusCode)
                {
                    question = await response.Content.ReadAsAsync<List<QuestionnaireViewModel>>();
                }
                else
                {
                    //Console.WriteLine("Internal server Error");
                }
            }
            return View(question);
        }

        //public ViewResult Index()
        //{
        //    return View(new QuestionnaireViewModel());
        //}
    }
}
