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

namespace Moodlight_Lab
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 


    /*
        Start
            create variables for color
            create bool variables for counting up the color intensity
            create tick integer 
                Update
                    if the redintensity equals to 255 then return false
                    if the redintensity equals to 0 then return true
                    if redcountingup then redintensity adds 1 each time
                        else
                            redinstensity minus 1 each time
                    if the greenintensity equals to 255 then return false
                    if the greenintensity equals to 0 then return true
                    if greencountingup then redintensity adds 1 each time
                        else
                            greeninstensity minus 1 each time
                    if the blueintensity equals to 255 then return false
                    if the blueintensity equals to 0 then return true
                    if bluecountingup then redintensity adds 1 each time
                        else
                            blueinstensity minus 1 each time
                    redintensity adds by one (++)
                    greenintensity adds by one (++)
                    blueintensity adds by one (++)
                update end

                draw
                    change backfround color at random numbers between 0 - 255
                    if tick equals to 10 then screen turns black
        End
    */
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //color varibales
        byte redIntensity = 0;
        byte greenIntensity = 80;
        byte blueIntensity = 160;

        bool redCountingUp = true;
        bool greenCountingUp = true;
        bool blueCountingUp = true;

        int tick = 0;

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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //if it equals to 255 run code
            if (redIntensity == 255)
                //return false
                redCountingUp = false;
            //if it equals to 0 run code
            if (redIntensity == 0)
                //return true
                redCountingUp = true;
            //when it counts
            if (redCountingUp)
                //add 1 
                redIntensity++;
            else
                redIntensity--;

            if (greenIntensity == 255)
                greenCountingUp = false;
            if (greenIntensity == 0)
                greenCountingUp = true;
            if (greenCountingUp)
                greenIntensity++;
            else
                greenIntensity--;

            if (blueIntensity == 255)
                blueCountingUp = false;
            if (blueIntensity == 0)
                blueCountingUp = true;
            if (blueCountingUp)
                blueIntensity++;
            else
                blueIntensity--;

            if (tick == 11)
                tick = 0;

            tick++;

            redIntensity++;
            greenIntensity++;
            blueIntensity++;


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
            Color blackBackground;

            //makes a random color
            backgroundColor = new Color(rand.Next(256), rand.Next(256), rand.Next(256));

            //makes black color
            blackBackground = new Color(0, 0, 0);

            //changes color
            GraphicsDevice.Clear(backgroundColor);

            //if it equals 10
            if(tick == 10)
            {
                //change color to black
                GraphicsDevice.Clear(blackBackground);
            }

            base.Draw(gameTime);
        }
    }
}
