using DataCreationMicroservice.Context;
using Microsoft.EntityFrameworkCore;
using StockMarketCharting.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
//using Microsoft.Office.Interop.Excel;
//using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;

namespace UploadMicroservice.Repositories
{
    public class UploadRepository : IRepository
    {
        private StockMarketContext context;

        public UploadRepository(StockMarketContext dbContext)
        {
            this.context = dbContext;
        }
        public Tuple<int,string,string> UploadExcel(string filePath)
        {
            var list = new List<StockPrice>();
            FileInfo info = new FileInfo(filePath);
            string fileExtension = info.Extension;
            string excelConString = "";
            //Get connection string using extension
            switch (fileExtension)
            {
                // If uploaded file is Excel 1997 - 2007.
                case ".xls":
                    excelConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";
                    break;
                //If uploaded file is Excel 2007 and above
                case ".xlsx":
                    excelConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";
                    break;
            }
            // Read data from first sheet of excel into datatable
            DataTable dt = new DataTable();
            excelConString = string.Format(excelConString, filePath);

            Tuple<int, string, string> summary;

            using (OleDbConnection excelOledbConnection = new OleDbConnection(excelConString))
            {
                using (OleDbCommand excelDbCommand = new OleDbCommand())
                {
                    using (OleDbDataAdapter excelDataAdapter = new OleDbDataAdapter())
                    {
                        excelDbCommand.Connection = excelOledbConnection;

                        excelOledbConnection.Open();
                        // Get schema from excel sheet
                        DataTable excelSchema = excelOledbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);                        // Get sheet name
                        string sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();
                        excelOledbConnection.Close();

                        // Read Data from First Sheet.
                        excelOledbConnection.Open();
                        excelDbCommand.CommandText = "SELECT * From [" + sheetName + "]";
                        excelDataAdapter.SelectCommand = excelDbCommand;
                        //Fill datatable from adapter
                        excelDataAdapter.Fill(dt);
                        excelOledbConnection.Close();

                        int count = dt.Rows.Count;
                        string cName;
                        string sName;

                        foreach (DataRow r in dt.Rows)
                        {
                            // int i = Int32.Parse(r[1].ToString().Trim());
                            //You can try single() method instead of where.
                            //StockExchangeId = context.StockExchanges.Where(s=> s.StockExchangeName == r[1].ToString().Trim())
                            //list.Add(
                            //    new StockPrice()
                            //    {
                            //        CompanyId = int.Parse(r[0].ToString().Trim()),
                            //        StockExchangeId = int.Parse(r[1].ToString().Trim()),
                            //        CurrentPrice = Convert.ToDouble(r[2].ToString().Trim()),
                            //        Date = r[3].ToString().Trim(),
                            //        Time = r[4].ToString().Trim()
                            //    }) ;
                            DateTime t = (DateTime)r[3];
                            var sp=new StockPrice()
                             {
                                 CompanyId = int.Parse(r[0].ToString().Trim()),
                                 StockExchangeId = int.Parse(r[1].ToString().Trim()),
                                 CurrentPrice = Convert.ToDouble(r[2].ToString().Trim()),
                                 Date = t.ToString("d").Trim(),

                                //Date = r[3].ToString().Trim(),
                                Time = r[4].ToString().Trim()
                             };
                            context.Add(sp);
                            var x= context.SaveChanges();
                            Console.WriteLine(x);
                        }
                        cName = context.Companies.Find(list.First().CompanyId).CompanyName;
                        sName = context.StockExchanges.Find(list.First().StockExchangeId).StockExchangeName;
                        summary = new Tuple<int, string, string>(count, cName, sName);

                        context.StockPrices.AddRange(list);  //insert list of rows to table
                        var x = context.SaveChanges();
                        Console.WriteLine(x);
                        return summary;
                    }
                }

            }
        }
    }
}
