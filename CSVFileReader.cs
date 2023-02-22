using System;
using System.IO;
using System.Data;
using System.Linq;
using static System.IO.StreamReader;

class CSVFileReader{

    DataTable dataTable = new DataTable();

    public DataTable ReadFile(string FileName){

         System.IO.StreamReader reader = new System.IO.StreamReader(FileName);
        
         // Read the first line to create columns in the DataTable
            string[] headers = reader.ReadLine().Split(',');
            foreach (string header in headers)
            {
                dataTable.Columns.Add(header);
            }

            // Read the rest of the lines to fill the DataTable
            while (!reader.EndOfStream)
            {
                string[] rows = reader.ReadLine().Split(',');
                DataRow dataRow = dataTable.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dataRow[i] = rows[i];
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;

    }
}

    