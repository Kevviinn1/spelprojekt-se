using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Security.Cryptography;
using static System.Formats.Asn1.AsnWriter;

namespace Spelprojekt_Kevin_Ö
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;

        Texture2D spaceBild;
        Texture2D basketBild;
        Texture2D starBild;

        SpriteFont Times;

        int score = 0;
       
        Vector2 spacePosition = new Vector2(0, 0);
        KeyboardState tangentbord = Keyboard.GetState();
        Random RandomNummer = new Random();
        Rectangle starRectangle = new Rectangle(300, 100, 80, 80);
        Rectangle basketRectangle = new Rectangle(550, 550, 250, 210);
        
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
            basketBild = Content.Load<Texture2D>("basket");
            starBild = Content.Load<Texture2D>("star");

            Times = Content.Load<SpriteFont>("Times");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {

            starRectangle.Y += 8;

            int Random = RandomNummer.Next(0, 1100);

            tangentbord = Keyboard.GetState();
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                basketRectangle.X -= 10;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                basketRectangle.X += 10;
            }

            if (basketRectangle.Intersects(starRectangle))
            {
                starRectangle = new Rectangle(Random, 20, 80, 80);
                score++;
            }

            base.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(spaceBild, spacePosition, Color.White);
            spriteBatch.Draw(basketBild, basketRectangle, Color.White);
            spriteBatch.Draw(starBild, starRectangle, Color.White);
            spriteBatch.DrawString(Times, score.ToString(), Vector2.Zero, Color.White);
            spriteBatch.End();
           
          
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
