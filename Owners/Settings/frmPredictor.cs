using OnlineStoreBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Store_Project
{
    public partial class frmPredictor : Form
    {
        private DataTable _dt;
        public frmPredictor()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPredict_Click(object sender, EventArgs e)
        {
            try
            {
                lbPredictions.Visible = false;
                lbPredictions.Text = $"Year {txtYear.Text}\nMonth {txtMonth.Text}\n" + clsSalesForcasting.PredictTotalSalesAndRevenue(_dt, Convert.ToInt32(txtYear.Text), Convert.ToInt32(txtMonth.Text)).ToString();
                lbPredictions.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error Occurred {ex.Message}");
            }
        }

        private void frmPredictor_Load(object sender, EventArgs e)
        {
            _dt=clsReport.GetAllSalesData();
        }

        private async void btnTrain_Click(object sender, EventArgs e)
        {
            try
            {
                string Predictions = "";
                ProgressIndicator1.Start();
                ProgressIndicator1.Visible = true;
                await Task.Run(() => Predictions = clsSalesForcasting.TrainModel(_dt, Convert.ToInt32(txtYear.Text), Convert.ToInt32(txtMonth.Text)).ToString());
                ProgressIndicator1.Stop();
                ProgressIndicator1.Visible = false;
                lbPredictions.Invoke(new Action(() => lbPredictions.Text = $"Year {txtYear.Text}\nMonth {txtMonth.Text}\n" + Predictions));
                lbPredictions.Invoke(new Action(() => lbPredictions.Visible = true));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error Occurred {ex.Message}");
            }
        }

    }
}
