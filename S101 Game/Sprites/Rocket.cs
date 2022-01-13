using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace S101_Game.Sprites
{
    public class Rocket : Sprite
    {
        public Vector2 Velocity;

        public float _initSpeed = 6f;
        public float variation = 0.5f;

        public float rotate = 0;
        public Vector2 origin;

        public Rocket(Texture2D texture)
            : base(texture)
        {
        }

        public override void Update(GameTime gameTime)
        {
            origin = new Vector2(_texture.Width / 2, _texture.Height / 2); //centrer la rocket

            Position.X -= _initSpeed;

            if (Position.X > 50)
            {

            }

            if (Position.X + _texture.Width < 0) //condition reset zapper
            {
                Position = new Vector2(1280, 360);
            }

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, rotate, origin, 1f, SpriteEffects.None, Layer);
        }
    }
}
