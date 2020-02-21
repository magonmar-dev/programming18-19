// BOMBERMAN

// Date        Author + Changes
// ---------   ------------------------------
// 27-Feb-19   Cristina Francés: Help Screen

using System;
using System.Collections.Generic;

class Game
{
    protected Player player;
    protected int numEnemies;
    protected Enemy[] enemies;
    protected Room room;
    protected bool finished;
    protected Font font18;
    protected List<Bomb> bombs;

    public Game()
    {
        player = new Player();
        player.MoveTo(135, 205);

        numEnemies = 2;
        enemies = new Enemy[numEnemies];
        
        for (int i = 0; i < numEnemies; i++)
        {
            enemies[i] = new Enemy();
        }

        bombs = new List<Bomb>();

        finished = false;

        Random rnd = new Random();
        for (int i = 0; i < numEnemies; i++)
        {
            enemies[i].MoveTo(rnd.Next(200, 800), rnd.Next(50, 600));
            enemies[i].SetSpeed(rnd.Next(1, 5), rnd.Next(1, 5));
        }

        font18 = new Font("data/Joystix.ttf", 18);
        room = new Room();
    }

    void UpdateScreen()
    {
        SdlHardware.ClearScreen();
        room.DrawOnHiddenScreen();

        SdlHardware.WriteHiddenText("Score: ",
            40, 10,
            0xCC, 0xCC, 0xCC,
            font18);

        SdlHardware.WriteHiddenText("Press H for Help",
            780, 10,
            0xCC, 0xCC, 0xCC,
            font18);

        player.DrawOnHiddenScreen();
        for (int i = 0; i < numEnemies; i++)
            enemies[i].DrawOnHiddenScreen();
        for (int j = 0; j < bombs.Count; j++)
            bombs[j].DrawOnHiddenScreen();

        SdlHardware.ShowHiddenScreen();
    }

    void CheckUserInput()
    {
        if (SdlHardware.KeyPressed(SdlHardware.KEY_RIGHT))
        {
            if (room.CanMoveTo(player.GetX() + player.GetSpeedX(),
                    player.GetY(),
                    player.GetX() + player.GetWidth() + player.GetSpeedX(),
                    player.GetY() + player.GetHeight()))
                player.MoveRight();
        }
        if (SdlHardware.KeyPressed(SdlHardware.KEY_LEFT))
        {
            if (room.CanMoveTo(player.GetX() - player.GetSpeedX(),
                    player.GetY(),
                    player.GetX() + player.GetWidth() - player.GetSpeedX(),
                    player.GetY() + player.GetHeight()))
                player.MoveLeft();
        }
        if (SdlHardware.KeyPressed(SdlHardware.KEY_UP))
        {
            if (room.CanMoveTo(player.GetX(),
                    player.GetY() - player.GetSpeedY(),
                    player.GetX() + player.GetWidth(),
                    player.GetY() + player.GetHeight() - player.GetSpeedY()))
                player.MoveUp();
        }
        if (SdlHardware.KeyPressed(SdlHardware.KEY_DOWN))
        {
            if (room.CanMoveTo(player.GetX(),
                    player.GetY() + player.GetSpeedY(),
                    player.GetX() + player.GetWidth(),
                    player.GetY() + player.GetHeight() + player.GetSpeedY()))
                player.MoveDown();
        }

        if (SdlHardware.KeyPressed(SdlHardware.KEY_SPC))
        {
            bombs.Add(new Bomb());
            bombs[bombs.Count - 1].MoveTo(player.GetX(), player.GetY());
            bombs[bombs.Count - 1].Show();
            bombs[bombs.Count - 1].Enable();
        }

        if (SdlHardware.KeyPressed(SdlHardware.KEY_H))
        {
            HelpScreen help = new HelpScreen();
            help.Run();
        }

        if (SdlHardware.KeyPressed(SdlHardware.KEY_ESC))
            finished = true;
    }
    
    void UpdateWorld()
    {
        // Move enemies, background, etc 
        for (int i = 0; i < numEnemies; i++)
            enemies[i].Move();
    }

    void CheckGameStatus()
    {
        // Check collisions and apply game logic
        for (int i = 0; i < numEnemies; i++)
            if (player.CollisionsWith(enemies[i]))
                finished = true;

        for (int i = 0; i < bombs.Count; i++)
        {
            bombs[i].CheckExplosion();
        }
    }
    
    void PauseUntilNextFrame()
    {
        SdlHardware.Pause(40);
    }

    void UpdateHighscore()
    {
        // Save highest score
        // TO DO
    }

    public void Run()
    {
        do
        {
            UpdateScreen();
            CheckUserInput();
            UpdateWorld();
            PauseUntilNextFrame();
            CheckGameStatus();
        }
        while (!finished);

        UpdateHighscore();
    }
}