using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
    public class Player : Support.Texture
    {
         
        public Player(Vector2 position) : base("player", position, new Vector2(0.2f, 0.2f))
        {
          
        }

        public void Update(GameTime gameTime)
        {
            Vector2 previousPos = Position;
            if (Keyboard.GetState().IsKeyDown(Keys.Space)) Position.Y += (float)gameTime.ElapsedGameTime.TotalSeconds * 0.5f;
      
            if (Keyboard.GetState().IsKeyDown(Keys.Left))Position.X -= (float)gameTime.ElapsedGameTime.TotalSeconds * 0.3f;
            
            if (Keyboard.GetState().IsKeyDown(Keys.Right))Position.X += (float)gameTime.ElapsedGameTime.TotalSeconds * 0.3f;
          

            var status = Support.Camera.GetCollision(this);
            if (status != Support.CollisionStatus.Inside)
            {
                Position = previousPos;
            }
        }
    }
}
