using SupportBank;
using System.Data;
using NLog;
class CSVFileReader{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
   
    DataTable dataTable = new DataTable();
        
    public DataTable ReadFile(string FileName){

        Logger.Info("Inside ReadFile method:- FileName: "+ FileName);
       
        try{
         System.IO.StreamReader reader = new System.IO.StreamReader(FileName);
         
         // Read the first line to create columns in the DataTable
            string[] headers = reader.ReadLine().Split(',');
            
            Logger.Info("Reading File Header");
               
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

            if(dataTable.Rows.Count == 0){
                Logger.Debug("No Data Found...");
            }
                    try{
                        foreach (DataRow row in dataTable.Rows)
                        {
                            DateTime.Parse(row["Date"].ToString()!);
                        }
                    }catch(System.FormatException e){
                        Logger.Debug("Date is not valid");
                        Console.WriteLine("Date invalid, please update the date in proper format in the file!!");
                        throw e;
                    }

                    try{
                        foreach (DataRow row in dataTable.Rows)
                        {
                            Decimal.Parse(row["Amount"].ToString()!);
                        }
                    }catch(System.FormatException e){
                        Logger.Debug("Amount is not valid");
                        Console.WriteLine("Amount should be a number, please update the file with correct amount.");
                        throw e;
                    }
        }
        catch (FileNotFoundException e){
            Console.WriteLine("File Not found, please give correct path");

        }
        return dataTable;

    }
}

    