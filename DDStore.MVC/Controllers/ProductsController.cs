using DDStore.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace DDStore.MVC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {

            IEnumerable<mvcProductModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<mvcProductModel>>().Result;

            return View(empList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcProductModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcProductModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcProductModel emp)
        {
            if (emp.ProductID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Products", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Products/" + emp.ProductID, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";

            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync($"Products/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";

            return RedirectToAction("Index");
        }
       


    }
}