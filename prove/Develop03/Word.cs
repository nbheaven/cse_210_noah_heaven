class Word
{
    private bool _hide;
    private string _word;
    private string _blank;

public Word(string word){

    _hide = false;

    _blank = "______";

    _word = word;
    
}

public string DisplayWord()
{
    if (_hide == true){

        return _blank;
    }

    else{

        return _word;
    }
}

public void SetBool()
{

    _hide = true;

}

public bool GetBool(){

    return _hide;

}

}