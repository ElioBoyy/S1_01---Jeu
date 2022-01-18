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
