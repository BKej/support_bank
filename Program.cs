using SupportBank;
using System.Data;
using NLog;
using NLog.Config;
using NLog.Targets;

var config = new LoggingConfiguration();
var target = new FileTarget { FileName = @"C:\Work\Logs\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
config.AddTarget("File Logger", target);
config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
LogManager.Configuration = config;

// ask user input if file path is not found;
string fileName = "";
CSVFileReader csv;
DataTable dataTable;
JSONFileReader json;
List<Transaction> myTransactions=new List<Transaction>();

while(!File.Exists(fileName)){
        
        Console.WriteLine("Enter the FileName to read:");
        fileName=  Console.ReadLine();

        if(!File.Exists(fileName)){
        Console.WriteLine("Incorrect filename, please enter correct filename:");}
    }


if(Path.GetExtension(fileName)==".csv"){
        csv = new CSVFileReader();
        dataTable= csv.ReadFile(fileName);
        foreach (DataRow row in dataTable.Rows)
        {
            myTransactions.Add(new Transaction(row["Date"].ToString()!,row["From"].ToString()!,row["To"].ToString()!,row["Narrative"].ToString()!,Convert.ToDecimal(row["Amount"])));
        }
}else if (Path.GetExtension(fileName)==".json"){
    
       json = new JSONFileReader(); 
       myTransactions=json.JSONReadFile(fileName);
}

Accounting accounts = new Accounting(myTransactions);
List<string> BalanceList = accounts.CalculateBalance();

foreach(string info in BalanceList )
{
    Console.WriteLine(info);
}

Console.WriteLine("Enter the Person Name to see the transaction:");

string personName = Console.ReadLine();

List<string> personTransaction = accounts.DisplayPersonTransaction(personName);

foreach(string info in personTransaction){
    Console.WriteLine(info.ToString());
}

