class CreditsScreen
{
    protected Player player;

    public void Run()
    {
        Image credits = new Image("data/credits.png");
        Font font18 = new Font("data/Joystix.ttf", 18);
        Font font40 = new Font("data/Joystix.ttf", 40);

        player = new Player();
        player.MoveTo(80,538);
        player.SetSpeed(50, 0);

        do
        {
            SdlHardware.ClearScreen();
            SdlHardware.DrawHiddenImage(credits, 0, 0);
            SdlHardware.WriteHiddenText("Thanks for playing",
                50, 30,
                0xCC, 0xCC, 0xCC,
                font18);
            SdlHardware.WriteHiddenText("Press R to Return",
                680, 30,
                0xCC, 0xCC, 0xCC,
                font18);
            SdlHardware.WriteHiddenText("Trivial by María",
                220, 640,
                0xCC, 0xCC, 0xCC,
                font40);
            player.DrawOnHiddenScreen();
            SdlHardware.ShowHiddenScreen();
            
            player.Move();

            SdlHardware.Pause(100);
        } while (!SdlHardware.KeyPressed(SdlHardware.KEY_R));
    }
}