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

CSVFileReader csv = new CSVFileReader();
DataTable dataTable = csv.ReadFile("Transactions2014New.csv");

List<Transaction> myTransactions=new List<Transaction>();

foreach (DataRow row in dataTable.Rows)
{
    myTransactions.Add(new Transaction(row["Date"].ToString()!,row["From"].ToString()!,row["To"].ToString()!,row["Narrative"].ToString()!,Convert.ToDecimal(row["Amount"])));
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

