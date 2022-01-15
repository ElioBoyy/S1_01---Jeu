﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace S101_Game.Sprites
{
    public class Rocket : Sprite
    {
        public Vector2 Velocity;

        public float _initSpeed = 10f;
        public float variation = 1f;

        public float rotate = 0;
        public Vector2 origin;

        public Rocket(Texture2D texture)
            : base(texture)
        {
        }

        public override void Update(GameTime gameTime)
        {
            origin = new Vector2(_texture.Width / 2, _texture.Height / 2); //centrer la rocket

            Position.Y += (float)Math.Cos(Position.X / 70) * 10f; //rocket vacillante

            if (Position.X <= - 1280 * 2)
            {
                Position.X = 1280 * 2 + _texture.Width;
            }

            Position.X -= _initSpeed;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, rotate, origin, 1f, SpriteEffects.None, Layer);
        }
    }
}
