using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spelprojekt_Kevin_Ö
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;

        Texture2D starBild;
        Texture2D spaceBild;
        Texture2D bucketBild;

        Vector2 bucketPosition = new Vector2(100, 100);
        Vector2 starPosition = new Vector2(500, 200);
        Vector2 spacePosition = new Vector2(200, 500);
        float bucketSpeed = 3;
        KeyboardState tangentbord = Keyboard.GetState();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;

            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            starBild = Content.Load<Texture2D>("star");
            spaceBild = Content.Load<Texture2D>("space");
            bucketBild = Content.Load<Texture2D>("bucket");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            tangentbord = Keyboard.GetState();

            if (tangentbord.IsKeyDown(Keys.Left) || tangentbord.IsKeyDown(Keys.A))
            {
                bucketPosition.X -= bucketSpeed;
            }
            if (tangentbord.IsKeyDown(Keys.Right) || tangentbord.IsKeyDown(Keys.D))
            {
                bucketPosition.X += bucketSpeed;
            }

                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(starBild, starPosition, Color.White);
            spriteBatch.Draw(spaceBild, spacePosition, Color.White);
            spriteBatch.Draw(bucketBild, bucketPosition, Color.White);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
