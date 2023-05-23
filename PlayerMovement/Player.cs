using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PlayerMovement
{
    public class Player
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }

        public Player(Vector2 position)
        {
            Position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White);
        }
    }
}
