namespace SupportBank;
using System.Collections.Generic;
using NLog;
using NLog.Config;
using NLog.Targets;

class Accounts{
private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

    public string Name {get;set;}
    public decimal Balance{get;set;}
    public List<Transaction> personTransaction = new List<Transaction>();
    public PersonList personList;

    //Constructor
    public Accounts(List<Transaction> myTransactions){
       personTransaction = myTransactions;
       //we need to initialise personList
       personList = new PersonList(personTransaction);
    }  
    
    //Method to calculate Balance for each person
    public List<string> CalculateBalance(){

        decimal AmountCredit = 0;
        decimal AmountDebit = 0;
        
        List<string> BalanceList = new List<string>();

        foreach(string name in personList.GetPersonList()){
            Name = name;
            foreach (Transaction transaction in personTransaction){
                if (name == transaction.From){
                    AmountCredit =+ transaction.Amount;
                }
                if (name == transaction.To){
                    AmountDebit =+ transaction.Amount;
                }
                Balance = AmountCredit - AmountDebit;
            }
            BalanceList.Add($"{Name}: {Balance}");
         }
         
        return BalanceList;
    } 

    public List<string> DisplayPersonTransaction(string name){
        List<string> TransactionList = new List<string>();

        if (!personList.GetPersonList().Contains(name)){
            throw new ArgumentOutOfRangeException($"Sorry, this name: {name} is invalid.");
        }
        
        foreach (Transaction transaction in personTransaction){
                if (name == transaction.From){
                TransactionList.Add($"{name} owes :- Transaction Date: {transaction.Date}, Transaction To: {transaction.To}, Transaction Narrative: {transaction.Narrative}, Transaction Amount: {transaction.Amount}");
                }

                if (name == transaction.To){
                TransactionList.Add($"{name} needs to give :-, Transaction Date: {transaction.Date}, Transaction From: {transaction.From}, Transaction Narrative: {transaction.Narrative}, Transaction Amount: {transaction.Amount}");
                }
        }
        
        return TransactionList;
    }

}