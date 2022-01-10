using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Tutorial023.Sprites
{
    public class Player : Sprite
    {
        public Vector2 Velocity;

        private float _flyingSpeed = 1;
        private float _increaser = 0.15f;

        public Player(Texture2D texture)
            : base(texture)
        {
        }

        public override void Update(GameTime gameTime)
        {
            bool runForest = false;
            float jetpackPower = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Position.Y >= 594) { Math.Abs(_flyingSpeed); _flyingSpeed = 1f; }

            //Start
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                runForest = true;

            //Vitesse IronBoy
            if (runForest == true)
                Velocity.X = 1F;

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                if (Position.Y <= 0)
                {
                    Position.Y = 0.1f;
                    _flyingSpeed = 0f;
                }
                else
                {
                    Position.Y -= _flyingSpeed;
                    _flyingSpeed += _increaser;
                }
            }
            else
            {
                if (Position.Y <= 595)
                {
                    Position.Y -= _flyingSpeed;
                    _flyingSpeed -= _increaser * 3;
                }
                else { Position.Y = 602; }
                if (Position.Y <= 0)
                {
                    Position.Y = 0.1f;
                    _flyingSpeed = 0f;
                }
            }

            _increaser += jetpackPower / 10000;


            Console.WriteLine(_flyingSpeed + "   " + Position.Y + "   " + _increaser);
        }
    }
}
