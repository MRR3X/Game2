using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame.Support
{
    static class Font
    {
        static private SpriteFont sFont;
        static private Vector2 sLocation = new Vector2(5, 5);
        static private Vector2 sLocation2 = new Vector2(5, 25);

        static public void Setup()
        {
            sFont = Game1.sContent.Load<SpriteFont>("fArial");
        }

        static public void PrintStatus(string msg, Color color)
        {
            Game1.sSpriteBatch.DrawString(sFont, msg, sLocation, color);
        }

        static public void PrintStatus2(string msg, Color color)
        {
            Game1.sSpriteBatch.DrawString(sFont, msg, sLocation2, color);
        }

        static public void PrintStatusLine(string msg, int line, Color color)
        {
            Vector2 location = sLocation;
            location.Y += (line) * 20;
            Game1.sSpriteBatch.DrawString(sFont, msg, location, color);
        }

        static public void PrintAt(Vector2 pos, string msg, Color color)
        {
            Point p = Camera.ConvertToPosition(pos);
            Game1.sSpriteBatch.DrawString(sFont, msg, new Vector2(p.X, p.Y), color);
        }
    }
}
