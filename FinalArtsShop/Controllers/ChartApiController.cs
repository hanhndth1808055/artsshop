using FinalArtsShop.Logger;
using FinalArtsShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalArtsShop.Controllers
{
    public class ChartApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Route("api/ChartApi/Data/")]
        [HttpGet]
        public IHttpActionResult StartDataDetail(DateTime fromDate, DateTime toDate, String typeDate)
        {
            List<long[]> result = new List<long[]>();
            String startDate = fromDate.ToString("yyyy-MM-dd 00:00:00");
            //DateTime start_date = Convert.ToDateTime(startDate);
            //String startDate2 = fromDate.ToString("yyyy-MM-dd HH:mm:ss");
            String endDate = toDate.AddDays(1).ToString("yyyy-MM-dd 00:00:00");
            List<Order> listOrder = db.Orders
                            .SqlQuery("Select * from Orders where CreatedAt > '" + startDate + "' and CreatedAt <'"+endDate+ "' order by createdat;")
                            .ToList<Order>();
            DateTime dateToConvert = (DateTime)listOrder[0].CreatedAt;
            fromDate = new System.DateTime(dateToConvert.Year, dateToConvert.Month, dateToConvert.Day, 0, 0, 0);
            //fromDate = (DateTime)listOrder[0].CreatedAt;
            if (listOrder.Count > 0)
            {
                int day = 1;
                int number = 0;
                DateTime testFormat;
                for (int i= 0; i < listOrder.Count; i++)
                {
                    if(listOrder[i].CreatedAt < fromDate.AddDays(day))
                    {
                        Debug.WriteLine("fromDate.AddDays(day): "+ fromDate.AddDays(day));
                        number++;
                    }
                    else
                    {
                        long[] subItem = convertData(listOrder[i-2], number);
                        result.Add(subItem);
                        number = 0;
                        day++;
                    }
                }
                long[] lastItem = convertData(listOrder[listOrder.Count-1], number);
                result.Add(lastItem);
                try
                {

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return Exception(ex.Message);
                }
            }
            else
            {
                return Ok();
            }
        }
        private long[] convertData(Order order, int number)
        {
            long[] lastItem;
            DateTime lastDate = (DateTime)order.CreatedAt;
            DateTime testFormat = new System.DateTime(lastDate.Year, lastDate.Month, lastDate.Day, 0, 0, 0);
            TimeSpan span = (testFormat).Subtract(new DateTime(1970, 1, 1, 0, 0, 0));
            Double parseDate = span.TotalMilliseconds;
            long pareLastDate = Convert.ToInt64(parseDate);
            //lastItem = new Dictionary<int, long>();
            List<long> termsList = new List<long>();
            termsList.Add(pareLastDate);
            termsList.Add(number);
            lastItem = termsList.ToArray();
            //lastItem.Add(number, pareLastDate);
            return lastItem;
        }
        [Route("api/ChartApi/IncomeOfYear")]
        [HttpGet]
        public IHttpActionResult test()
        {
            return Ok(IncomeOfYear());
        }

        [Route("api/ChartApi/totalorder")]
        [HttpGet]
        public IHttpActionResult TotalOrder()
        {
            //List<Order> listOrder = db.Orders
            //                .SqlQuery("Select count(id) from Orders;")
            //                .ToList<Order>();
            string sql = "Select count(id) from Orders;";
            var total = db.Database.SqlQuery<int>(sql).Single();
            return Ok(total);
        }
        private IHttpActionResult Exception(string message)
        {
            throw new NotImplementedException();
        }
        private double[] IncomeOfYear()
        {
            double[] result = new double[12];
            DateTime current = DateTime.Now;
            double total = 0;
            try
            {
                for (int i = 0; i < 12; i++)
                {
                    total = 0;
                    int dayOfMoth = DateTime.DaysInMonth(current.Year, i + 1);
                    DateTime start_date = new System.DateTime(current.Year, i + 1, 01, 0, 0, 0);
                    DateTime end_date = new System.DateTime(current.Year, i + 1, dayOfMoth, 00, 00, 00);
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
            }
            catch (Exception ex)
            {
                NLogger.Error(ex);
            }
            return result;
        }
    }
}
