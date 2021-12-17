﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tutorial023.Sprites
{
    public class Player : Sprite
    {
        public Vector2 Velocity;

        public Player(Texture2D texture)
            : base(texture)
        {
        }

        public override void Update(GameTime gameTime)
        {
            bool runForest = false;

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                runForest = true;

            if (runForest == true)
                Velocity.X = 3F;
        }
    }
}