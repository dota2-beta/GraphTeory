namespace TEST4LABA
{
    internal class Transport : Control
    {
        private Point _point;
        private System.Windows.Forms.Timer _timer;

        private int frames;
        private int vecX;
        private int vecY;
        public Bitmap _bitmap;
        Place placeOut;

        public Transport()
        {
            this._bitmap = Resources.circle;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackgroundImage = _bitmap;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Visible = false;
            this.Width = 30;
            this.Height = 30;
            

            _point = new Point(0, 0);
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 2;
            _timer.Tick += _timer_Tick;

        }
        private int complete = 0;
        private void _timer_Tick(object? sender, EventArgs e)
        {
            if (complete != frames)
            {
                _point.X += vecX;
                _point.Y += vecY;
                this.Location = _point;
                complete++;
            }
            else
            {
                this.Visible = false;
                this.Location = this.placeOut.Location;
                complete = 0;
                _timer.Stop();
            }
        }
        
        public void Car_Move(Place placeOut, Place placeIn, bool infected, int people)
        {
            if (infected)
                this.BackgroundImage = Resources.circle_inf;
            else this.BackgroundImage = Resources.circle;
            this.Visible = true;
            this.Location = placeOut.Location;
            this._point = this.Location;
            this.placeOut = placeOut;

            //_allPlaces[s.To()].Location.X + _allPlaces[s.To()].Width / 2, 
            //_allPlaces[s.To()].Location.Y + _allPlaces[s.To()].Width / 2

            Point placeIn_center = new Point((int)(placeIn.Location.X + placeIn.Width / 2.0 - 30), 
                (int)(placeIn.Location.Y + placeIn.Width / 2.0));
            Point placeOut_center = new Point((int)(placeOut.Location.X + placeOut.Width / 2.0 - 30),
                (int)(placeOut.Location.Y + placeOut.Width / 2.0));

            frames = 30;
            
            //vecX = (placeIn.Location.X - placeOut.Location.X) / frames;
            //vecY = (placeIn.Location.Y - placeOut.Location.Y) / frames;

            vecX = (placeIn.Location.X + placeIn.Width / 2 - placeOut.Location.X - placeOut.Width / 2) / frames;
            vecY = (placeIn.Location.Y + placeIn.Width / 2 - placeOut.Location.Y - placeOut.Width / 2) / frames;

            //vecX = (placeIn_center.X - placeOut_center.X) / frames;
            //vecY = (placeIn_center.Y - placeOut_center.Y) / frames;

            _timer.Start();

            if (infected && (placeIn.Infected + people) < placeIn.Population)
                placeIn.Infected+= people;

        }
    }
}
