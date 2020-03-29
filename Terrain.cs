using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarLander
{
    class Terrain
    {
        //Constructor
        public Terrain() {
            points = new List<PointF>();
        }


        public int TotalHeight = 100;
        public int ScreenHeight = 480;
        public int midHeight = 50;
        public int Width = 800;
        const int landingStripWidth = 30;
        public List<PointF> points;

        public void GenerateTerrain()
        {
            Random rnd = new Random();

            float tempHeight = 0;
            //currently has 11 points
            //our terrain is left list of connected dots in random height < 1/2 of screen
            for (int w = 0; w < Width; w += rnd.Next(1, 10))
            {

                double amp = .2;
                double period = 7;
                int currentWave = 0;
                /*
                switch (currentWave)
                {
                    case 0:
                        amp = .2;
                        period = 7;
                        break;
                    case 1:

                        break;
                    case 2:
                        break;

                }*/
                
                tempHeight = Convert.ToSingle(amp * Math.Sin(period * w)+1);
                Console.WriteLine(tempHeight);
                tempHeight += rnd.Next(0, 40);
                points.Add(new PointF(w, tempHeight));
            }

            int landingsCount = rnd.Next(3) + 2;
            for (int i = 0; i < landingsCount; i++)
            //insert landings 
            {
                int idx = rnd.Next(points.Count);
                points.Insert(idx + 1, (new PointF(points[idx].X + landingStripWidth, points[idx].Y)));
            }
            points.Add(new PointF(Width, rnd.Next(TotalHeight)));
            /*
            //"normalize terrain" - lower it to the lowest point
            //find lowest point
            float lowest = points.Min(p => p.Y);
*/
            //decrease each
            for (int i = 0; i < points.Count; i++)
            {
                points[i] = new PointF(points[i].X, ScreenHeight - (points[i].Y));//- lowest));
            }

        }
    }
}
