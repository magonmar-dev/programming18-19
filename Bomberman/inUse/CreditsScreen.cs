using System;

class CreditsScreen
{
    public void Run()
    {
        Image welcome = new Image("data/welcome.png");
        Font font18 = new Font("data/Joystix.ttf", 18);
        SdlHardware.ClearScreen();
        SdlHardware.DrawHiddenImage(welcome, 0, 0);
        SdlHardware.WriteHiddenText("Bomberman by María",
            40, 10,
            0xCC, 0xCC, 0xCC,
            font18);
        SdlHardware.WriteHiddenText("R to Return",
            460, 470,
            0xBB, 0xBB, 0xBB,
            font18);
        SdlHardware.ShowHiddenScreen();

        do
        {
            SdlHardware.Pause(100); // To avoid using 100% CPU
        } while (!SdlHardware.KeyPressed(SdlHardware.KEY_R));
    }
}
