namespace SupportBank;
using System.Collections.Generic;
class PersonAccount {

    public string Name {get;set;}
    public decimal AmountCredit {get;set;}
    public decimal AmountDebit {get;set;}
    public decimal Balance{get;set;}
    public List<string> BalanceList = new List<string>();
HashSet<string> PersonName = new HashSet<string>();
    List<Transaction> personTransaction;
    public PersonAccount(List<Transaction> myTransactions){
       personTransaction = myTransactions;
    }  
    
    

    
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

}