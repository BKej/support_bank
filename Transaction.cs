namespace SupportBank;
class Transaction{

    public string Date {get;set;}
    public string From {get;set;}
    public string To {get;set;}
    public string Narrative {get;set;}
    public decimal Amount {get; set;}

    public Transaction(string date,string from,string to,string narrative,decimal amount){
            Date= date;
            From = from;
            To = to;
            Narrative = narrative;
            Amount = amount;
     }

}
    


