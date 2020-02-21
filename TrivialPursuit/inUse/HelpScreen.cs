using System;

class HelpScreen
{
    public void Run()
    {
        string[] text =
        {
            "Press D to throw the dice",
            "Your game piece will move to the next box",
            "Press A, B or C to choose the answer",
            "Wait your turn",
            "Actual player is indicated above",
            "Press Q to quit the game",
            " ",
            "Try to use arrow keys to move",
            "the player only in this screen",
            " ",
            "Press R to Return"
        };

        Image background = new Image("data/board.png");
        Font font18 = new Font("data/Joystix.ttf", 18);

        Player player = new Player();
        player.MoveTo(430, 550);
        short playerSpeed = 4;

        byte color = 255;
        short x = 180;
        short y = 180;
        short spacing = 40;

        do
        {
            SdlHardware.ClearScreen();
            SdlHardware.DrawHiddenImage(background, 0, 0);

            color = 255;
            y = 180;
            for (int i = 0; i < text.Length; i++)
            {
                SdlHardware.WriteHiddenText(text[i],
                    x, y,
                    color, color, color,
                    font18);
                color -= 15;
                y += spacing;
            }
            player.DrawOnHiddenScreen();
            SdlHardware.ShowHiddenScreen();

            if (SdlHardware.KeyPressed(SdlHardware.KEY_RIGHT)
                && (player.GetX() < 600))
            {
                player.ChangeDirection(Sprite.RIGHT);
                SdlHardware.ScrollHorizontally((short)(-playerSpeed));
                player.MoveTo(player.GetX() + playerSpeed, player.GetY());
                player.NextFrame();
            }
            if (SdlHardware.KeyPressed(SdlHardware.KEY_LEFT)
                && (player.GetX() > 300))
            {
                player.ChangeDirection(Sprite.LEFT);
                SdlHardware.ScrollHorizontally(playerSpeed);
                player.MoveTo(player.GetX() - playerSpeed, player.GetY());
                player.NextFrame();
            }
            
            SdlHardware.Pause(40);
        }
        while (!SdlHardware.KeyPressed(SdlHardware.KEY_R));
        SdlHardware.ResetScroll();
    }
}
