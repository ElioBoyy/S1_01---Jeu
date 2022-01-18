using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace S101_Game.Sprites
{
    public class FontApply : Fonts
    {
        public FontApply(SpriteFont font)
            : base(font)
        {
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, $"Score.{(int)(gameTime.TotalGameTime.TotalSeconds * 3)}", Position, Color.White);
        }
    }
}
