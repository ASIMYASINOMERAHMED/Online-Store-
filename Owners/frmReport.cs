using OnlineStoreBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Online_Store_Project
{
    public partial class frmReport : Form
    {
        private DataTable _dtSalesData;
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            _dtSalesData = clsReport.GetAllSalesData();
            // TODO: This line of code loads data into the 'online_StoreDataSet1.SP_GetSalesReportData' table. You can move, or remove it, as needed.
            this.sP_GetSalesReportDataTableAdapter.Fill(this.online_StoreDataSet1.SP_GetSalesReportData);
            clsReport report = new clsReport();
            string PredictedTotalSalesAndRevenue =  clsSalesForcasting.PredictTotalSalesAndRevenue(clsReport.GetAllSalesData(),DateTime.Now.AddYears(1).Year,DateTime.Now.Month);
  
            report.PredictedTotalSalesAndRevenue = PredictedTotalSalesAndRevenue;
           List<clsReport> lst = new List<clsReport>();

            lst.Add(report);
            Microsoft.Reporting.WinForms.ReportDataSource dataset = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", lst);

            reportViewer1.LocalReport.DataSources.Add(dataset);
            dataset.Value = lst;

            this.reportViewer1.RefreshReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
