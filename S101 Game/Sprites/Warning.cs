using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace S101_Game.Sprites
{
    public class Warning : Sprite
    {
        public Vector2 Velocity;

        public float _initSpeed = 0f;

        public Vector2 origin;

        public Warning(Texture2D texture)
            : base(texture)
        {
        }

        public override void Update(GameTime gameTime)
        {
            origin = new Vector2(_texture.Width / 2, _texture.Height / 2); //centrer le warning
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, 0, origin, 1f, SpriteEffects.None, Layer);
        }
    }
}
