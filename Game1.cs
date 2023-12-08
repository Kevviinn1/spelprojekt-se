using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Security.Cryptography;

namespace Spelprojekt_Kevin_Ö
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;

        Texture2D spaceBild;
        Texture2D bucketBild;
        Texture2D starBild;

       
        Vector2 spacePosition = new Vector2(0, 0);
        KeyboardState tangentbord = Keyboard.GetState();
        Random RandomNummer = new Random();
        Rectangle starRectangle = new Rectangle (300, 100, 0, 0);
        Rectangle bucketRectangle = new Rectangle(550, 550, 450, 250);
        
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
            spaceBild = Content.Load<Texture2D>("space");
            bucketBild = Content.Load<Texture2D>("bucket");
            starBild = Content.Load<Texture2D>("star");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {

            starRectangle.Y += 8;

            int Random = RandomNummer.Next(0, 1100);

            tangentbord = Keyboard.GetState();
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                bucketRectangle.X -= 10;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                bucketRectangle.X += 10;
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
            spriteBatch.Draw(starBild, starRectangle, Color.White);
            spriteBatch.Draw(spaceBild, spacePosition, Color.White);
            spriteBatch.Draw(bucketBild, bucketRectangle, Color.White);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
