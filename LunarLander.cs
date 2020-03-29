using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;


/*
 * This class holds the first layer to the game. It creates an instance of game and holds the event listeners
 * for the keys the users might press
 */

namespace LunarLander
{
    public partial class LunarLander : Form
    {
        public LunarLander()
        {
            InitializeComponent();
        }

        //Creates an instance of the game class
        Game game = new Game();
        
        /*
         * KeyDown has to be registered in a hash set so that multiple keys can be read at once
         * 
         */
        private void keyDown(object sender, KeyEventArgs e)
        {
            //Listens to escape key (Layer 1)
            if (e.KeyData == Keys.Escape)
            {
                //Creates a new instance of the game class which will restart the game and create new terrain
                game = new Game();
            }
            //Registers keys to hash set in game class
            game.KeyDown(e);
        }

        /*
         * The key up method will remove the keys from the hash set
         */
        private void keyUp(object sender, KeyEventArgs e)
        {
            game.KeyUp(e);
        }
        /*
         * The timer method will execute repeatedly 
         * This update will update the sprite and current status of the game (Pause or not paused)
         */
        private void timer(object sender, EventArgs e)
        {
            //updates the sprites location and rotation, current status of the game.....
            game.Update(new TimeSpan(updateTimer.Interval * 10000));
            //Displays and applys all the updated information to the screen
            gameScreen.Image = game.Draw();
        }
        


        /*
        HashSet<GameKeys> keys = new HashSet<GameKeys>();
        private void keyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    keys.Add(GameKeys.Left);
                    break;
                case Keys.Right:
                    keys.Add(GameKeys.Right);
                    break;
                case Keys.Up:
                    keys.Add(GameKeys.Up);
                    break; 
                case Keys.Down:
                    keys.Add(GameKeys.Down);
                    break;
                case Keys.Space:
                    keys.Add(GameKeys.Space);
                    break;
            }
        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    keys.Remove(GameKeys.Left);
                    break;
                case Keys.Right:
                    keys.Remove(GameKeys.Right);
                    break;
                case Keys.Up:
                    keys.Remove(GameKeys.Up);
                    break;
                case Keys.Down:
                    keys.Remove(GameKeys.Down);
                    break;
                case Keys.Space:
                    keys.Remove(GameKeys.Space);
                    break;
            }

        }
        private void timer(object sender, EventArgs e)
        {
            updateImage(new TimeSpan(updateTimer.Interval * 10000));
        }

        int X = 200;
        int Y = 100;
        Bitmap bmp = new Bitmap(640, 480);
        private static String imageName = "tile002";
        public Bitmap sprite = (Bitmap)Properties.Resources.ResourceManager.GetObject(imageName);
        int z = 0;

        private void updateImage(TimeSpan ts)
        {
            Y += 3;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Black);

                Matrix m = new Matrix();

                if (keys.Contains(GameKeys.Left) && (keys.Contains(GameKeys.Up)))
                {
                    X -= 5;
                    Y -= 5;
                    z+=20;
                    m.RotateAt((z), new PointF(X, Y));
                    Console.WriteLine("HERE");
                }
                else if (keys.Contains(GameKeys.Right) && (keys.Contains(GameKeys.Up)))
                {
                    X += 5;
                    Y -= 5;
                }
                else if (keys.Contains(GameKeys.Up))
                {
                    Y -= 5;
                }
                else if (keys.Contains(GameKeys.Down))
                {
                    Y += 5;
                }
                else if (keys.Contains(GameKeys.Left))
                {
                    X -= 5;
                }
                else if (keys.Contains(GameKeys.Right))
                {
                    X += 5;
                }
                
                g.Transform = m;
                g.DrawImage(sprite, new PointF(X, Y));
                m.Reset();
                g.Transform = m;

            }
            pictureBox1.Image = bmp;
        }*/
    }
}
