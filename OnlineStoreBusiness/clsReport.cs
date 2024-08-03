using OnlineStoreDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Project
{
    public class clsReport
    {
        public string dateTime { get; set; }
        public int Year { set; get; }
        public int TotalSales { set; get; } = 0;
        public decimal TotalRevenue { set; get; } = 0;
        public string PredictedTotalSalesAndRevenue { set; get; }

        public clsReport()
        {
            dateTime = DateTime.Now.ToShortDateString();
            Year = DateTime.Now.Year;
            TotalSales = clsReportData.GetCurrentYearTotalSales();
            TotalRevenue = clsReportData.GetCurrentYearTotalRevenue();
        }
        public static DataTable GetAllSalesData()
        {
            return clsReportData.GetAllSalesData();
        }

        public static int GetCurrentYearTotalSales()
        {
            return clsReportData.GetCurrentYearTotalSales();
        }
        public static decimal GetCurrentYearTotalRevenue()
        {
            return clsReportData.GetCurrentYearTotalRevenue();
        }
     
    }
}
