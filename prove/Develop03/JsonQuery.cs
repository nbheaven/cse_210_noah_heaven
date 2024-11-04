using System;   
using System.IO;
using System.Text.Json;
class JsonQuery {

private string _jsonFilePath;
private string _scripture;
private string _scriptureReference;

public JsonQuery(){

    _jsonFilePath = "lds-scriptures.json";

    _scripture = "";

    _scriptureReference = "";

}

public string QueryJson(){

    Console.WriteLine("Please input the scripture reference to memorize. Ex. Genesis 1:2 or Gen. 1:2. Or enter 'q' to quit");
        bool b = false;

        while (b == false) 
        {

        _scriptureReference = Console.ReadLine();


        if (_scriptureReference == "q"){

            break;
        }

        string jsonString = File.ReadAllText(_jsonFilePath);
        JsonDocument jsonDoc = JsonDocument.Parse(jsonString);
        JsonElement root = jsonDoc.RootElement;

            foreach (JsonElement element in root.EnumerateArray())
            {
                if (element.TryGetProperty("verse_title", out JsonElement nameElement) && element.TryGetProperty("verse_short_title", out JsonElement shortNameElement))
                {

                    if ((nameElement.GetString() == _scriptureReference || shortNameElement.GetString() == _scriptureReference) && element.TryGetProperty("scripture_text", out JsonElement scriptureElement))
                    {
                        _scripture = scriptureElement.GetString();

                        Console.WriteLine(_scripture);

                        b = true;
                                
                        break;
                    }
                    
                    
                }


            }

            if(b==false)
            {

                Console.WriteLine("Reference not found. Check spelling and try again.");
            }
        }


        return _scripture;

            }
            
        

}
