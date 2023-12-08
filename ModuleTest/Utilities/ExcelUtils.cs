using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TataCliq.Utilities
{
    internal class ExcelUtils
    {
        public static List<SearchData> ReadExcelData(string excelFilePath, string? sheetName)
        {
            List<SearchData> excelDataList = new List<SearchData>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    var dataTable = result.Tables[sheetName];
                    if (dataTable != null)
                    {

                        foreach (DataRow row in dataTable.Rows)
                        {
                            SearchData excelData = new SearchData
                            {
                                UserName = GetValueOrDefault(row, "userName"),
                                Pwd = GetValueOrDefault(row,"password"),
                                Name = GetValueOrDefault(row, "name"),
                                LastName = GetValueOrDefault(row, "lastName"),
                                Email = GetValueOrDefault(row, "email"),
                                Content = GetValueOrDefault(row, "content")
                            };
                            excelDataList.Add(excelData);
                        }
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                }
            }
            return excelDataList;
        }
        static string GetValueOrDefault(DataRow row, string columnName)
        {
            Console.WriteLine(row + "  " + columnName);
            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;
        }
    }
}
