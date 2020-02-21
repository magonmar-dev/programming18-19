using System;

class Room
{
    protected Image brick, house, barrel, edge;

    protected int mapHeight = 13, mapWidth = 19;
    protected int tileWidth = 50, tileHeight = 50;
    protected int leftMargin = 30, topMargin = 50;

    protected string[] levelData =
    {
        "2222222222222222222",
        "2111111111111111112",
        "2414313131313134342",
        "2111411111111141112",
        "2111313133313131312",
        "2114111111111114112",
        "2131313133313131312",
        "2114111111111114112",
        "2131313133313131312",
        "2111411111111411112",
        "2134313131313134312",
        "2411111411141111142",
        "2222222222222222222"};

    public Room()
    {
        brick = new Image("data/brick.png");
        edge = new Image("data/edge.png");
        house = new Image("data/house.png");
        barrel = new Image("data/barrel.png");
    }

    public void DrawOnHiddenScreen()
    {
        for (int row = 0; row < mapHeight; row++)
        {
            for (int col = 0; col < mapWidth; col++)
            {
                int posX = col * tileWidth + leftMargin;
                int posY = row * tileHeight + topMargin;
                switch (levelData[row][col])
                {
                    case '1': SdlHardware.DrawHiddenImage(brick, posX, posY); break;
                    case '2': SdlHardware.DrawHiddenImage(edge, posX, posY); break;
                    case '3': SdlHardware.DrawHiddenImage(house, posX, posY); break;
                    case '4': SdlHardware.DrawHiddenImage(barrel, posX, posY); break;
                }
            }
        }
    }

    public bool CanMoveTo(int x1, int y1, int x2, int y2)
    {
        for (int column = 0; column < mapWidth; column++)
        {
            for (int row = 0; row < mapHeight; row++)
            {
                char tile = levelData[row][column];
                if (tile == '2' || tile == '3' || tile == '4')  // Space means a tile can be crossed
                {
                    int x1tile = leftMargin + column * tileWidth;
                    int y1tile = topMargin + row * tileHeight;
                    int x2tile = x1tile + tileWidth;
                    int y2tile = y1tile + tileHeight;
                    if ((x1tile < x2) &&
                        (x2tile > x1) &&
                        (y1tile < y2) &&
                        (y2tile > y1) // Collision as bouncing boxes
                        )
                        return false;
                }
            }
        }
        return true;
    }
}
