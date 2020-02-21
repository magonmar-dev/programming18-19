// BOMBERMAN

// Date        Author + Changes
// ---------   ------------------------------
// 27-Feb-19   Cristina Francés: Help Screen

using System;

class HelpScreen
{
    public void Run()
    {
        string[] text =
        {
            "Use arrow keys to move right, ",
            "left or up and down",
            "Press SPACE to put a bomb",
            "Beware of enemies that move, kill!",
            " ",
            "Press R to return"
        };

        Image background = new Image("data/help.png");
        Font font18 = new Font("data/Joystix.ttf", 18);
        SdlHardware.ClearScreen();
        SdlHardware.DrawHiddenImage(background, 0, 0);

        byte white = 200;
        short x = 440;
        short y = 400;
        short spacing = 40;

        for (int i = 0; i < text.Length; i++)
        {
            SdlHardware.WriteHiddenText(text[i],
                x, y,
                white, white, white,
                font18);
            white -= 20;
            y += spacing;
        }
        SdlHardware.ShowHiddenScreen();

        do
        {
            SdlHardware.Pause(100);
        }
        while (!SdlHardware.KeyPressed(SdlHardware.KEY_R));
    }
}
