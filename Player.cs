using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MyGame
{
    public class Player
    {
        Support.Texture lleft;
        Support.Texture rright;
        Support.Texture up;
        Support.Texture down;
        Support.Texture left;
        Support.Texture right;
        Support.Texture active;
        Support.Texture downn;
        Support.Texture BulletR;
        Support.Texture BulletL;
        Support.Texture abullet;
        List<Bullet> Bullets = new List<Bullet>();

        public Player(Vector2 position)

        {
            left = new Support.Texture("Player1", position, new Vector2(0.2f, 0.2f));
            right = new Support.Texture("Player", position, new Vector2(0.2f, 0.2f));

            up = new Support.Texture("up", position, new Vector2(0.2f, 0.2f));
            rright = new Support.Texture("right", position, new Vector2(0.2f, 0.2f));
            lleft = new Support.Texture("left", position, new Vector2(0.2f, 0.2f));
            down = new Support.Texture("down", position, new Vector2(0.2f, 0.2f));
            downn = new Support.Texture("downn", position, new Vector2(0.2f, 0.2f));
            active = right;

            BulletL = new Support.Texture("bulletL", position, new Vector2(0.2f, 0.2f));
            BulletR = new Support.Texture("bulletR", position, new Vector2(0.2f, 0.20f));
            abullet = BulletR;
        }

        public void Update(GameTime gameTime)
        {

            Vector2 previousPos = active.Position;

            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
                up.Position = active.Position;
                active = up;
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                { active.Position.X += (float)gameTime.ElapsedGameTime.TotalSeconds * 0.3f; rright.Position = active.Position; active = rright; }
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    active.Position.X -= (float)gameTime.ElapsedGameTime.TotalSeconds * 0.3f; lleft.Position = active.Position; active = lleft;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    active.Position.Y += (float)gameTime.ElapsedGameTime.TotalSeconds * 0.3f; up.Position = active.Position; active = up;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    active.Position.Y -= (float)gameTime.ElapsedGameTime.TotalSeconds * 0.2f; down.Position = active.Position; active = down;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Down) && Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    active.Position.Y -= (float)gameTime.ElapsedGameTime.TotalSeconds * 0.2f; downn.Position = active.Position; active = downn;
                }
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.LeftControl))
            {
                right.Position = active.Position; active = right;

                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                { active.Position.X += (float)gameTime.ElapsedGameTime.TotalSeconds * 0.3f; right.Position = active.Position; active = right; active.Position.Y -= 0.001f; }
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                { active.Position.X -= (float)gameTime.ElapsedGameTime.TotalSeconds * 0.3f; left.Position = active.Position; active = left; active.Position.Y -= 0.001f; }
            }

            if (active == left)
            {
                active.Position.Y -= (float)gameTime.ElapsedGameTime.TotalSeconds * 0.5f; left.Position = active.Position;

            }
            if (active == right)
            { active.Position.Y -= (float)gameTime.ElapsedGameTime.TotalSeconds * 0.5f; right.Position = active.Position; }

            if (active.Position.Y < -1.2f)
            { active.Position.Y = -1.2f; active.Position.X = previousPos.X; }

           for (int i = Bullets.Count; i >= 0; i++)
            {
                abullet.Position = active.Position;
                if (Keyboard.GetState().IsKeyDown(Keys.Space) )
                {
                    abullet.Position.X += (float)gameTime.ElapsedGameTime.TotalSeconds * 0.5f; abullet = BulletR;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Space) )
                {
                    abullet.Position.X -= (float)gameTime.ElapsedGameTime.TotalSeconds * 0.5f; abullet = BulletL;
                }

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
            abullet.Draw();

        }
    }

    internal class Bullet
    {
    }
}
