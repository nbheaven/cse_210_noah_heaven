namespace Develop03;

class Scripture
{

    private List<Word> _word = new List<Word>();


    public void DisplayQuiz()
    {
        bool t = false;

        while (t == false ){
    
            var q = Console.ReadLine();

            if (q == "q"){
        
                Console.WriteLine("User has quit the program");
                break;
            }

            if (_word.All(w => w.GetBool()))
            {
                t = true;
            }

            Console.Clear();
            List<string> scripture = new List<string>(); 

            Random random = new Random();

            for (int i = 0; i < 2;)
            {

                if (_word.All(w => w.GetBool()))
                {
                    Console.WriteLine("All word bools are true. Exiting loop.");
                    break;
                }
        
                int iWord = random.Next(0, _word.Count);
                if (_word[iWord].GetBool() == false ){

                    _word[iWord].SetBool();

                    i++;
                }

            }

            foreach (Word word in _word){

                scripture.Add(word.DisplayWord());
            }

            Console.WriteLine(String.Join(" ", scripture));
     

            foreach (Word word in _word)
            {
                word.DisplayWord();
            }
        }
    }

    public List<Word> ToWordList(string scripture)
    {
        List<string> words = new List<string>();
        string[] wordArray = scripture.Split(' ');
        foreach (string word in wordArray)
        {
            _word.Add(new Word(word));
        }
    
        return _word;
    }

}