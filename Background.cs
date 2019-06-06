using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
   public class Background : Support.Texture
    {
        public Background(Vector2 position) : base("background10", position, new Vector2(4f,2f))
        {
           
        }

        public void Update(GameTime gameTime)
        {
            Vector2 previousPos = Position;
            
            var status = Support.Camera.GetCollision(this);
            if (status != Support.CollisionStatus.Inside)
            {
                Position = previousPos;
            }
        }
    }
}