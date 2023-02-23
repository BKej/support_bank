namespace SupportBank;
class Person{
    public string Name;

    //Constructor
    public Person(string name){
       Name = name;
    }

    public override string ToString()
    {
        return $"Name: {Name}";
    }
    
}