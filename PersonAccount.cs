namespace SupportBank;
class PersonAccount {

    public string Name {get;set;}
    public decimal AmountCredit {get;set;}
    public decimal AmountDebit {get;set;}
    public decimal Balance{get;set;}

    List<Transaction> personTransaction;
    public PersonAccount(List<Transaction> myTransactions){
       personTransaction = myTransactions;
    }    
    public decimal CalculateBalance(string name){
        
        foreach (Transaction transaction in personTransaction){
            if (name == transaction.From){
                AmountCredit =+ transaction.Amount;
        }

            if (name == transaction.To){
                AmountDebit =+ transaction.Amount;
        }

        }
       
        return (Balance = AmountCredit - AmountDebit);
    }

    // all the transactions, from and to
    // public DisplayTransaction(NameFrom){

    // }

}