using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Cow : Support.Texture
    {
        Vector2 direction;

        public Cow(Vector2 position, float size) : base("Cow", position, new Vector2(size))
        {
            direction.X = 1f;
            direction = Vector2.Transform(direction, Matrix.CreateRotationZ((float)Game1.sRandom.NextDouble() * (float)Math.PI * 2));
        }

        public float Radius
        {
            get => size.X * 0.5f;
            set => size.X = size.Y = value * 2f;
        }

        public void Update(GameTime gameTime)
        {
            var status = Support.Camera.GetCollision(this);
            switch (status)
            {
                case Support.CollisionStatus.Bottom:
                case Support.CollisionStatus.Top:
                    direction.Y *= -1;
                    Position += direction * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case Support.CollisionStatus.Left:
                case Support.CollisionStatus.Right:
                    direction.X *= -1;
                    Position += direction * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
            }
            Position += direction * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
