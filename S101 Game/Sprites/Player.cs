using Microsoft.Xna.Framework;
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
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            bool runForest = false;

            //Start
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                runForest = true;

            //Vitesse IronBoy
            if (runForest == true)
                Velocity.X = 2F;

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                if (!(Position.Y <= 0))
                {
                    Position.Y -= 8f;     
                }
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Space) && Position.Y <= 530)
            {
                Position.Y += 10f;
            }
        }
    }
}
