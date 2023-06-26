using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Diagnostics;
using PaymentCrudapp2.Models;

namespace PaymentCrudapp2.Controllers
{
    public class PaymentController : Controller
    {
        private static readonly HttpClient client;

        static PaymentController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44372/api/PaymentsData/");
        }

        // GET: Payment/List
        public ActionResult List()
        {
            //Objective: communicste with our Payment Data api to retrieve a list of payments
            //curl https://localhost:44372/api/PaymentsData/ListPayments
            
            string url = "ListPayments";
            HttpResponseMessage response = client.GetAsync(url).Result; 

            Debug.WriteLine("The response code is");
            Debug.WriteLine(response.StatusCode);
            
            IEnumerable<PaymentDto> payments = response.Content.ReadAsAsync<IEnumerable<PaymentDto>>().Result;
            Debug.WriteLine("Number Of Payments Recieved: ");
            Debug.WriteLine(payments.Count());

            return View(payments);
        }

        // GET: Payment/Details/5
        public ActionResult Details(int id)
        {
            //Objective: communicste with our Payment Data api to retrieve one payment
            //curl https://localhost:44372/api/PaymentsData/FindPayment/{id}
            
            string url = "FindPayment/"+id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("The response code is");
            Debug.WriteLine(response.StatusCode);

            PaymentDto selectedpayments = response.Content.ReadAsAsync<PaymentDto>().Result;
            Debug.WriteLine("Payment Recieved: ");
            Debug.WriteLine(selectedpayments.Name);

            return View(selectedpayments);
        }

        // GET: Payment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Payment/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Payment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Payment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Payment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Payment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
