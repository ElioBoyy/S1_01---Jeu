using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using S101_Game.Misc;
using S101_Game.Sprites;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace S101_Game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Start : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D textureBG;
        Sectors _BG;
        private MenuFont _fontEnter;
        private MenuFont _fontQuit;
        private MenuFont _silverMan;
        private MenuFont _team;
        private SpriteFont font;
        private SpriteFont team;

        public int difficulty = 0;

        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 768;

        public Start()
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
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight;
            graphics.ApplyChanges();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            textureBG = Content.Load<Texture2D>("LoadingBG");
            _BG = new Sectors(textureBG)
            {
                Position = new Vector2(0, 0),
            };

            font = Content.Load<SpriteFont>("fontScore");
            team = Content.Load<SpriteFont>("teamFont");

            _fontEnter = new MenuFont(font)
            {
                write = "Entrer pour jouer",
                Position = new Vector2(ScreenWidth / 2.65f, 610),
                Layer = 1f,
            };
            _fontQuit = new MenuFont(font)
            {
                write = "Echap ou Retour pour quitter",
                Position = new Vector2(ScreenWidth / 3.4f, 660),
                Layer = 1f,
            };
            _silverMan = new MenuFont(font)
            {
                write = "Silver Man : JoyRide",
                Position = new Vector2(ScreenWidth / 3f, 25),
                Layer = 1f,
            };
            _team = new MenuFont(team)
            {
                write = "Team 667",
                Position = new Vector2(ScreenWidth - 100, ScreenHeight - 35),
                Layer = 1f,
            };
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            var kbState = Keyboard.GetState();

            if (kbState.IsKeyDown(Keys.Enter))
            {
                using (var game = new Game1())
                    game.Run();
            }
            else if (kbState.IsKeyDown(Keys.Escape) || kbState.IsKeyDown(Keys.Back))
            {
                this.Exit();
            }
            else { }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.PointClamp);

            _BG.Draw(gameTime, spriteBatch);
            _fontEnter.Draw(gameTime, spriteBatch);
            _fontQuit.Draw(gameTime, spriteBatch);
            _silverMan.Draw(gameTime, spriteBatch);
            _team.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
