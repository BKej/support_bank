namespace SupportBank;
using System.Collections.Generic;
using NLog;

class Accounting{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
    public List<Transaction> TransactionList = new List<Transaction>();
    HashSet<string> PersonNameList = new HashSet<string>();

    //Constructor
    public Accounting(List<Transaction> myTransactions){
       TransactionList = myTransactions;
    }  

      public HashSet<string> GetPersonList(){
        List<Person> Person = new List<Person>();
        
        //Logger.Info("Generate a unique person name list from transactionlist");
        foreach(Transaction transaction in TransactionList){
            Person.Add(new Person(transaction.From));
            foreach(Person user in Person){

                //user.Name type is string;
                PersonNameList.Add(user.Name);
            }
        }
        return PersonNameList;
    }
    
    //Method to calculate Balance for each person
    public List<string> CalculateBalance(){
        decimal amountCredit = 0;
        decimal amountDebit = 0;
        decimal balance = 0;
        string Name;
        
        List<string> balanceList = new List<string>();

        foreach(string name in GetPersonList()){
            Name = name;
            foreach (Transaction transaction in TransactionList){
                if (name == transaction.From){
                    amountCredit =+ transaction.Amount;
                }
                if (name == transaction.To){
                    amountDebit =+ transaction.Amount;
                }
                balance = amountCredit - amountDebit;
            }
            balanceList.Add($"{Name}: {balance}");
         }
        return balanceList;
    } 

    public List<string> DisplayPersonTransaction(string name){
       List<string> personTransactions = new List<string>();
        if (!GetPersonList().Contains(name)){
            throw new ArgumentOutOfRangeException($"Sorry, this name: {name} is invalid.");
        }
        
        foreach (Transaction transaction in TransactionList){
                if (name == transaction.From){
                personTransactions.Add($"{name} lent {transaction.Amount} amount to {transaction.To} on Date: {transaction.Date} for {transaction.Narrative} ");
                }
        }
        foreach (Transaction transaction in TransactionList){
              if (name == transaction.To){
                personTransactions.Add($"{name} owes {transaction.Amount} amount from {transaction.From} on Date: {transaction.Date} for {transaction.Narrative} ");
                }
        }
        
        return personTransactions;
    }

}