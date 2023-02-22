namespace SupportBank;
using System.Collections.Generic;
class PersonAccount {

    public string Name {get;set;}
    public decimal AmountCredit {get;set;}
    public decimal AmountDebit {get;set;}
    public decimal Balance{get;set;}
    public List<string> BalanceList = new List<string>();

    public List<string> TransactionList = new List<string>();
    HashSet<string> PersonName = new HashSet<string>();
    List<Transaction> personTransaction;

    //Constructor
    public PersonAccount(List<Transaction> myTransactions){
       personTransaction = myTransactions;
    }  
    
    //Method to calculate Balance for each person
    public List<string> CalculateBalance(){
        foreach(Transaction transaction in personTransaction){
            PersonName.Add(transaction.From);
        }

        foreach(string name in PersonName){
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
         
        return (BalanceList);
    } 

    public List<string> DisplayPersonTransaction(string name){
        if (!PersonName.Contains(name)){
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