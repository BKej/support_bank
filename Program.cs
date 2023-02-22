using SupportBank;
using System.Data;

CSVFileReader csv = new CSVFileReader();

List<Transaction> myTransactions=new List<Transaction>();

DataTable dataTable = csv.ReadFile();

foreach (DataRow row in dataTable.Rows)
{
    myTransactions.Add(new Transaction(row["Date"].ToString(),row["From"].ToString(),row["To"].ToString(),row["Narrative"].ToString(),Convert.ToDecimal(row["Amount"])));
}

PersonAccount personAcc = new PersonAccount(myTransactions);

List<string> BalanceList = personAcc.CalculateBalance();

foreach(string info in BalanceList ){
    Console.WriteLine(info.ToString());
}


