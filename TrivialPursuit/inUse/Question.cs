using System;

class Question
{
    private const int TOTALANSWERS = 3;

    protected string title;
    protected string answer1;
    protected string answer2;
    protected string answer3;
    protected string[] answers = new string[TOTALANSWERS];
    protected string correctAnswer;
    protected string category;

    public Question(string title, string answer1, 
        string answer2, string answer3, 
        string correctAnswer, string category)
    {
        this.title = title;
        answers[0] = answer1;
        answers[1] = answer2;
        answers[2] = answer3;
        this.correctAnswer = correctAnswer;
        this.category = category;
    }

    public Question() { }

    public string GetTitle()
    {
        return title;
    }

    public string[] GetAnswers()
    {
        return answers;
    }

    public string GetCorrectAnswer()
    {
        return correctAnswer;
    }

    public string GetCategory()
    {
        return category;
    }
}
