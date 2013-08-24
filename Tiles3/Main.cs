using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;

namespace Tiles3
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Main : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont debugFont;
        Texture2D tileSheet;
        Board board;

        string fpstring; int fps; float time; MouseState ms; Stopwatch stopwatch = new Stopwatch();

        Vector2 gameBoardOrigin = new Vector2(70, 70);

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            ms = Mouse.GetState();
            board = new Board();
            stopwatch.Start();
            Window.Title = "good kid, m.A.A.d tiles";
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            debugFont = Content.Load<SpriteFont>(@"debugFont");
            tileSheet = Content.Load<Texture2D>(@"Tiles\tilesheet");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            #region debug
            ms = Mouse.GetState();
            time = (float)stopwatch.Elapsed.Seconds;
            fps++;
            if (time >= 1)
            {
                fpstring = fps.ToString();
                fps = 0;
                stopwatch.Restart();
            }
            #endregion
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AntiqueWhite);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.DrawString(debugFont, "X:" + ms.X + " Y:" + ms.Y + "\nFPS:" + fpstring, new Vector2(2, 2), Color.Black);
            for (int x = 0; x < Board.TileWidth; x++)
            {
                for (int y = 0; y < Board.TileHeight; y++)
                {
                    int posX = (int)gameBoardOrigin.X + (x * Tile.tileWidth);
                    int posY = (int)gameBoardOrigin.Y + (y * Tile.tileHeight);
                    spriteBatch.Draw(tileSheet, new Rectangle(posX, posY, Tile.tileWidth, Tile.tileHeight), board.GetSource(x,y), Color.White);
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
