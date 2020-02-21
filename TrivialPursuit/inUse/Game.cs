using System;

class Game
{
    protected Board board;
    protected Dice dice;
    protected QuestionList questionList;
    protected Question question;
    protected Font font18;
    protected Font font30;

    private int actualPlayer;
    private int actualBox;

    private bool finished;
    private bool canShowQuestion;
    private bool canThrowDice;
    private bool failedAnswer;
    private bool successfulAnswer;

    private string[] players;

    public Game()
    {
        finished = false;
        
        font18 = new Font("data/Joystix.ttf", 18);
        font30 = new Font("data/Joystix.ttf", 30);
        board = new Board();

        dice = new Dice();
        dice.MoveTo(445, 550);
        canThrowDice = true;

        players = new string[] { "Player 1", "Computer" };

        actualBox = board.GetBoxNumber();
        actualPlayer = 0;

        questionList = new QuestionList();
        canShowQuestion = false;
        failedAnswer = false;
        successfulAnswer = false;
    }

    void UpdateScreen()
    {
        SdlHardware.ClearScreen();
        board.DrawOnHiddenScreen();
        dice.DrawOnHiddenScreen();

        SdlHardware.WriteHiddenText("Press H for Help",
            40, 5,
            0xCC, 0xCC, 0xCC,
            font18);

        SdlHardware.WriteHiddenText("Press Q to Finish",
            690, 5,
            0xCC, 0xCC, 0xCC,
            font18);

        if (!failedAnswer)
        {
            SdlHardware.WriteHiddenText(players[actualPlayer],
                420, 140,
                0xCC, 0xCC, 0xCC,
                font18);
        }

        if (questionList.GetError())
        {
            SdlHardware.WriteHiddenText("File error",
                350, 350,
                0xFF, 0x00, 0x00,
                font30);
        }

        if(canShowQuestion)
            ShowQuestion();

        if (failedAnswer)
        {
            SdlHardware.WriteHiddenText("Wrong answer",
                330, 350,
                0xFF, 0x00, 0x00,
                font30);
            SdlHardware.WriteHiddenText(
                "Next player " + players[actualPlayer],
                330, 390,
                0xCC, 0xCC, 0xCC,
                font18);
            SdlHardware.WriteHiddenText(
                "Press SPC to continue",
                330, 470,
                0x8a, 0x2b, 0xe2,
                font18);
        }

        if (successfulAnswer)
        {
            SdlHardware.WriteHiddenText("Correct answer",
                310, 350,
                0xFF, 0x00, 0x00,
                font30);

            if (actualPlayer == 0)
            {
                SdlHardware.WriteHiddenText(
                    "You can throw the dice again",
                    280, 390,
                    0xCC, 0xCC, 0xCC,
                    font18);
            }
            else if (actualPlayer == 1)
            {
                SdlHardware.WriteHiddenText(
                    "Press SPC to continue",
                    300, 470,
                    0x8a, 0x2b, 0xe2,
                    font18);
            }
        }

        SdlHardware.WriteHiddenText("D to Throw the Dice",
            340, 610,
            0xCC, 0xCC, 0xCC,
            font18);

        SdlHardware.ShowHiddenScreen();
    }

    void CheckUserInput()
    {
        if (SdlHardware.KeyPressed(SdlHardware.KEY_Q))
            finished = true;

        if (SdlHardware.KeyPressed(SdlHardware.KEY_H))
        {
            HelpScreen help = new HelpScreen();
            help.Run();
        }

        if(canThrowDice)
        {
            if (SdlHardware.KeyPressed(SdlHardware.KEY_D))
            {
                // Wait if key D is pressed
                while (SdlHardware.KeyPressed(SdlHardware.KEY_D)) { }
                ChangeTurn();
            }
        } 
    }

