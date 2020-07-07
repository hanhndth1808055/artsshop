using FinalArtsShop.Logger;
using FinalArtsShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace FinalArtsShop.Controllers
{
    public class PaypalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult PaymentSuccess()
        {
            return View("~/Views/Checkout/PaypalSuccess.cshtml");
        }
        public ActionResult PaymentError()
        {
            return View("~/Views/Checkout/PaypalError.cshtml");
        }
        [HttpPost]
        public HttpStatusCodeResult Receive()
        {
            //Store the IPN received from PayPal
            LogRequest(Request);

            //Fire and forget verification task
            Task.Run(() => VerifyTask(Request));

            //Reply back a 200 code
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        private void VerifyTask(HttpRequestBase ipnRequest)
        {
            var verificationResponse = string.Empty;
            string informationRequets = "";
            try
            {
                var verificationRequest = (HttpWebRequest)WebRequest.Create("https://www.sandbox.paypal.com/cgi-bin/webscr");

                //Set values for the verification request
                verificationRequest.Method = "POST";
                verificationRequest.ContentType = "application/x-www-form-urlencoded";
                var param = Request.BinaryRead(ipnRequest.ContentLength);
                var strRequest = Encoding.ASCII.GetString(param);
                
                //Add cmd=_notify-validate to the payload
                strRequest = "cmd=_notify-validate&" + strRequest;
                NLogger.Infor("strRequest: " + strRequest);
                informationRequets = strRequest;
                verificationRequest.ContentLength = strRequest.Length;

                //Attach payload to the verification request
                var streamOut = new StreamWriter(verificationRequest.GetRequestStream(), Encoding.ASCII);
                streamOut.Write(strRequest);
                streamOut.Close();

                //Send the request to PayPal and get the response
                var streamIn = new StreamReader(verificationRequest.GetResponse().GetResponseStream());
                verificationResponse = streamIn.ReadToEnd();
                streamIn.Close();

            }
            catch (Exception exception)
            {
                //Capture exception for manual investigation
            }

            ProcessVerificationResponse(informationRequets, verificationResponse);
        }


        private void LogRequest(HttpRequestBase request)
        {
            // Persist the request values into a database or temporary data store
        }

        private void ProcessVerificationResponse(string requestInformation, string verificationResponse)
        {
            if (verificationResponse.Equals("VERIFIED"))
            {
                string orderId = getOrderId(requestInformation);
                NLogger.Infor("orderId = "+ orderId);
                NLogger.Infor("update FulfillmentStatusEnum with orderId: " + orderId);
                Order order = db.Orders.First(a => a.Id.Equals(orderId));
                order.PaymentStatus = PaymentStatusEnum.Paid;
                db.SaveChanges();
                NLogger.Infor("update success");
                Session["ShoppingCartName"] = new ShoppingCart();
                // check that Payment_status=Completed
                // check that Txn_id has not been previously processed
                // check that Receiver_email is your Primary PayPal email
                // check that Payment_amount/Payment_currency are correct
                // process payment 
            }
            else if (verificationResponse.Equals("INVALID"))
            {
                string orderId = getOrderId(requestInformation);
                NLogger.Infor("orderId = " + orderId);
                //Log for manual investigation
                NLogger.Infor("ERROR Payment "+orderId);
            }
            else
            {
                //Log error
            }
        }
        private string getOrderId(string request)
        {
            string orderId="";
            if (request.Equals(""))
            {
                return null;
            }
            else
            {
                string[] arrListStr = request.Split(new string[] { "&item_number=" }, StringSplitOptions.None);
                if (arrListStr.Length > 1)
                {
                    orderId = (arrListStr[1].Split('&'))[0];
                }
            }
            return orderId;
        }
    }
}
