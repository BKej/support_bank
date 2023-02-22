using SupportBank;
using System.Data;

CSVFileReader csv = new CSVFileReader();
DataTable dataTable = csv.ReadFile("Transactions2014.csv");


List<Transaction> myTransactions=new List<Transaction>();

foreach (DataRow row in dataTable.Rows)
{
    myTransactions.Add(new Transaction(row["Date"].ToString(),row["From"].ToString(),row["To"].ToString(),row["Narrative"].ToString(),Convert.ToDecimal(row["Amount"])));
}

PersonAccount personAcc = new PersonAccount(myTransactions);
List<string> BalanceList = personAcc.CalculateBalance();

foreach(string info in BalanceList ){
    Console.WriteLine(info.ToString());
}

Console.WriteLine("Enter the Person Name to see the transaction:");
String PersonName = Console.ReadLine();

List<string> personTransaction = personAcc.DisplayPersonTransaction(PersonName);

foreach(string info in personTransaction){
    Console.WriteLine(info.ToString());
}

