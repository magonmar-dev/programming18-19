using System;

class Enemy : Sprite
{
    public Enemy()
    {
        LoadImage("data/enemy-2.png");
        width = 40;
        height = 50;
        xSpeed = 5;
    }

    public override void Move()
    {
        x += xSpeed;
        /*
        if ((x < 50) || (x > 970))
            xSpeed = -xSpeed;
        */
        
    }
}
