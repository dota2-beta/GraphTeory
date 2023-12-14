using System.Drawing.Drawing2D;

namespace TEST4LABA
{

    abstract internal class MyObject : Control
    {
        protected new Point Location;// = new System.Drawing.Point(177, 117);
        protected static string Name;
        protected static int width, height;

        public MyObject(Point Location, string Name, int width, int height) :
            base(Name, Location.X, Location.Y, width, height)
        {
            this.Location = Location;
        }
        public MyObject() { }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) //для того, чтобы сделать пикчу круглой
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(-1, -1, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(grPath);
            base.OnPaint(e);
        }
    }
}
