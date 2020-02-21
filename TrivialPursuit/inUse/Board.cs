using System.Collections.Generic;

class Board
{
    private struct Box
    {
        public int x;
        public int y;
        public string category;
        public string color;
        public bool isColorBox;
    }

    private List<Box> Boxes { get; set; }

    protected Image blue, orange, red, green, 
        science, geografy, entertainment, sports;
    protected Player player;
    protected QuestionList questions;

    protected int mapHeight = 8, mapWidth = 8;
    protected int boxWidth = 112, boxHeight = 90;
    protected int leftMargin = 30, topMargin = 30;
    protected int currentPosition = 0;

    protected string[] levelData =
    {
        "OSFTPSFB",
        "T      P",
        "P      T",
        "F      S",
        "S      F",
        "T      P",
        "P      T",
        "RFSPTFSG"};

    public Board()
    {
        blue = new Image("data/blue.png");
        orange = new Image("data/orange.png");
        red = new Image("data/red.png");
        green = new Image("data/green.png");
        science = new Image("data/science.png");
        geografy = new Image("data/geografy.png");
        entertainment = new Image("data/entertainment.png");
        sports = new Image("data/sports.png");
        
        questions = new QuestionList();

        Boxes = new List<Box>();
        SetBoxes();

        player = new Player();
        player.MoveTo(leftMargin + boxWidth / 4, topMargin + boxHeight / 4);
    }

    public void DrawOnHiddenScreen()
    {
        for (int row = 0; row < mapHeight; row++)
        {
            for (int col = 0; col < mapWidth; col++)
            {
                int posX = col * boxWidth + leftMargin;
                int posY = row * boxHeight + topMargin;
                switch (levelData[row][col])
                {
                    case 'B':
                        SdlHardware.DrawHiddenImage(blue, posX, posY);
                        break;
                    case 'O':
                        SdlHardware.DrawHiddenImage(orange, posX, posY);
                        break;
                    case 'R':
                        SdlHardware.DrawHiddenImage(red, posX, posY);
                        break;
                    case 'G':
                        SdlHardware.DrawHiddenImage(green, posX, posY);
                        break;
                    case 'S':
                        SdlHardware.DrawHiddenImage(science, posX, posY);
                        break;
                    case 'F':
                        SdlHardware.DrawHiddenImage(geografy, posX, posY);
                        break;
                    case 'T':
                        SdlHardware.DrawHiddenImage(entertainment, posX, posY);
                        break;
                    case 'P': SdlHardware.DrawHiddenImage(sports, posX, posY);
                        break;
                }
            }
        }
        player.DrawOnHiddenScreen();
    }