    private void ShowQuestion()
    {
        string title = question.GetTitle();
        short questionY = 220;

        if (title.Length > 35)
        {
            string part1 = title.Substring(0, 35).Trim();
            string part2 = title.Substring(35).Trim();

            SdlHardware.WriteHiddenText("- " + part1,
                    220, questionY,
                    0x00, 0xff, 0xff,
                    font18);
            questionY += 30;

            if (part2.Length > 35)
            {
                string newPart2 = part2.Substring(0, 35).Trim();
                string part3 = part2.Substring(35).Trim();

                SdlHardware.WriteHiddenText("  " + newPart2,
                    220, questionY,
                    0x00, 0xff, 0xff,
                    font18);
                questionY += 30;
                SdlHardware.WriteHiddenText("  " + part3,
                    220, questionY,
                    0x00, 0xff, 0xff,
                    font18);
                questionY += 30;
            }
            else
            {
                SdlHardware.WriteHiddenText("  " + part2,
                    220, questionY,
                    0x00, 0xff, 0xff,
                    font18);
                questionY += 30;
            }
        }
        else
        {
            SdlHardware.WriteHiddenText("- " + title,
            220, questionY,
            0x00, 0xff, 0xff,
            font18);
            questionY += 30;
        }

        string[] answerID = new string[] { "a)", "b)", "c)" };
        string[] answers = question.GetAnswers();
        for (int i = 0; i < answers.Length; i++)
        {
            SdlHardware.WriteHiddenText(
                answerID[i] + " " + answers[i],
                220, questionY,
                0x00, 0xff, 0xff,
                font18);
            questionY += 30;
        }

        if(actualPlayer == 0)
        {
            SdlHardware.WriteHiddenText(
                "Press A, B or C to answer",
                300, 470,
                0x8a, 0x2b, 0xe2,
                font18);
        }
        if (actualPlayer == 1)
        {
            SdlHardware.WriteHiddenText(
                "Press SPC to continue",
                300, 470,
                0x8a, 0x2b, 0xe2,
                font18);
        }
    }

    public void ChangeTurn()
    {
        failedAnswer = false;
        successfulAnswer = false;
        canThrowDice = false;

        int num = dice.Throw();
        board.MovePlayer(num);
        string category = board.GetBoxCategory();
        question = questionList.GetQuestion(category);

        canShowQuestion = true;
        UpdateScreen();
        string playerAnswer = "";

        GetPlayerAnswer(ref playerAnswer);

        if (playerAnswer == question.GetCorrectAnswer())
        {
            successfulAnswer = true;
            canShowQuestion = false;
            UpdateScreen();
            canThrowDice = true;
        }
        else
        {
            failedAnswer = true;
            canShowQuestion = false;

            if (actualPlayer == 0)
                actualPlayer++;
            else
                actualPlayer--;

            UpdateScreen();

            while (!SdlHardware.KeyPressed(SdlHardware.KEY_SPC)) { }

            canThrowDice = true;

            return;
        }
    }

    public void GetPlayerAnswer(ref string answer)
    {
        if (actualPlayer == 0)
        {
            while ((!SdlHardware.KeyPressed(SdlHardware.KEY_A))
            && (!SdlHardware.KeyPressed(SdlHardware.KEY_B))
            && (!SdlHardware.KeyPressed(SdlHardware.KEY_C))) { }

            if (SdlHardware.KeyPressed(SdlHardware.KEY_A)) answer = "a";
            else if (SdlHardware.KeyPressed(SdlHardware.KEY_B)) answer = "b";
            else if (SdlHardware.KeyPressed(SdlHardware.KEY_C)) answer = "c";
        }
        else if (actualPlayer == 1)
        {
            Random rnd = new Random();
            int id = rnd.Next(0, 2);
            if (id == 0) answer = "a";
            else if (id == 1) answer = "b";
            else if (id == 2) answer = "c";

            while (!SdlHardware.KeyPressed(SdlHardware.KEY_SPC)) { }
        }
    }

    void PauseUntilNextFrame()
    {
        SdlHardware.Pause(100);
    }

    void UpdateHighscore()
    {
        // TO DO
    }

    public void Run()
    {
        do
        {
            UpdateScreen();
            CheckUserInput();
            PauseUntilNextFrame();
        }
        while (!finished);

        UpdateHighscore();
    }
}
