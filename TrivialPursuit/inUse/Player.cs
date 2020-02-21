class Player : Sprite
{
    public Player()
    {
        LoadSequence(RIGHT, new string[] {"data/playerC6.png",
            "data/playerC5.png","data/playerC4.png","data/playerC3.png",
            "data/playerC2.png","data/playerC1.png","data/playerC.png"});

        LoadSequence(LEFT, new string[] {"data/playerC.png",
            "data/playerC1.png", "data/playerC2.png", "data/playerC3.png",
            "data/playerC4.png", "data/playerC5.png", "data/playerC6.png" });
        currentDirection = RIGHT;

        x = 0;
        y = 0;
        width = 60;
        height = 60;
        xSpeed = 0;
    }

    // Only for the animation of CreditsScreen
    public override void Move()
    {
        if (x > 800)
        {
            xSpeed = -xSpeed;
            ChangeDirection(LEFT);
            NextFrame();
        }
        else if(x < 80)
        {
            xSpeed = -xSpeed;
            ChangeDirection(RIGHT);
            NextFrame();
        }

        x += xSpeed;
        ChangeDirection(RIGHT);
        NextFrame();
    }
}
