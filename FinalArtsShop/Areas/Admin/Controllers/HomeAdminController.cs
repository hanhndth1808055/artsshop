using FinalArtsShop.Logger;
using FinalArtsShop.Models;
using FinalArtsShop.ModelsDAO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace FinalArtsShop.Areas.Admin.Controllers
{
    [System.Web.Http.Authorize]
    public class HomeAdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public async Task<ActionResult> Index()
        {
            string sql = "Select count(id) from Orders;";
            string sqlOrderSucess = " Select count(id) from Orders where FulfillmentStatus = 2;";
            var total = db.Database.SqlQuery<int>(sql).Single();
            var totalOrserSucess = db.Database.SqlQuery<int>(sqlOrderSucess).Single();
            string api = ApiConfig.api;
            //string apiVps = ApiConfig.apiVps;
            information infor = await testAsync();
            string str = infor.use.Remove(infor.use.Length - 1);
            string inforTotal = infor.total.Remove(infor.total.Length - 1);
            ViewBag.api = api;
            //ViewBag.apiVps = apiVps;
            ViewBag.total = total;
            ViewBag.Revenueofmonth = Revenueofmonth(DateTime.Now);
            ViewBag.totalOrserSucess = totalOrserSucess;
            ViewBag.mothPrevious = mothPrevious();
            ViewBag.totalUser = totalUser();
            ViewBag.information_use = str;
            ViewBag.information_total = inforTotal;
            ViewBag.Returned = Returned(DateTime.Now);
            //double[] IncomeOfYear_ = IncomeOfYear();
            //ViewBag.IncomeOfYear = IncomeOfYear_;
            return View("~/Areas/Admin/Views/Dashboard/Dashboard.cshtml");
        }
        private double Returned(DateTime currentDate)
        {
            double result = 0;
            //DateTime currentDate = DateTime.Now;
            int dayOfMoth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            if (dayOfMoth == 1)
            {
                return 0;
            }
            DateTime start_date = new System.DateTime(currentDate.Year, currentDate.Month, 01, 0, 0, 0);
            DateTime end_date = new System.DateTime(currentDate.Year, currentDate.Month, dayOfMoth, 00, 00, 00);
            String startDate = start_date.ToString("yyyy-MM-dd 00:00:00");
            String endDate = end_date.ToString("yyyy-MM-dd 23:59:59");

            List<Order> listOrder = db.Orders
                            .SqlQuery("Select * from Orders where CreatedAt > '" + startDate + "' and CreatedAt <'" + endDate + "' and fulfillmentstatus = 5 order by createdat;")
                            .ToList<Order>();

            foreach (Order item in listOrder)
            {
                result += item.TotalPrice;
            }
            return result;
        }
        private double Revenueofmonth(DateTime currentDate)
        {
            double result = 0;
            //DateTime currentDate = DateTime.Now;
            int dayOfMoth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            if (dayOfMoth == 1)
            {
                return 0;
            }
            DateTime start_date = new System.DateTime(currentDate.Year, currentDate.Month, 01, 0, 0, 0);
            DateTime end_date = new System.DateTime(currentDate.Year, currentDate.Month, dayOfMoth, 00, 00, 00);
            String startDate = start_date.ToString("yyyy-MM-dd 00:00:00");
            String endDate = end_date.ToString("yyyy-MM-dd 23:59:59");

            List<Order> listOrder = db.Orders
                            .SqlQuery("Select * from Orders where CreatedAt > '" + startDate + "' and CreatedAt <'" + endDate + "' order by createdat;")
                            .ToList<Order>();

            foreach(Order item in listOrder)
            {
                result += item.TotalPrice;
            }
            return result;
        }
        private double mothPrevious()
        {
            double result = 0;
            double currentMonth = Revenueofmonth(DateTime.Now);
            double previousMonth = Revenueofmonth(DateTime.Now.AddMonths(-1));
            if (previousMonth == 0)
            {
                return 100;
            }
            result = (previousMonth / currentMonth) * 100;
            return result;
        }
        private int totalUser()
        {
            string sql = "Select count(id) from aspnetusers;";
            var totalOrserSucess = db.Database.SqlQuery<int>(sql).Single();
            return totalOrserSucess;
        }
        private double[] IncomeOfYear()
        {
            double[] result=new double[12];
            DateTime current = DateTime.Now;
            double total=0;
            try
            {
                for (int i = 0; i < 12; i++)
                {
                    total = 0;
                    int dayOfMoth = DateTime.DaysInMonth(current.Year, i + 1);
                    DateTime start_date = new System.DateTime(current.Year, i+1, 01, 0, 0, 0);
                    DateTime end_date = new System.DateTime(current.Year, i+1, dayOfMoth, 00, 00, 00);
                    String startDate = start_date.ToString("yyyy-MM-dd 00:00:00");
                    String endDate = end_date.ToString("yyyy-MM-dd 23:59:59");
                    List<Order> listOrder = db.Orders
                                    .SqlQuery("Select * from Orders where CreatedAt > '" + startDate + "' and CreatedAt <'" + endDate + "' order by createdat;")
                                    .ToList<Order>();
                    if (listOrder.Count == 0)
                    {
                        result[i] = 0;
                    }
                    else
                    {
                        foreach (Order item in listOrder)
                        {

                            total += item.TotalPrice;
                        }
                        result[i] = total;
                    }
                }
                Debug.WriteLine(result);
                return result;
            }catch(Exception ex)
            {
                NLogger.Error(ex);
            }
            return result;
        }
        private async Task<information> testAsync()
        {
            information infor = new information();
            var client = new HttpClient();

            var result = await client.GetAsync("http://171.244.141.61:8111/dataservice/getsysteminformation/");
            //Console.WriteLine(result.StatusCode);
            var dataRespon = await result.Content.ReadAsStringAsync();
            infor = JsonConvert.DeserializeObject<information>(dataRespon);
            return infor;
        }
    }
}
