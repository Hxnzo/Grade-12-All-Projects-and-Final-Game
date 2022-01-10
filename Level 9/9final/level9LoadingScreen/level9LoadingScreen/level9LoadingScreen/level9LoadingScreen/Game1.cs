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
// Psuedocode
/*
Start:
        Declare all varaiables
        load image, font 
        load an array with tips and facts
        increase timer in update method
        draw loading... on screen/ change to start game when 30 seconds pass
        draw random facts on top left screen using method
        random value from array method
        {
            // get lentgh of array so can display random facts
            messageTimer++;
            if (messageTimer == 300 && timer <= 1800) newMessage = true;
            if (newMessage)
            {
                get array lenght
                set message = to array lentgh
                set message timer to 0
                newMessage = false;
            }
        }
End:
    */
namespace level9LoadingScreen
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // Set all variables
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int timer;
        Texture2D background;
        Color backgroundColour;
        Rectangle backgroundRec;
        Random  rnd;
        string[] tipsFacts;
        SpriteFont font;
        GamePadState pad1;
        int messageTimer = 0;
        string message = "";
        bool newMessage = true;
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
            rnd = new Random();
            // load font and image
            font = this.Content.Load<SpriteFont>("SpriteFont1");
            background = this.Content.Load<Texture2D>("ferrari");
            backgroundColour = new Color(255, 255, 255);
            backgroundRec = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            // load array with facts
            tipsFacts = new string[] { "Press A to use nitrous", "Stay away from the cops, they'll arrest you when you go too fast"
                , "Use the right thumbstick to turn right and left","Press the trigger to accelerate", "To exit the game press 'X'"
                , "Get first place to win prizes and cars", "When you win you will move onto a harder level", "The cops will get harder to lose on the harder levels so watch out!"
                ,"Use nitrous to gain the Lead!" };

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
            pad1 = GamePad.GetState(PlayerIndex.One);

            // when timer hits 30 secodns than allow player to press x button to exit
            if (timer >= 1800)
            {
                if (pad1.Buttons.X == ButtonState.Pressed)
                {
                    this.Exit();

                }
            }
            // increase timewr 60 times every second
                timer++;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // strat drawing
            spriteBatch.Begin();
            // draw background
            spriteBatch.Draw(background, backgroundRec, backgroundColour);
            if (timer >= 1800)
            {
                // dispplay fonts dependent on timing
                spriteBatch.DrawString(font, "Start Game",
                    new Vector2(650,430)
                    , Color.Red);
                spriteBatch.DrawString(font, "Press X to Exit",
                    new Vector2(630, 450)
                    , Color.Red);
            }
            else
            {
                spriteBatch.DrawString(font, "Loading...",
                    new Vector2(650, 430)
                    , Color.Red);
            }


            // dispaly facts
            newFact(spriteBatch, timer);

            spriteBatch.DrawString(font, message, new Vector2(12, 12), Color.Red);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        // new facts method
        private void newFact(SpriteBatch sb, int timer)
        {
            // get lentgh of array so can display random facts
            messageTimer++;
            if (messageTimer == 300 && timer <= 1800) newMessage = true;
            if (newMessage)
            {
                int idx = new Random().Next((tipsFacts.Length));
                message = (tipsFacts[idx]);
                messageTimer = 0;
                newMessage = false;
            }
        }
    }
}
