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

decimal BalanceAmount = personAcc.CalculateBalance("Jon A");


//foreach (Transaction transaction in myTransactions){
    Console.WriteLine(BalanceAmount);

