using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace S101_Game.Sprites
{
    public class Sprite : Component
    {
        protected float _layer { get; set; }

        protected Texture2D _texture;

        public float Layer
        {
            get { return _layer; }
            set
            {
                _layer = value;
            }
        }

        public Vector2 Position;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);//borne les images
            }
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public override void Update(GameTime gameTime)
        {
  
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, Layer);//draw le fond d'écran avec tous les parametres
        }
    }
}
