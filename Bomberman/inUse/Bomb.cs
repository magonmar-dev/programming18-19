using System;
using System.Collections.Generic;

class Bomb : Sprite
{
    DateTime activationTime;
    static int timeToExplode = 5;

    public Bomb()
    {
        width = 50;
        height = 50;

        LoadSequence(APPEARING,
           new string[] { "data/bomb.png" });
        LoadSequence(DISAPPEARING,
           new string[] { "data/explosion1.png",
                "data/explosion2.png", "data/explosion3.png",
                "data/explosion4.png"});
        currentDirection = APPEARING;
    }

    public void Enable()
    {
        activationTime = DateTime.Now;
        ChangeDirection(APPEARING);
        NextFrame();
    }

    public void CheckExplosion()
    {
        if ((DateTime.Now - activationTime).Seconds > timeToExplode)
        {
            ChangeDirection(DISAPPEARING);
            NextFrame();
        }

        if ((DateTime.Now - activationTime).Seconds > timeToExplode+3)
        {
            Hide();
        }
    }
}