using System;

class Player : Sprite
{
    public Player()
    {
        LoadSequence(RIGHT,
            new string[] { "data/playerR1-2.png",
                "data/playerR2-2.png"});
        LoadSequence(LEFT,
            new string[] { "data/playerL1-2.png",
                "data/playerL2-2.png"});
        currentDirection = RIGHT;

        x = 0;
        y = 0;
        xSpeed = ySpeed = 5;
        // Tamaño colisiones player
        width = 40;
        height = 50;
    }

    public void MoveRight()
    {
        x += xSpeed;
        ChangeDirection(RIGHT);
        NextFrame();
    }

    public void MoveLeft()
    {
        x -= xSpeed;
        ChangeDirection(LEFT);
        NextFrame();
    }

    public void MoveUp()
    {
        y -= ySpeed;
    }

    public void MoveDown()
    {
        y += ySpeed;
    }
}