    private void SetBoxes()
    {
        int boxCounter = 0;

        while (boxCounter < 28)
        {
            for (int row = 0; row < mapHeight; row++)
            {
                for (int col = 0; col < mapWidth; col++)
                {
                    int posX = col * boxWidth + leftMargin;
                    int posY = row * boxHeight + topMargin;

                    string newCategory = "";
                    string newColor = "";
                    bool newIsColorBox = false;

                    bool isBox = false;

                    if (boxCounter == 0 && row == 0 && col == 0)
                    {
                        newCategory = questions.categories[0];
                        newColor = questions.colors[0];
                        newIsColorBox = true;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 1 && row == 0 && col == 1)
                    {
                        newCategory = questions.categories[1];
                        newColor = questions.colors[1];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 2 && row == 0 && col == 2)
                    {
                        newCategory = questions.categories[0];
                        newColor = questions.colors[0];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 3 && row == 0 && col == 3)
                    {
                        newCategory = questions.categories[2];
                        newColor = questions.colors[2];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 4 && row == 0 && col == 4)
                    {
                        newCategory = questions.categories[3];
                        newColor = questions.colors[3];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 5 && row == 0 && col == 5)
                    {
                        newCategory = questions.categories[1];
                        newColor = questions.colors[1];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 6 && row == 0 && col == 6)
                    {
                        newCategory = questions.categories[0];
                        newColor = questions.colors[0];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 7 && row == 0 && col == 7)
                    {
                        newCategory = questions.categories[1];
                        newColor = questions.colors[1];
                        newIsColorBox = true;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 8 && row == 1 && col == 7)
                    {
                        newCategory = questions.categories[3];
                        newColor = questions.colors[3];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 9 && row == 2 && col == 7)
                    {
                        newCategory = questions.categories[2];
                        newColor = questions.colors[2];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 10 && row == 3 && col == 7)
                    {
                        newCategory = questions.categories[1];
                        newColor = questions.colors[1];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 11 && row == 4 && col == 7)
                    {
                        newCategory = questions.categories[0];
                        newColor = questions.colors[0];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 12 && row == 5 && col == 7)
                    {
                        newCategory = questions.categories[3];
                        newColor = questions.colors[3];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 13 && row == 6 && col == 7)
                    {
                        newCategory = questions.categories[2];
                        newColor = questions.colors[2];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 14 && row == 7 && col == 7)
                    {
                        newCategory = questions.categories[3];
                        newColor = questions.colors[3];
                        newIsColorBox = true;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 15 && row == 7 && col == 6)
                    {
                        newCategory = questions.categories[1];
                        newColor = questions.colors[1];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 16 && row == 7 && col == 5)
                    {
                        newCategory = questions.categories[0];
                        newColor = questions.colors[0];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 17 && row == 7 && col == 4)
                    {
                        newCategory = questions.categories[2];
                        newColor = questions.colors[2];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 18 && row == 7 && col == 3)
                    {
                        newCategory = questions.categories[3];
                        newColor = questions.colors[3];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 19 && row == 7 && col == 2)
                    {
                        newCategory = questions.categories[1];
                        newColor = questions.colors[1];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 20 && row == 7 && col == 1)
                    {
                        newCategory = questions.categories[0];
                        newColor = questions.colors[0];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 21 && row == 7 && col == 0)
                    {
                        newCategory = questions.categories[2];
                        newColor = questions.colors[2];
                        newIsColorBox = true;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 22 && row == 6 && col == 0)
                    {
                        newCategory = questions.categories[3];
                        newColor = questions.colors[3];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 23 && row == 5 && col == 0)
                    {
                        newCategory = questions.categories[2];
                        newColor = questions.colors[2];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 24 && row == 4 && col == 0)
                    {
                        newCategory = questions.categories[1];
                        newColor = questions.colors[1];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 25 && row == 3 && col == 0)
                    {
                        newCategory = questions.categories[0];
                        newColor = questions.colors[0];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 26 && row == 2 && col == 0)
                    {
                        newCategory = questions.categories[3];
                        newColor = questions.colors[3];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }
                    else if (boxCounter == 27 && row == 1 && col == 0)
                    {
                        newCategory = questions.categories[0];
                        newColor = questions.colors[0];
                        newIsColorBox = false;
                        isBox = true;
                        boxCounter++;
                    }

                    if (isBox)
                    {
                        Box box = new Box();
                        box.x = posX;
                        box.y = posY;
                        box.category = newCategory;
                        box.color = newColor;
                        box.isColorBox = newIsColorBox;
                        Boxes.Add(box);
                    }
                }
            }
        }
    }

    public int GetBoxNumber()
    {
        return currentPosition;
    }

    public string GetBoxCategory()
    {
        return Boxes[currentPosition].category;
    }

    public string GetBoxColor()
    {
        return Boxes[currentPosition].color;
    }

    public bool GetIsColorBox()
    {
        return Boxes[currentPosition].isColorBox;
    }

    public void MovePlayer(int number)
    {
        currentPosition += number;
        if (currentPosition >= 28)
            currentPosition -= 28;
        int x = Boxes[currentPosition].x + boxWidth / 4;
        int y = Boxes[currentPosition].y + boxHeight / 4;
        player.MoveTo(x, y);
    }
}
