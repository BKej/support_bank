namespace SupportBank;
class PersonAccount {

    public string Name {get;set;}
    public decimal AmountCredit {get;set;}
    public decimal AmountDebit {get;set;}
    public decimal Balance{get;set;}

    Transaction personTransaction;
    public PersonAccount(Transaction myTransactions){
       personTransaction = myTransactions;
    }    
    public decimal CalculateBalance(string name){
        
        if (name == personTransaction.From){
            AmountCredit =+ personTransaction.Amount;
        }

        if (name == personTransaction.To){
            AmountDebit =+ personTransaction.Amount;
        }

        return (Balance = AmountCredit - AmountDebit);
    }

    // all the transactions, from and to
    // public DisplayTransaction(NameFrom){

    // }

}