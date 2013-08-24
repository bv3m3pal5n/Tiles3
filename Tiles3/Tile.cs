using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tiles3
{
    class Tile
    {
        public const int tileHeight = 48;
        public const int tileWidth = 63;

        private const int textureOffsetX = 1;
        private const int textureOffsetY = 1;
        private const int texturePaddingX = 1;
        private const int texturePaddingY = 1;

        static Random rand = new Random();

        static public Rectangle TileRectSource()
        {
            int r = rand.Next(3);
            return new Rectangle(textureOffsetX, textureOffsetY, (r * tileWidth + r * texturePaddingX), texturePaddingY);
        }
    }
}
