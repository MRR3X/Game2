using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
    public class Player
    {
        Support.Texture left;
        Support.Texture right;
        Support.Texture active;

        public Player(Vector2 position)
        {
            left = new Support.Texture("Player1", position, new Vector2(0.2f, 0.2f));
            right = new Support.Texture("Player", position, new Vector2(0.2f, 0.2f));
            active = right;
        }

        public void Update(GameTime gameTime)
        {
            Vector2 previousPos = active.Position;
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) active.Position.Y += (float)gameTime.ElapsedGameTime.TotalSeconds * 0.5f;

              

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                active.Position.X += (float)gameTime.ElapsedGameTime.TotalSeconds * 0.3f;
                right.Position = active.Position;
                active = right;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                active.Position.X -= (float)gameTime.ElapsedGameTime.TotalSeconds * 0.3f;
                left.Position = active.Position;
                active = left;
            }

            var status = Support.Camera.GetCollision(active);
            if (status != Support.CollisionStatus.Inside)
            {
                active.Position = previousPos;
            }
        }

        public void Draw()
        {
            active.Draw();
        }
    }
}
