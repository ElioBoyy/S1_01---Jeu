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

        private Texture2D boyTexture;
        private Texture2D zapperTexture;
        private Texture2D rocketTexture;
        private Texture2D warningTexture;

        private Sectors _sectorsA;
        private Sectors _sectorsB;
        private Sectors _sectorsC;
        private Sectors _sectorsD;

        private Texture2D sectorA;
        private Texture2D sectorB;
        private Texture2D sectorC;
        private Texture2D sectorD;

        private FontApply _font;
        private SpriteFont font;

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

            boyTexture = Content.Load<Texture2D>("Boy1");//load player
            zapperTexture = Content.Load<Texture2D>("Trap/Zapper");//load Zapper
            rocketTexture = Content.Load<Texture2D>("Trap/Rocket");//load Rocket
            warningTexture = Content.Load<Texture2D>("Warning");//load Warning

            sectorA = Content.Load<Texture2D>("Sectors/SectorA");
            sectorB = Content.Load<Texture2D>("Sectors/SectorB");
            sectorC = Content.Load<Texture2D>("Sectors/SectorC");
            sectorD = Content.Load<Texture2D>("Sectors/SectorD");

            font = Content.Load<SpriteFont>("fontScore");

            _font = new FontApply(font)
            {
                Position = new Vector2(0, 0),
                Layer = 1f,
            };

            //Init traps
            _zapper = new Zapper(zapperTexture)
            {
                Position = new Vector2(1280, 360),
                Layer = 0.63f,
            };

            _rocket = new Rocket(rocketTexture)
            {
                Position = new Vector2(1280 * 2, 360),
                Layer = 0.62f,
            };

            _warning = new Warning(warningTexture)
            {
                Position = new Vector2(1200, 360),
                Layer = 0.61f,
            };

            //init player
            _player = new Player(boyTexture)
            {
                Position = new Vector2(50, ScreenHeight - boyTexture.Height - 60),
                Layer = 0.6f,
            };

            //Init Sectors
            _sectorsA = new Sectors(sectorA)
            {
                Position = new Vector2(-150, 0),
                Layer = 0.54f,
            };

            _sectorsB = new Sectors(sectorB)
            {
                Position = new Vector2(-150, 0),
                Layer = 0.53f,
            };

            _sectorsC = new Sectors(sectorC)
            {
                Position = new Vector2(-150, 0),
                Layer = 0.52f,
            };

            _sectorsD = new Sectors(sectorD)
            {
                Position = new Vector2(-150, 0),
                Layer = 0.51f,
            };

            //init background
            _scrollingBackgrounds = new List<ScrollingBackground>()
            {
                new ScrollingBackground(Content.Load<Texture2D>("ScrollingBackgrounds/Floor"), _player, 60f)
                {
                    Layer = 0.4f,
                },
                new ScrollingBackground(Content.Load<Texture2D>("ScrollingBackgrounds/Hills_Front"), _player, 40f)
                {
                    Layer = 0.3f,
                },
                new ScrollingBackground(Content.Load<Texture2D>("ScrollingBackgrounds/Hills_Middle"), _player, 30f)
                {
                    Layer = 0.29f,
                },
                new ScrollingBackground(Content.Load<Texture2D>("ScrollingBackgrounds/Clouds_Fast"), _player, 25f, true)
                {
                    Layer = 0.28f,
                },
                new ScrollingBackground(Content.Load<Texture2D>("ScrollingBackgrounds/Hills_Back"), _player, 0f)
                {
                    Layer = 0.27f,
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
            _player.Update(gameTime); //update Player
            _zapper.Update(gameTime); //update Zapper
            _rocket.Update(gameTime); //update Rocket
            _warning.Update(gameTime); //update warning rocket

            //Rocket suit le Joueur (méthode smooth)
            _rocketCoefDir = ((_player.Position.Y - _rocket.Position.Y) / (_rocket.Position.X - 128 - _rocket.Position.X)) * 4;

            if (_rocketCoefDir > 2) //si coef dir trop élevé: bloque à 3x
                _rocketCoefDir = 2;

            _rocket.Position.Y -= _rocketCoefDir;

            //warning rocket en approche
            _warning.Position.Y = _rocket.Position.Y;

            //Avertissement rocket
            if (_rocket.Position.X > _warning.Position.X + 100)
            {
                _warning.Position.X = 1200;
            }
            else
            {
                _warning.Position.X = 1350;
            }

            //update background
            foreach (var sb in _scrollingBackgrounds)
            {
                sb.Update(gameTime);
            }

            //Intersections
            if (_player.Rectangle.Intersects(_rocket.Rectangle))
            {

            }
            if (_player.Rectangle.Intersects(_zapper.Rectangle))
            {
                
            }

            //Sectors
            if (gameTime.TotalGameTime.TotalSeconds <= 60) { _sectorsA.Position = new Vector2(10, 0); }
            else if (gameTime.TotalGameTime.TotalSeconds <= 120) { _sectorsB.Position = new Vector2(10, 0); _sectorsA.Position = new Vector2(-150, 0); }
            else if (gameTime.TotalGameTime.TotalSeconds <= 150) { _sectorsC.Position = new Vector2(10, 0); _sectorsB.Position = new Vector2(-150, 0); }
            else if (gameTime.TotalGameTime.TotalSeconds <= 180) { _sectorsD.Position = new Vector2(10, 0); _sectorsC.Position = new Vector2(-150, 0); }



            Console.WriteLine(gameTime.TotalGameTime.TotalSeconds);

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

            _font.Draw(gameTime, spriteBatch);
            _zapper.Draw(gameTime, spriteBatch);
            _rocket.Draw(gameTime, spriteBatch);
            _warning.Draw(gameTime, spriteBatch);
            _sectorsA.Draw(gameTime, spriteBatch);
            _sectorsB.Draw(gameTime, spriteBatch);
            _sectorsC.Draw(gameTime, spriteBatch);
            _sectorsD.Draw(gameTime, spriteBatch);

            _player.Draw(gameTime, spriteBatch);

            foreach (var sb in _scrollingBackgrounds)
                sb.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
