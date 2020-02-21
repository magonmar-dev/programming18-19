class WelcomeScreen
{
    protected Image welcome;
    protected int option;
    protected Font font24;

    public WelcomeScreen()
    {
        welcome = new Image("data/welcome.png");
        option = 0;
        font24 = new Font("data/Joystix.ttf", 24);
    }

    public int GetChosenOption()
    {
        return option;
    }

    public void Run()
    {
        option = 0;
        SdlHardware.ClearScreen();
        SdlHardware.DrawHiddenImage(welcome, 0, 0);

        SdlHardware.WriteHiddenText("1. Play",
            140, 60,
            0xCC, 0xCC, 0xCC,
            font24);
        SdlHardware.WriteHiddenText("2. Help",
            300, 60,
            0xCC, 0xCC, 0xCC,
            font24);
        SdlHardware.WriteHiddenText("3. Credits",
            470, 60,
            0xCC, 0xCC, 0xCC,
            font24);
        SdlHardware.WriteHiddenText("Q. Quit",
            700, 60,
            0xCC, 0xCC, 0xCC,
            font24);

        SdlHardware.ShowHiddenScreen();

        do
        {
            if (SdlHardware.KeyPressed(SdlHardware.KEY_1))
            {
                option = 1;
            }
            if (SdlHardware.KeyPressed(SdlHardware.KEY_2))
            {
                option = 2;
            }
            if (SdlHardware.KeyPressed(SdlHardware.KEY_3))
            {
                option = 3;
            }
            if (SdlHardware.KeyPressed(SdlHardware.KEY_Q))
            {
                option = 4;
            }
            SdlHardware.Pause(100);
        }
        while (option == 0);
    }
}
