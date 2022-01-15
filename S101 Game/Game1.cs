﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using S101_Game.Misc;
using S101_Game.Sprites;
using System;
using System.Collections.Generic;

namespace S101_Game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 720;

        private List<ScrollingBackground> _scrollingBackgrounds;

        private Zapper _zapper;
        private Rocket _rocket;
        private Warning _warning;
        private Player _player;

        public float _rocketCoefDir;

        public Game1()
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
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var boyTexture = Content.Load<Texture2D>("Boy1");
            var zapperTexture = Content.Load<Texture2D>("Trap/Zapper");
            var rocketTexture = Content.Load<Texture2D>("Trap/Rocket");
            var warningTexture = Content.Load<Texture2D>("Warning");

            _player = new Player(boyTexture)
            {
                Position = new Vector2(50, (ScreenHeight - boyTexture.Height) - 60),
                Layer = 1f,
            };

            _zapper = new Zapper(zapperTexture)
            {
                Position = new Vector2(1280, 360),
                Layer = 1f,
            };

            _rocket = new Rocket(rocketTexture)
            {
                Position = new Vector2(1280 * 2, 360),
                Layer = 1f,
            };

            _warning = new Warning(warningTexture)
            {
                Position = new Vector2(1200, 360),
                Layer = 1f,
            };

            _scrollingBackgrounds = new List<ScrollingBackground>()
            {
                new ScrollingBackground(Content.Load<Texture2D>("ScrollingBackgrounds/Floor"), _player, 60f)
                {
                    Layer = 0.9f,
                },
                new ScrollingBackground(Content.Load<Texture2D>("ScrollingBackgrounds/Hills_Front"), _player, 40f)
                {
                    Layer = 0.8f,
                },
                new ScrollingBackground(Content.Load<Texture2D>("ScrollingBackgrounds/Hills_Middle"), _player, 30f)
                {
                    Layer = 0.79f,
                },
                new ScrollingBackground(Content.Load<Texture2D>("ScrollingBackgrounds/Clouds_Fast"), _player, 25f, true)
                {
                    Layer = 0.78f,
                },
                new ScrollingBackground(Content.Load<Texture2D>("ScrollingBackgrounds/Hills_Back"), _player, 0f)
                {
                    Layer = 0.77f,
                },
                new ScrollingBackground(Content.Load<Texture2D>("ScrollingBackgrounds/Sky"), _player, 0f)
                {
                    Layer = 0.1f,
                },
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
            _player.Update(gameTime);
            _zapper.Update(gameTime); //update Zapper
            _rocket.Update(gameTime); //update Rocket
            _warning.Update(gameTime); //update warning rocket

            _rocketCoefDir = ((_player.Position.Y - _rocket.Position.Y) / (_rocket.Position.X - 128 - _rocket.Position.X)) * 4;
            if (_rocketCoefDir > 3)
                _rocketCoefDir = 3;
            _rocket.Position.Y -= _rocketCoefDir;

            _warning.Position.Y = _rocket.Position.Y;

            if (_rocket.Position.X > _warning.Position.X)
            {
                _warning.Position.X = 1200;
            }
            else
            {
                _warning.Position.X = 1350;
            }

            foreach (var sb in _scrollingBackgrounds) //update background
            {
                sb.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.PointClamp);

            _player.Draw(gameTime, spriteBatch);
            _zapper.Draw(gameTime, spriteBatch);
            _rocket.Draw(gameTime, spriteBatch);
            _warning.Draw(gameTime, spriteBatch);

            foreach (var sb in _scrollingBackgrounds)
                sb.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
