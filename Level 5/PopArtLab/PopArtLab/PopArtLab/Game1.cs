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

/*
    Psuedocode

        Start
            declare a variable that will load the picture and the font that you will be using
            set the 2D array size for the string array
            set a word for each set of points within the array
            set the 2D array size for the rectangle array
            create for loop to run 2 times
            create another for loop to run 2 times
            draw image in each quadrant
            create 2 for loops that run 2 times each
            call the color method from the rectangles class
            print the image in each quadrant
            set the color of each quadrant
            print the words in each quadrant
        End

           
*/

namespace PopArtLab
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D background;
        Random rnd = new Random();

        SpriteFont font;

        Rectangles[,] quad; 
        string[,] words;

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
            //loads the picture anf ont from references
            background = Content.Load<Texture2D>("R34");
            font = Content.Load<SpriteFont>("SpriteFont");

            words = new string[2, 2];
            words[0, 0] = "The";
            words[0, 1] = "Best";
            words[1, 0] = "Car";
            words[1, 1] = "Ever";

            quad = new Rectangles[2, 2];

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    quad[i, j] = new Rectangles(
                        
                        i, j, 

                        new Rectangle(i * GraphicsDevice.Viewport.Width / 2,
                                                j * GraphicsDevice.Viewport.Height / 2,
                                                GraphicsDevice.Viewport.Width / 2,
                                                GraphicsDevice.Viewport.Height / 2),
                       
                        new Vector2(((GraphicsDevice.Viewport.Width / 4) + (GraphicsDevice.Viewport.Width / 2 * i) - (font.MeasureString(words[i, j]).X / 2)),
                                          (GraphicsDevice.Viewport.Height / 2) + (GraphicsDevice.Viewport.Height / 2 * j) - (font.MeasureString(words[i, j]).Y)),
                        
                        rnd

                        );
                }
            }

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

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    quad[i, j].color();
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    spriteBatch.Draw(background, quad[i, j].GetRec(), quad[i, j].GetClr());
                    spriteBatch.DrawString(font, words[i, j], quad[i, j].GetVec(), quad[j, i].GetClr2());
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
