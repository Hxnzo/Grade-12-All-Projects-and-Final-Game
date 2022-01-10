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

namespace PopArtLab
{
    class Rectangles
    {
        //fields
        private int xVal;
        private int yVal;

        private byte redIntensity;
        private byte greenIntensity;
        private byte blueIntensity;

        bool redCountingUp = true;
        bool greenCountingUp = true;
        bool blueCountingUp = true;

        private Random rnd;
        private Rectangle rec;
        private Color clr;
        private Color clr2;
        private Vector2 vec;
        //private ContentManager con;

        //setter(mutator) and getters

        public Rectangle GetRec()
        {
            return rec;
        }

        public void SetRec(Rectangle aRec)
        {
            rec = aRec;
        }

        public Color GetClr()
        {
            return clr;
        }

        public void SetClr(Color aClr)
        {
            clr = aClr;
        }

        public Color GetClr2()
        {
            return clr2;
        }

        public void SetClr2(Color aClr2)
        {
            clr2 = aClr2;
        }

        public Vector2 GetVec()
        {
            return vec;
        }

        public void SetVec(Vector2 aVec)
        {
            vec = aVec;
        }

        public int GetXVal()
        {
            return xVal;
        }

        public void SetXVal(int aXVal)
        {
            xVal = aXVal;
        }

        public int GetYVal()
        {
            return yVal;
        }

        public void SetYVal(int aYVal)
        {
            yVal = aYVal;
        }

        //public void SetCon(ContentManager aCon)
        //{
        //    con = aCon;
        //}
        //public ContentManager GetCon()
        //{
        //    return con;
        //}

        //constructors
        public Rectangles(int someXVal, int someYVal, Rectangle someRec, Vector2 someVec, Random aRnd)
        {           
            SetRec(someRec);
            SetVec(someVec);
            SetXVal(someXVal);
            SetYVal(someYVal);
            rnd = aRnd;

            redIntensity = Convert.ToByte(rnd.Next(256));
            greenIntensity = Convert.ToByte(rnd.Next(256));
            blueIntensity = Convert.ToByte(rnd.Next(256));

            color();
        }

        public void color()
        {
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


            redIntensity+=2;
            greenIntensity++;
            blueIntensity++;

            clr = new Color(redIntensity, greenIntensity, blueIntensity);

            clr2 = new Color(0, 0, 0);
        }
    }
}
