namespace SupportBank;

//This class gets all the unique list of persons
class PersonList{
    HashSet<string> PersonName = new HashSet<string>();
    public List<Transaction> personTransaction = new List<Transaction>();

//Constructor
    public PersonList(List<Transaction> myTransactions){
       personTransaction = myTransactions;
    }  
    
    public HashSet<string> GetPersonList (){
        foreach(Transaction transaction in personTransaction){
            PersonName.Add(transaction.From);
        }

        return PersonName;
    }
}