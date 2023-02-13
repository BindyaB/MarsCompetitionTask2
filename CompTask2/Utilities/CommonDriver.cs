using CompTask2.Pages;
using ExcelDataReader;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompTask2.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;
        
    }

    public class ExcelLib
    {
        public static DataTable ExcelToDataTable(string filename, string sheetname)
        {
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                var result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }

                });
            stream.Close();
            DataTableCollection table = result.Tables;
            DataTable resultTable = table[sheetname];
            return resultTable;


        }


        static List<DataCollection> dataCol = new List<DataCollection>();

        public static void PopulateInCollection(string filename, string sheetname)
        {
            dataCol.Clear();
            DataTable table = ExcelToDataTable(filename, sheetname);
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    DataCollection dfTable = new DataCollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    dataCol.Add(dfTable);
                }
            }
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();
                return data.ToString();


            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

    public class DataCollection
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
    }

}
