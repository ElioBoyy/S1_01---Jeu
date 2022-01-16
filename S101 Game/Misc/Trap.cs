using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using S101_Game.Sprites;

namespace S101_Game.Misc
{
    public class Trap : Component
    {
        private float _speedUp = 1f;

        private float _layer;

        private List<Sprite> _sprites;

        private readonly Player _player;

        private float _speed;

        public float Layer
        {
            get { return _layer; }
            set
            {
                _layer = value;

                foreach (var sprite in _sprites)
                    sprite.Layer = _layer;
            }
        }

        public Trap(Texture2D texture, Player player, float scrollingSpeed, bool constantSpeed = false)
          : this(new List<Texture2D>() { texture, texture }, player, scrollingSpeed, constantSpeed) {}

        public Trap(List<Texture2D> textures, Player player, float scrollingSpeed, bool constantSpeed = false)
        {
            _player = player;

            _sprites = new List<Sprite>();

            for (int i = 0; i < textures.Count; i++)
            {
                var texture = textures[i];

                _sprites.Add(new Sprite(texture)
                {
                    Position = new Vector2(i * texture.Width - Math.Min(i, i + 1), Game1.ScreenHeight - texture.Height),
                });
            }
        }

        public override void Update(GameTime gameTime)
        {
            _speedUp += 0.002f; //Coef d'accélération du perso

            ApplySpeed(gameTime);
        }

        private void ApplySpeed(GameTime gameTime)
        {
            _speed = (float)(gameTime.ElapsedGameTime.TotalSeconds);

            foreach (var sprite in _sprites)
            {
                sprite.Position.X -= _speed;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var sprite in _sprites)
                sprite.Draw(gameTime, spriteBatch);
        }
    }
}
