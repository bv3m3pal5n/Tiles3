using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tiles3
{
    class Board
    {
        //List<Rectangle> Tileinfo = new List<Rectangle>();
        static public Rectangle[,] Tilegen;
        public const int TileWidth = 10;
        public const int TileHeight = 8;

        public Tile[,] Tileboard;

        public Board()
        {
            Tileboard = new Tile[TileWidth, TileHeight];
            GenerateTiles();
        }

        private void GenerateTiles()
        {
            for (int x = 0; x < TileWidth; x++)
            {
                for (int y = 0; y < TileHeight; y++)
                {
                    Tilegen[x, y] = Tile.TileRectSource();
                }
            }
        }

        public Rectangle GetSource(int x, int y)
        {
            return Tilegen[x, y];
        }
    }
}
