namespace TEST4LABA
{
    internal class Place : MyObject
    {
        #region поля
        private PictureBox _pandemicBox;

        private string _name;
        private int _population;
        private int _vaccinated;
        private int _transportSaturation;
        private int _infected;
        private string _type;
        private int _r, _g, _b;
        private bool _pandemic;
        private bool _enabled;

        public int PlaceId;
        public Label label;
        public new string Name { get { return _name; } set { _name = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public int Population
        {
            get { return _population; }
            set
            {
                if (value > 0)
                    _population = value;
            }
        }
        public int Vaccinated { get { return _vaccinated; } set { this._vaccinated = value; } }
        public int TransportSaturation { get { return _transportSaturation; } }
        public int Infected { get { return _infected; } set { this._infected = value; } }
        public int R { get { return _r; } set { _r = value; } }
        public int G { get { return _g; } set { _g = value; } }
        public int B{ get { return _b; } set { _b = value; } }
        public bool Pandemic { get { return _pandemic;  } 
            set {
                _pandemic = value;
                if(_pandemic)
                {
                    this._pandemicBox.Visible = true;
                }
                else
                {
                    this._pandemicBox.Visible = false;
                }
            } 
        }
        public int[] infected_period;
        public new bool Enabled { get { return _enabled; } 
            set {
                _enabled = value;
                if (!_enabled)
                {
                    this.BackColor = Color.Gray;
                    FullInfectedLabel();
                }
            } 
        }
        public int Days;
        #endregion

        public Place(int PlaceId, string Name, int population, int infected, int vaccinated, int transportSaturation, 
            String Type, Point Location, int width, int height, Bitmap icon) : base(Location, Name, width, height)
        {
            this.PlaceId = PlaceId;
            this.Name = Name;
            this._population = population;
            this._vaccinated = vaccinated;
            this._transportSaturation = transportSaturation;
            this._infected = infected;
            this._type = Type;

            this.BackgroundImage = icon;
            this.BackColor = Color.Green;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            _pandemicBox = new PictureBox();
            _pandemicBox.Visible = false;
            _pandemicBox.BackColor = Color.Transparent;
            _pandemicBox.BackgroundImage = Resources.pandemic;
            _pandemicBox.BackgroundImageLayout = ImageLayout.Stretch;

            switch (this.Type) {
                case "Мегаполис":
                    _pandemicBox.Size = new Size(50, 50);
                    _pandemicBox.Location = new Point(50, 0);
                    break;
                case "Город":
                    _pandemicBox.Size = new Size(37, 37);
                    _pandemicBox.Location = new Point(37, 0);
                    break;
                case "Поселок":
                    _pandemicBox.Size = new Size(25, 25);
                    _pandemicBox.Location = new Point(25, 0);
                    break;
                    
        }
            this.Controls.Add(_pandemicBox);//панель в которую заносится 

            this.infected_period = new int[4] {0,0,0,0};
            this.label = new Label();
            this.Enabled = true;
        }

        //функция смены обводки
        public void Outline_ReDraw()
        {
            ColorChange colorChange = new ColorChange();
            colorChange.ColorRedToGreen((int)(1000 - this.Infected * 1.0 / this._population * 1000));
            this.BackColor = Color.FromArgb(colorChange.r, colorChange.g, colorChange.b);

        }
        public void CheckFullInfected()
        {
             this.Enabled = this.Infected < this.Population;
        }
        private void FullInfectedLabel()
        {
            label.Text = Days.ToString() + " д.";
            label.Font = new Font("Impact", 16);
            if (Type == "Город")
                label.ForeColor = Color.GhostWhite;
            else label.ForeColor = Color.Black;
            label.BackColor = Color.Transparent;

            this.Controls.Add(label);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Dock = DockStyle.Fill;
        }
    }
}