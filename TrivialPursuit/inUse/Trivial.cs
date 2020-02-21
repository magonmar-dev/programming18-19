class Trivial
{
    public static void Main(string[] args)
    {
        bool fullScreen = false;
        SdlHardware.Init(960, 750, 24, fullScreen);

        WelcomeScreen w = new WelcomeScreen();

        do
        {
            w.Run();
            if (w.GetChosenOption() == 1)
            {
                Game g = new Game();
                g.Run();
            }
            else if (w.GetChosenOption() == 2)
            {
                HelpScreen help = new HelpScreen();
                help.Run();
            }
            else if (w.GetChosenOption() == 3)
            {
                CreditsScreen credits = new CreditsScreen();
                credits.Run();
            }
        } while (w.GetChosenOption() != 4);
    }
}