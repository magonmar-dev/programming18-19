using System;
using System.IO;
using System.Collections.Generic;

class QuestionList
{
    private const byte TOTALQUESTIONS = 10; // Number of questions per category
    private const byte LINES = 5; // Number of file lines per question
    private const byte TOTALLINES = 50; // Number lines per file/category

    private List<string> lines;

    protected SortedList<int, Question> geographyQuestions;
    protected SortedList<int, Question> scienceQuestions;
    protected SortedList<int, Question> entertainmentQuestions;
    protected SortedList<int, Question> sportsQuestions;

    protected bool error;

    public string[] categories;
    public string[] colors;

    public QuestionList()
    {
        categories = new string[] {
            "geography", "science", "entertainment", "sports"};
        colors = new string[] {
            "orange", "blue", "red", "green"};

        error = false;

        geographyQuestions = new SortedList<int, Question>();
        scienceQuestions = new SortedList<int, Question>();
        entertainmentQuestions = new SortedList<int, Question>();
        sportsQuestions = new SortedList<int, Question>();

        lines = new List<string>();

        LoadQuestions();
        ExtractQuestionFormat();
    }

    public bool GetError()
    {
        return error;
    }

    public void LoadQuestions()
    {
        foreach(string c in categories)
        {
            string name = "data/" + c + ".txt";
            StreamReader inputfile;

            try
            {
                inputfile = File.OpenText(name);
                string line;

                do
                {
                    line = inputfile.ReadLine();
                    if (line != null)
                    {
                        lines.Add(line);
                    }
                }
                while (line != null);
                inputfile.Close();
            }
            catch (IOException e)
            {
                error = true;
                SaveError(e);
            }
        }
    }
    
    public void ExtractQuestionFormat()
    {
        byte counter = 0;
        string category;

        int id = 0;
        Question q;
        string title = "";
        string answer1 = "";
        string answer2 = "";
        string answer3 = "";
        string correctAnswer = "";
        
        for (int i = 0; i < lines.Count; i++)
        {
            category = categories[counter];

            if (lines[i].Trim().StartsWith("#"))
            {
                int stopPostion = lines[i].IndexOf(".");
                id = Convert.ToInt32(lines[i].Substring(1, (stopPostion-1)));
                title = lines[i].Trim().Substring(4);
            }

            if (lines[i].Trim().StartsWith("a)"))
                answer1 = lines[i].Substring(3);
            else if (lines[i].Trim().StartsWith("b)"))
                answer2 = lines[i].Substring(3);
            else if (lines[i].Trim().StartsWith("c)"))
                answer3 = lines[i].Substring(3);

            if (lines[i].Contains("sol"))
            {
                correctAnswer = lines[i].Substring(lines[i].IndexOf(" ") + 1);
            }

            if ( i % TOTALLINES == 49) // Pass to next category
                counter++;

            if ( i % LINES == 4) // New question
            {
                q = new Question(title, answer1, answer2, answer3, 
                    correctAnswer, category);
                SaveQuestion(id, category, q);
            }
        }
    }
    
    public void SaveQuestion(int id, string category, Question q)
    {
        if (category == categories[0])
            geographyQuestions.Add(id, q);
        else if (category == categories[1])
            scienceQuestions.Add(id, q);
        else if (category == categories[2])
            entertainmentQuestions.Add(id, q);
        else if (category == categories[3])
            sportsQuestions.Add(id, q);
    }

    public void SaveError(IOException e)
    {
        StreamWriter outputFile;
        string errorName = "errors.txt";
        
        outputFile = File.Exists(errorName) ? 
            File.AppendText(errorName) : File.CreateText(errorName);

        outputFile.WriteLine(e.Message);
    }

    public Question GetQuestion(string category)
    {
        Random rnd = new Random();
        int id = rnd.Next(1, 10);

        Question q = new Question();

        if (category == categories[0])
            q = geographyQuestions[id];
        else if (category == categories[1])
            q = scienceQuestions[id];
        else if (category == categories[2])
            q = entertainmentQuestions[id];
        else if (category == categories[3])
            q = sportsQuestions[id];

        return q;
    }
}
