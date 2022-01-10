using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Color_nerve_lab
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //color varibales
        byte redIntensity = 0;
        byte greenIntensity = 0;
        byte blueIntensity = 0;

        bool gameOver = false;

        Random rand = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            GamePadState pad1 = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyboard = Keyboard.GetState();

            //allows the game to exit
            if (keyboard.IsKeyDown(Keys.Escape))
                this.Exit();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //if the "B" button on the cotroller is pressed or the "R" button on the keyboard then add 1 to redintensity
            if (pad1.Buttons.B == ButtonState.Pressed || keyboard.IsKeyDown(Keys.R))
                //add 1 
                redIntensity++;

            //if the "A" button on the cotroller is pressed or the "G" button on the keyboard then add 1 to greenintensity
            if (pad1.Buttons.A == ButtonState.Pressed || keyboard.IsKeyDown(Keys.G))
                //add 1
                greenIntensity++;

            //if the "X" button on the cotroller is pressed or the "B" button on the keyboard then add 1 to blueintensity
            if (pad1.Buttons.X == ButtonState.Pressed || keyboard.IsKeyDown(Keys.B))
                //add 1
                blueIntensity++;

            //if the "Y" button on the cotroller is pressed or the "Y" button on the keyboard then add 1 to redintensity and greenintensity
            if (pad1.Buttons.Y == ButtonState.Pressed || keyboard.IsKeyDown(Keys.Y))
            {
                //add 1
                greenIntensity++;
                //add 1
                redIntensity++;
            }

            //if the intensities equal to 255 then run the statement
            if (redIntensity >= 255 || greenIntensity >= 255 || blueIntensity >= 255)
                //sets gameOver to true
                gameOver = true;

            //runs if gameOver is true
            if(gameOver)
            {
                //makes the controller vibrate
                GamePad.SetVibration(PlayerIndex.One, 0, 1);

                //stes intensities to 0
                redIntensity = 0;
                greenIntensity = 0;
                blueIntensity = 0;

                //creates color variable
                Color blackBackground;
                //makes black color
                blackBackground = new Color(0, 0, 0);

                //change color to black
                GraphicsDevice.Clear(blackBackground);
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
          

            //creates color variable
            Color backgroundColor;

            //makes a random color
            backgroundColor = new Color(redIntensity, greenIntensity, blueIntensity);

            //changes color
            GraphicsDevice.Clear(backgroundColor);

                base.Draw(gameTime);
        }
    }
}
