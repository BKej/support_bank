namespace SupportBank;
using Newtonsoft.Json;
using System.IO;


class JSONFileReader{

//method to read a jsonfile;
public List<Transaction> JSONReadFile(string FileName){

    string json = File.ReadAllText(FileName);

    List<Transaction> obj = JsonConvert.DeserializeObject<List<Transaction>>(json)!;

    return obj;

}

}