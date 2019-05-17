﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
    public class Player : Support.Texture
    {
        public Player(Vector2 position) : base("fox", position, new Vector2(0.2f))
        {
        }

        public void Update(GameTime gameTime)
        {
            Vector2 previousPos = Position;
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) Position.X += (float)gameTime.ElapsedGameTime.TotalSeconds * 0.5f;
            if (Keyboard.GetState().IsKeyDown(Keys.Left)) Position.X -= (float)gameTime.ElapsedGameTime.TotalSeconds * 0.5f;
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) Position.Y += (float)gameTime.ElapsedGameTime.TotalSeconds * 0.5f;
            if (Keyboard.GetState().IsKeyDown(Keys.Down)) Position.Y -= (float)gameTime.ElapsedGameTime.TotalSeconds * 0.5f;

            var status = Support.Camera.GetCollision(this);
            if (status != Support.CollisionStatus.Inside)
            {
                Position = previousPos;
            }
        }
    }
}
