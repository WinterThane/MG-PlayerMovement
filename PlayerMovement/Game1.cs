using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlayerMovement
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Player _player;
        const float PLAYER_SPEED = 5.0f;
        int _move;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 1200;
            _graphics.ApplyChanges();

            _player = new Player(new Vector2(800, 600));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _player.Texture = Content.Load<Texture2D>("Player/AirplaneSpritesheet");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

            KeyboardState keyboardState = Keyboard.GetState();

            Vector2 direction = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.W))
            {
                direction.Y--;
                _move = 3;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                direction.Y++;
                _move = 0;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                direction.X--;
                _move = 1;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                direction.X++;
                _move = 2;
            }

            if (direction.Length() > 0.0f)
            {
                direction.Normalize();
            }

            _player.Position += direction * PLAYER_SPEED;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            Move(_move, _player.Position);
            int time = gameTime.TotalGameTime.Milliseconds / 100;
            if (time % 2 == 0)
            {
                _move = 0;
            }
            else
            {
                _move = 4;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void Move(int move, Vector2 position)
        {
            Rectangle sourceRect = new(0, move * 128, 64, 128);
            _spriteBatch.Draw(_player.Texture, position, sourceRect, Color.White);
        }
    }
}