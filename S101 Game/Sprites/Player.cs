using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace S101_Game.Sprites
{
    public class Player : Sprite
    {
        public Vector2 Velocity;

        private float _flyingSpeed = 1f;
        private float _increaser = 0.15f;

        public Player(Texture2D texture)
            : base(texture)
        {
        }

        public override void Update(GameTime gameTime)
        {
            float jetpackPower = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Position.Y >= 594) { Math.Abs(_flyingSpeed); _flyingSpeed = 1f; } //Reset sol

            Velocity.X = 1F;

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                if (Position.Y <= 0)
                {
                    Position.Y = 0.1f; //bornage
                    _flyingSpeed = 0f;
                }
                else
                {
                    Position.Y -= _flyingSpeed; //poussée jetpack
                    _flyingSpeed += _increaser;
                }
            }
            else
            {
                if (Position.Y <= 595)
                {
                    Position.Y -= _flyingSpeed;
                    _flyingSpeed -= _increaser * 3; //Gravité, n* le coef de poussée (augmente avec le temps | peut être constant avec un réel)
                }
                else { Position.Y = 602; }
                if (Position.Y <= 0)
                {
                    Position.Y = 0.1f; //bornage
                    _flyingSpeed = 0f;
                }
            }

            //Pas pour l'accélération de poussée du jetpack
            _increaser += jetpackPower / 1000;
        }
    }
}
