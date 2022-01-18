using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace S101_Game.Sprites
{
    public class Fonts : Component
    {
        protected float _layer { get; set; }

        protected SpriteFont _font;

        public float Layer
        {
            get { return _layer; }
            set
            {
                _layer = value;
            }
        }

        public Vector2 Position;

        public Fonts(SpriteFont font)
        {
            _font = font;
        }

        public override void Update(GameTime gameTime)
        {
  
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
        }
    }
}
