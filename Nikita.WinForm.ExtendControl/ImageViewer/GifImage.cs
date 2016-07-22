using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Timers;

namespace Nikita.WinForm.ExtendControl
{
    public class GifImage : IDisposable
    {
        private bool animationEnabled = true;
        private int currentFrame = 0;
        private Bitmap currentFrameBmp = null;
        private Size currentFrameSize = new Size();
        private FrameDimension dimension;
        private int frameCount;
        private double framesPerSecond = 0;
        private Image gif;
        private KpImageViewer KpViewer;
        private int rotation = 0;
        private Timer timer = null;
        private bool updating = false;

        public GifImage(KpImageViewer KpViewer, Image img, bool animation, double fps)
        {
            this.updating = true;
            this.KpViewer = KpViewer;
            this.gif = img;
            this.dimension = new FrameDimension(gif.FrameDimensionsList[0]);
            this.frameCount = gif.GetFrameCount(dimension);
            this.gif.SelectActiveFrame(dimension, 0);
            this.currentFrame = 0;
            this.animationEnabled = animation;

            this.timer = new Timer();

            this.updating = false;

            framesPerSecond = 1000.0 / fps; // 15 FPS
            this.timer.Enabled = this.animationEnabled;
            this.timer.Interval = framesPerSecond;
            this.timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);

            this.currentFrameBmp = (Bitmap)gif;
            this.currentFrameSize = new Size(currentFrameBmp.Size.Width, currentFrameBmp.Size.Height);
        }

        public bool AnimationEnabled
        {
            get { return animationEnabled; }
            set
            {
                animationEnabled = value;

                if (timer != null)
                {
                    timer.Enabled = animationEnabled;
                }
            }
        }

        public Bitmap CurrentFrame
        {
            get
            {
                return currentFrameBmp;
            }
        }

        public Size CurrentFrameSize
        {
            get
            {
                return currentFrameSize;
            }
        }

        public double FPS
        {
            get { return (1000.0 / framesPerSecond); }
            set
            {
                if (value <= 30.0 && value > 0.0)
                {
                    framesPerSecond = 1000.0 / value;

                    if (timer != null)
                    {
                        timer.Interval = framesPerSecond;
                    }
                }
            }
        }

        public int FrameCount
        {
            get { return frameCount; }
        }

        public int Rotation
        {
            get { return rotation; }
        }

        public void Dispose()
        {
            Lock();
            timer.Enabled = false;
            gif.Dispose();
            gif = null;
            Unlock();

            timer.Dispose();
        }

        public bool Lock()
        {
            if (updating == false)
            {
                while (updating)
                {
                    // Wait
                }

                return true;
            }

            return false;
        }

        public void NextFrame()
        {
            try
            {
                if (gif != null)
                {
                    if (Lock())
                    {
                        lock (gif)
                        {
                            gif.SelectActiveFrame(this.dimension, this.currentFrame);
                            currentFrame++;

                            if (currentFrame >= this.frameCount)
                            {
                                currentFrame = 0;
                            }

                            OnFrameChanged();
                        }
                    }

                    Unlock();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        public void Rotate(int rotation)
        {
            this.rotation = (this.rotation + rotation) % 360;
        }

        public void Unlock()
        {
            updating = false;
        }

        private void OnFrameChanged()
        {
            this.currentFrameBmp = (Bitmap)gif;
            this.currentFrameSize = new Size(currentFrameBmp.Size.Width, currentFrameBmp.Size.Height);

            this.KpViewer.InvalidatePanel();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            NextFrame();
        }
    }
}