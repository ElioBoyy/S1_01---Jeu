using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace S101_Game.Sprites
{
    public class Zapper : Sprite
    {
        public Vector2 Velocity;

        public float _initSpeed = 1f;
        public float _speedUp = 0.002f;

        public float rotate = 0;
        public Vector2 origin;

        public int randomPositionY = 0;

        public Zapper(Texture2D texture)
            : base(texture)
        {
        }

        public override void Update(GameTime gameTime)
        {
            float rotator = (float)gameTime.ElapsedGameTime.TotalSeconds * 1.5f; //vitesse rota zapper

            origin = new Vector2(_texture.Width / 2, _texture.Height / 2); //centrer la rota zapper
            rotate += rotator; //enclancher la rota zapper

            _initSpeed += _speedUp; //tarer la vitesse du zapper sur la vitesse du sol

            if (Position.X + _texture.Width * 2 < 0) //condition reset zapper
            {
                Random _random = new Random();
                randomPositionY = _random.Next(_texture.Height / 2, 720 - _texture.Height / 2 - 60);
                Position += new Vector2(1280 + _texture.Width * 4, 0);
                Position.Y = randomPositionY;
            }

            Position -= new Vector2(_initSpeed, 0);

            Console.WriteLine(randomPositionY);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, rotate, origin, 1f, SpriteEffects.None, Layer);
        }
    }
}
