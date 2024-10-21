class JsonQuery {

private string _jsonFilePath;
private string _scripture;
private string _scriptureReference;

public JsonQuery(){

    _jsonFilePath = "lds-scriptures.json"

    _scripture = ""

    _scriptureReference = ""

}

public string QueryJson(){
    Console.writeLine("Please input the scripture reference to memorize. Ex. Genesis 1:2")
    _scriptureReference = Console.Read()

    string jsonString = File.ReadAllText(jsonFilePath);
    JsonDocument jsonDoc = JsonDocument.Parse(jsonString);
    JsonElement root = jsonDoc.RootElement;
    
    if (root.TryGetProperty("verse_title", out JsonElement nameElement))
{
    string verse_title = nameElement.GetString();
    
    Console.WriteLine($"verse title: {verse_title}");
}

    return _scripture

}


}