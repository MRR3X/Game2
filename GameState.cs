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

        Platforms platforms;
        public GameState()
        {
            player = new Player(new Vector2(0, -0.50f));
            background = new Background(new Vector2(0, 0));
            platforms = new Platforms(new Vector2(0, -0.15f));
        }

        public void Update(GameTime gameTime)
        {
            platforms.Update(gameTime);
            player.Update(gameTime);
            background.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            background.Draw();
            platforms.Draw();
            player.Draw();
           
        }
    }
}
