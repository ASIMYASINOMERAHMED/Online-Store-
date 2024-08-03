using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Statistics.Kernels;
using System;
using System.Data;
using System.Globalization;
using Microsoft.ML;
using Microsoft.ML.Data;
using System.Linq;
using System.Collections.Generic;
using Online_Store_Project;
using System.IO;

namespace OnlineStoreBusiness
{
    public static class clsSalesForcasting
    {

     
        public class SalesData
        {
            [ColumnName("Year"), LoadColumn(0)]
            public float Year { get; set; }

            [ColumnName("Month"), LoadColumn(1)]
            public float Month { get; set; }

            [ColumnName("TotalSales"), LoadColumn(2)]
            public float TotalSales { get; set; }
            [ColumnName("TotalRevenue"), LoadColumn(3)]
            public float TotalRevenue { get; set; }
        }

        public class SalesPrediction
        {
            [ColumnName("Score")]
            public float PredictedTotalSales;
         
        }
        public class RevenuePrediction
        {
            [ColumnName("Score")]
            public float PredictedTotalRevenue;
        }
        private static IEnumerable<SalesData> ConvertDataTableToSalesDataEnumerable(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                yield return new SalesData
                {
                    Year = Convert.ToSingle(row["Year"]),
                    Month = DateTime.ParseExact((row["Month"].ToString()), "MMMM", CultureInfo.InvariantCulture).Month,
                    TotalSales = Convert.ToSingle(row["TotalSales"]),
                    TotalRevenue = Convert.ToSingle(row["TotalRevenue"])
                };
            }
        }
 
        public static string PredictTotalSalesAndRevenue(DataTable dataTable,int year, int month)
        {
            var mlContext = new MLContext();

            // Load the data into a DataTable
            //dataTable = LoadData();
            var model1Path = "model1.zip";
            var model2Path = "model2.zip";
            // Check if the pretrained model exists
            if (!File.Exists(model1Path)&&!File.Exists(model2Path))
            {
                // Create the data view from the DataTable
                var dataView = mlContext.Data.LoadFromEnumerable(ConvertDataTableToSalesDataEnumerable(dataTable));

            // Define the pipeline
            var pipeline = mlContext.Transforms.Concatenate("Features", "Year", "Month")
                .Append(mlContext.Transforms.CopyColumns("Label", "TotalSales"))
                .Append(mlContext.Transforms.Conversion.ConvertType("Label", null, DataKind.Single))
                .Append(mlContext.Regression.Trainers.Sdca());

            var pipeline2 = mlContext.Transforms.Concatenate("Features", "Year", "Month")
              .Append(mlContext.Transforms.CopyColumns("Label", "TotalRevenue"))
              .Append(mlContext.Transforms.Conversion.ConvertType("Label", null, DataKind.Single))
              .Append(mlContext.Regression.Trainers.Sdca());

            // Train the model
            var model = pipeline.Fit(dataView);
            var model2 = pipeline2.Fit(dataView);
                mlContext.Model.Save(model, dataView.Schema, model1Path);
                mlContext.Model.Save(model2, dataView.Schema, model2Path);
            }
            var loadedModel1 = mlContext.Model.Load(model1Path, out var model1Schema);
            var loadedModel2 = mlContext.Model.Load(model2Path, out var model2Schema);
            // Create a single-item prediction engine
            var engine = mlContext.Model.CreatePredictionEngine<SalesData, SalesPrediction>(loadedModel1);
            var engine2 = mlContext.Model.CreatePredictionEngine<SalesData, RevenuePrediction>(loadedModel2);
            // Create a new sales data instance for prediction
            var salesData = new SalesData
            {
                Year = year,
                Month = month
            };

            // Perform the prediction
            var prediction = engine.Predict(salesData);
            var RevenuePrediction = engine2.Predict(salesData);

            // Round the predicted total sales and total revenue to the nearest integers
            var predictedTotalSales = (int)Math.Round(prediction.PredictedTotalSales);
            var predictedTotalRevenue = RevenuePrediction.PredictedTotalRevenue;

            return $"Predicted Total Sales: {predictedTotalSales}\nPredicted Total Revenue: {predictedTotalRevenue} $";
        }
        public static string TrainModel(DataTable dataTable, int year, int month)
        {
            var mlContext = new MLContext();

  
                // Create the data view from the DataTable
                var dataView = mlContext.Data.LoadFromEnumerable(ConvertDataTableToSalesDataEnumerable(dataTable));

                // Define the pipeline
                var pipeline = mlContext.Transforms.Concatenate("Features", "Year", "Month")
                    .Append(mlContext.Transforms.CopyColumns("Label", "TotalSales"))
                    .Append(mlContext.Transforms.Conversion.ConvertType("Label", null, DataKind.Single))
                    .Append(mlContext.Regression.Trainers.Sdca());

                var pipeline2 = mlContext.Transforms.Concatenate("Features", "Year", "Month")
                  .Append(mlContext.Transforms.CopyColumns("Label", "TotalRevenue"))
                  .Append(mlContext.Transforms.Conversion.ConvertType("Label", null, DataKind.Single))
                  .Append(mlContext.Regression.Trainers.Sdca());

                // Train the model
                var model = pipeline.Fit(dataView);
                var model2 = pipeline2.Fit(dataView);

            // Create a single-item prediction engine
            var engine = mlContext.Model.CreatePredictionEngine<SalesData, SalesPrediction>(model);
            var engine2 = mlContext.Model.CreatePredictionEngine<SalesData, RevenuePrediction>(model2);
            // Create a new sales data instance for prediction
            var salesData = new SalesData
            {
                Year = year,
                Month = month
            };

            // Perform the prediction
            var prediction = engine.Predict(salesData);
            var RevenuePrediction = engine2.Predict(salesData);

            // Round the predicted total sales and total revenue to the nearest integers
            var predictedTotalSales = (int)Math.Round(prediction.PredictedTotalSales);
            var predictedTotalRevenue = RevenuePrediction.PredictedTotalRevenue;

            return $"Predicted Total Sales: {predictedTotalSales}\nPredicted Total Revenue: {predictedTotalRevenue} $";
        }
     
     
      

    }
}
