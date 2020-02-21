using System;

class Dice : Sprite
{
    protected int number;
    protected string[] images;

    public Dice()
    {
        images = new string[] {"data/dice1.png",
            "data/dice2.png", "data/dice3.png", "data/dice4.png",
            "data/dice5.png", "data/dice6.png" };

        LoadImage(images[1]);

        x = 0;
        y = 0;
        width = 50;
        height = 50;
    }

    public int Throw()
    {
        Random rnd = new Random();
        number = rnd.Next(1, 6);
        LoadImage(images[number - 1]);
        return number;
    }
}