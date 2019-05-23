using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class GameState
    {
      
        Player player;
        Background background;
        Vector2 pos = new Vector2();

        public GameState()
        {
            player = new Player(new Vector2(0, 0));
          
            background = new Background(new Vector2(0, 0));
        }

        public void Update(GameTime gameTime)
        {
          /*  pos = new Vector2(player.Position.X,player.Position.Y);
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                
                player1.Position = pos;
            }*/

            player.Update(gameTime);
            background.Update(gameTime);

        }

        public void Draw(GameTime gameTime)
        {

            background.Draw();

         



            player.Draw();

            //if (Keyboard.GetState().IsKeyDown(Keys.R))
            //{
            //    player.Position.X=0;
            //    player.Position.Y = 0;
            //}
        }
    }
}
