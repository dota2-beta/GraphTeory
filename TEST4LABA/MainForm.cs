using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TEST4LABA
{
    public partial class MainForm : Form
    {
        internal List<Place> _allPlaces;
        private DateTime _date;
        private DateTime _finalDate;
        private DataGridView _DGV;
        private Economy _economy;
        private int country_population;
        private int country_infected;
        private int country_vaccinated;
        private int country_increase_infected;
        private int period_step;
        private int TrackBar_speed;

        private Transport _tr;
        private bool redrawPlaces;

        public MainForm()
        {
            InitializeComponent();

            this.bottom_Info_Panel.BringToFront();

            _tr = new Transport();

            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(-1, -1, pictureBox_Town.Width, pictureBox_Town.Height);
            pictureBox_Town.Region = new Region(grPath);

            _economy = new Economy(StartForm.budget,
                                          StartForm.cost_one_vaccine,
                                          StartForm.average_salary,
                                          pictureBox_defolt);

            _DGV = StartForm.date;
            _date = StartForm.modelDate;

            _finalDate = _date.AddMonths(StartForm.period);

            this.lbl_date_day.Text = _date.Day.ToString();
            this.lbl_date_month.Text = _date.Month.ToString();
            this.lbl_date_year.Text = _date.Year.ToString();

            _allPlaces = new List<Place>();


            int aver_pop_mega = 0, aver_pop_city = 0, aver_pop_vill = 0;
            int m = 0, c = 0, v = 0;
            for (int i = 0; i < _DGV.RowCount; i++)
            {
                string place = _DGV.Rows[i].Cells[6].Value.ToString();
                switch (place)
                {
                    case "Мегаполис":
                        m++;
                        aver_pop_mega += int.Parse(_DGV.Rows[i].Cells[2].Value.ToString());
                        break;
                    case "Город":
                        c++;
                        aver_pop_city += int.Parse(_DGV.Rows[i].Cells[2].Value.ToString());
                        break;
                    case "Поселок":
                        v++;
                        aver_pop_vill += int.Parse(_DGV.Rows[i].Cells[2].Value.ToString());
                        break;

                }

            }
            if (m != 0) aver_pop_mega /= m;
            if (c != 0) aver_pop_city /= c;
            if (v != 0) aver_pop_vill /= v;
            Random rnd = new Random();
            for (int i = 0; i < _DGV.RowCount; ++i)
            {
                string place = _DGV.Rows[i].Cells[6].Value.ToString();
                switch (place)
                {
                    case "Мегаполис":
                        {
                            int imageSize = 155 + int.Parse(_DGV.Rows[i].Cells[2].Value.ToString()) / aver_pop_mega;
                            Place pls;
                            Point location;
                            bool equal;
                            do
                            {
                                equal = false;

                                pls = new Place(StartForm.listPlaceId[i],
                                    _DGV.Rows[i].Cells[1].Value.ToString(),
                                    int.Parse(_DGV.Rows[i].Cells[2].Value.ToString()),
                                    int.Parse(_DGV.Rows[i].Cells[3].Value.ToString()),
                                    int.Parse(_DGV.Rows[i].Cells[4].Value.ToString()),
                                    int.Parse(_DGV.Rows[i].Cells[5].Value.ToString()),
                                    _DGV.Rows[i].Cells[6].Value.ToString(),
                                    new Point(rnd.Next(0, MainPanel.Width - 100), rnd.Next(0, MainPanel.Height - 100)),
                                    imageSize, imageSize,
                                    Resources.megapolis);

                                for (int k = 0; k < _allPlaces.Count; k++)
                                    if (pls.Bounds.IntersectsWith(_allPlaces[k].Bounds))
                                        //pls.Bounds.IntersectsWith(panel_date.Bounds) ||
                                        //pls.Bounds.IntersectsWith(progressBar_date.Bounds) ||
                                        //pls.Bounds.IntersectsWith(button_speedDown.Bounds) ||
                                        //pls.Bounds.IntersectsWith(button_2speedDown.Bounds) ||
                                        //pls.Bounds.IntersectsWith(button_default.Bounds) ||
                                        //pls.Bounds.IntersectsWith(button_speedUp.Bounds) ||
                                        //pls.Bounds.IntersectsWith(button_2speedUp.Bounds))
                                    {
                                        equal = true;
                                        break;
                                    }
                                if (pls.Bounds.IntersectsWith(top_info_panel.Bounds))
                                    equal = true;

                            } while (equal);

                            MainPanel.Controls.Add(pls);
                            _allPlaces.Add(pls);
                        }
                        break;
                    case "Город":
                        {
                            int imageSize = 115 + int.Parse(_DGV.Rows[i].Cells[2].Value.ToString()) / aver_pop_city;
                            Place pls;
                            Point location;

                            bool equal;

                            do
                            {
                                equal = false;
                                pls = new Place(StartForm.listPlaceId[i],
                                    _DGV.Rows[i].Cells[1].Value.ToString(),
                                    int.Parse(_DGV.Rows[i].Cells[2].Value.ToString()),
                                    int.Parse(_DGV.Rows[i].Cells[3].Value.ToString()),
                                    int.Parse(_DGV.Rows[i].Cells[4].Value.ToString()),
                                    int.Parse(_DGV.Rows[i].Cells[5].Value.ToString()),
                                    _DGV.Rows[i].Cells[6].Value.ToString(),
                                    new Point(rnd.Next(0, MainPanel.Width - 100), rnd.Next(0, MainPanel.Height - 100)),
                                    imageSize, imageSize,
                                    Resources.city);

                                for (int k = 0; k < _allPlaces.Count; k++)
                                    if (pls.Bounds.IntersectsWith(_allPlaces[k].Bounds))
                                    //pls.Bounds.IntersectsWith(panel_date.Bounds) ||
                                    //pls.Bounds.IntersectsWith(progressBar_date.Bounds) ||
                                    //pls.Bounds.IntersectsWith(button_speedDown.Bounds) ||
                                    //pls.Bounds.IntersectsWith(button_2speedDown.Bounds) ||
                                    //pls.Bounds.IntersectsWith(button_default.Bounds) ||
                                    //pls.Bounds.IntersectsWith(button_speedUp.Bounds) ||
                                    //pls.Bounds.IntersectsWith(button_2speedUp.Bounds))
                                    {
                                        equal = true;
                                        break;
                                    }
                                if (pls.Bounds.IntersectsWith(top_info_panel.Bounds))
                                    equal = true;
                            } while (equal);

                            MainPanel.Controls.Add(pls);
                            _allPlaces.Add(pls);
                        }
                        break;
                    case "Поселок":
                        {
                            int imageSize = 75 + int.Parse(_DGV.Rows[i].Cells[2].Value.ToString()) / aver_pop_vill;

                            Place pls;
                            Point location;
                            bool equal;
                            do
                            {
                                equal = false;
                                pls = new Place(StartForm.listPlaceId[i],
                                    _DGV.Rows[i].Cells[1].Value.ToString(),
                                    int.Parse(_DGV.Rows[i].Cells[2].Value.ToString()),
                                    int.Parse(_DGV.Rows[i].Cells[3].Value.ToString()),
                                    int.Parse(_DGV.Rows[i].Cells[4].Value.ToString()),
                                    int.Parse(_DGV.Rows[i].Cells[5].Value.ToString()),
                                    _DGV.Rows[i].Cells[6].Value.ToString(),
                                    new Point(rnd.Next(0, MainPanel.Width - 100), rnd.Next(0, MainPanel.Height - 100)),
                                    imageSize, imageSize,
                                    Resources.village);

                                for (int k = 0; k < _allPlaces.Count; k++)
                                    if (pls.Bounds.IntersectsWith(_allPlaces[k].Bounds))
                                    //pls.Bounds.IntersectsWith(panel_date.Bounds) ||
                                    //pls.Bounds.IntersectsWith(progressBar_date.Bounds) ||
                                    //pls.Bounds.IntersectsWith(button_speedDown.Bounds) ||
                                    //pls.Bounds.IntersectsWith(button_2speedDown.Bounds) ||
                                    //pls.Bounds.IntersectsWith(button_default.Bounds) ||
                                    //pls.Bounds.IntersectsWith(button_speedUp.Bounds) ||
                                    //pls.Bounds.IntersectsWith(button_2speedUp.Bounds))
                                    {
                                        equal = true;
                                        break;
                                    }
                                if (pls.Bounds.IntersectsWith(top_info_panel.Bounds))
                                    equal = true;
                            } while (equal);

                            MainPanel.Controls.Add(pls);
                            _allPlaces.Add(pls);
                        }
                        break;
                }
            }

            for (int k = 0; k < _allPlaces.Count; k++)
            {
                _allPlaces[k].Click += Place_Click;
                _allPlaces[k].label.Click += Label_Click;
            }

            //foreach (var somePlace in StartForm.listPlaceId)

            int population = 0, infected = 0, vaccinated = 0;
            for (int i = 0; i < _allPlaces.Count; ++i)
            {
                population += _allPlaces[i].Population;
                infected += _allPlaces[i].Infected;
                vaccinated += _allPlaces[i].Vaccinated;
            }

            MainPanel.Controls.Add(_tr);

            TrackBar_speed = 0;
            period_step = -1;
            country_increase_infected = 0;

            country_population = population;
            country_infected = infected;
            country_vaccinated = vaccinated;

            lbl_country_population.Text = population.ToString();
            lbl_country_infected.Text = infected.ToString();
            lbl_country_vaccinated.Text = vaccinated.ToString();
            lbl_country_towns.Text = _allPlaces.Count.ToString();

            redrawPlaces = true;
            model_step();

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint, true);
            UpdateStyles();

        }


        private void Label_Click(object? sender, EventArgs e)
        {
            panel_Info_Town.Visible = true;
            panel_Info_Country.Visible = false;

            pictureBox_Town.BackgroundImage = ((sender as Label).Parent as Place).BackgroundImage;
            pictureBox_Town.BackgroundImageLayout = ImageLayout.Zoom;

            lbl_town_name.Text = ((sender as Label).Parent as Place).Name;
            lbl_town_population.Text = ((sender as Label).Parent as Place).Population.ToString();
            lbl_town_infected.Text = ((sender as Label).Parent as Place).Infected.ToString();
            lbl_town_vaccinated.Text = ((sender as Label).Parent as Place).Vaccinated.ToString();
            lbl_town_transport.Text = ((sender as Label).Parent as Place).TransportSaturation.ToString();

            this.lbl_vaccine.Text = (int.Parse(lbl_town_population.Text) / trackBar_vaccine.Maximum / 2 * trackBar_vaccine.Value).ToString();

            if (((sender as Label).Parent as Place).Infected > ((sender as Label).Parent as Place).Population * 0.45)
                pictureBox_town_pandemic.Visible = true;
            else pictureBox_town_pandemic.Visible = false;
        }

        //обновление кадров
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var j in _allPlaces)
            {
                if (j.Enabled)
                {
                    if (redrawPlaces) j.Outline_ReDraw();
                    if (this.pictureBox_Town.BackgroundImage == j.BackgroundImage)
                        this.pictureBox_Town.BackColor = j.BackColor;
                }
                else
                if (this.pictureBox_Town.BackgroundImage == j.BackgroundImage)
                    this.pictureBox_Town.BackColor = j.BackColor;
            }
        }


        //вывод информации о городе
        private void Place_Click(object sender, EventArgs e)
        {
            panel_Info_Town.Visible = true;
            panel_Info_Country.Visible = false;


            pictureBox_Town.BackgroundImage = (sender as Place).BackgroundImage;
            pictureBox_Town.BackgroundImageLayout = ImageLayout.Zoom;

            lbl_town_name.Text = (sender as Place).Name;
            lbl_town_population.Text = (sender as Place).Population.ToString();
            lbl_town_infected.Text = (sender as Place).Infected.ToString();
            lbl_town_vaccinated.Text = (sender as Place).Vaccinated.ToString();
            lbl_town_transport.Text = (sender as Place).TransportSaturation.ToString();
            lbl_id.Text = (sender as Place).PlaceId.ToString();
            this.lbl_vaccine.Text = Math.Round((int.Parse(lbl_town_population.Text) * 1.0 / trackBar_vaccine.Maximum / 2 * trackBar_vaccine.Value * _economy.Vaccine_cost / 1000000), 2).ToString() + "KK";

            if ((sender as Place).Infected > (sender as Place).Population * 0.45)
                pictureBox_town_pandemic.Visible = true;
            else pictureBox_town_pandemic.Visible = false;
        }

        //вывод информации о стране
        private void MainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            panel_Info_Town.Visible = false;
            panel_Info_Country.Visible = true;

            pictureBox_Earth.BackgroundImage = Resources.earth;
            pictureBox_Earth.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private async void model_step()
        {
            while (_date < _finalDate)
            {
                if (_allPlaces.Count > 1)
                {
                    Random rnd = new Random();
                    if (rnd.Next(0, 100) <= 90)
                        Go_Car();
                }
                period_step++;
                progressBar_date.Value = 0;
                int speed = TrackBar_speed;
                for (int i = 1; i < (100 - speed); ++i)
                {
                    progressBar_date.Value = i * 500 / (100 - speed);
                    await Task.Delay(1);
                }

                _date = _date.AddDays(7);
                this.lbl_date_day.Text = _date.Day.ToString();
                this.lbl_date_month.Text = _date.Month.ToString();
                this.lbl_date_year.Text = _date.Year.ToString();

                disease_course();

                lbl_country_infected.Text = country_infected.ToString() + " (" + country_increase_infected.ToString() + ")";
                lbl_country_vaccinated.Text = country_vaccinated.ToString();
                lbl_country_population.Text = country_population.ToString();

                country_increase_infected = 0;

                if (country_infected >= country_population * 0.45)
                    this.pictureBox_country_pandemic.Visible = true;
                else this.pictureBox_country_pandemic.Visible = false;

                if (_date.Day >= 20 && _date.Day < 27)
                    budget_changes();

                _economy.Check_Defolt();

                if (_economy.Budget < 1000000)
                    lbl_money.Text = Math.Round((_economy.Budget * 1.0 / 1000), 2).ToString() + "K";
                else lbl_money.Text = Math.Round((_economy.Budget * 1.0 / 1000000), 2).ToString() + "KK";

            }
            lbl_end.Visible = true;
        }

        private void button_vaccine_Click(object sender, EventArgs e)
        {
            foreach (var j in _allPlaces)
                if (j.Name == this.lbl_town_name.Text)
                    //если денег хватает, то вакцинируем
                    if ((_economy.Budget >= (j.Population * 1.0 / trackBar_vaccine.Maximum / 2 * trackBar_vaccine.Value * _economy.Vaccine_cost / 2))/*_economy.Budget >= 0*/ && j.Enabled)
                        if (j.Population / trackBar_vaccine.Maximum / 2 * trackBar_vaccine.Value + j.Vaccinated <= j.Population)
                        {
                            j.Vaccinated += j.Population / trackBar_vaccine.Maximum / 2 * trackBar_vaccine.Value;
                            lbl_town_vaccinated.Text = j.Vaccinated.ToString();

                            //_economy.Vaccination(j.Population / trackBar_vaccine.Maximum / 2 * trackBar_vaccine.Value);
                            _economy.Budget -= (long)(j.Population * 1.0 / trackBar_vaccine.Maximum / 2 * trackBar_vaccine.Value * _economy.Vaccine_cost);
                            break;
                        }
                        else
                        {
                            //_economy.Vaccination(j.Population - j.Vaccinated);
                            _economy.Budget -= (j.Population - j.Vaccinated) * _economy.Vaccine_cost;

                            j.Vaccinated = j.Population;
                            lbl_town_vaccinated.Text = j.Population.ToString();
                            break;
                        }
        }

        private void trackBar_vaccine_Scroll(object sender, EventArgs e)
        {
            if (int.Parse(lbl_town_population.Text) * 1.0 / trackBar_vaccine.Maximum / 2 * trackBar_vaccine.Value * _economy.Vaccine_cost < 1000000)
                this.lbl_vaccine.Text = Math.Round(((int.Parse(lbl_town_population.Text) * 1.0 / trackBar_vaccine.Maximum / 2 * trackBar_vaccine.Value) / 1000 * _economy.Vaccine_cost), 2).ToString() + "K";
            else this.lbl_vaccine.Text = Math.Round((int.Parse(lbl_town_population.Text) * 1.0 / trackBar_vaccine.Maximum / 2 * trackBar_vaccine.Value / 1000000 * _economy.Vaccine_cost), 2).ToString() + "KK";

            var normilizedMaximum = trackBar_vaccine.Maximum - trackBar_vaccine.Minimum; // рассчитываем нормализованный максимум (тоесть при минимуме равном нулю)
            var normilizedValue = trackBar_vaccine.Value - trackBar_vaccine.Minimum; // рассчитываем нормализованное значение (тоесть при минимуме равном нулю)
            var percents = (float)normilizedValue * 100 / normilizedMaximum; // расчитываем процент продвижения ползунка трекбара
            var newX = percents / 100 * (red_cursor_country.Parent.Width - red_cursor_country.Width - 5); // расчитываем новый X стрелочки

            red_cursor_place.Location = new Point((int)newX, red_cursor_place.Location.Y);
            red_cursor_place.Parent.Refresh();

            ColorChange colorChange = new ColorChange();
            colorChange.ColorRedToGreen((int)(1000 - trackBar_vaccine.Value * 1.0 / trackBar_vaccine.Maximum * 1000));
            panel_trackbar_place.BackColor = Color.FromArgb(colorChange.r, colorChange.g, colorChange.b);

        }

        private void disease_course()
        {
            switch (_date.Month)
            {
                case 1:
                    lbl_season.Text = "Январь";
                    break;
                case 2:
                    lbl_season.Text = "Февраль";
                    break;
                case 3:
                    lbl_season.Text = "Март";
                    break;
                case 4:
                    lbl_season.Text = "Апрель";
                    break;
                case 5:
                    lbl_season.Text = "Май";
                    break;
                case 6:
                    lbl_season.Text = "Июнь";
                    break;
                case 7:
                    lbl_season.Text = "Июль";
                    break;
                case 8:
                    lbl_season.Text = "Август";
                    break;
                case 9:
                    lbl_season.Text = "Сентябрь";
                    break;
                case 10:
                    lbl_season.Text = "Октябрь";
                    break;
                case 11:
                    lbl_season.Text = "Ноябрь";
                    break;
                case 12:
                    lbl_season.Text = "Декабрь";
                    break;
            }


            foreach (var item in _allPlaces)
            {
                if (item.Enabled)
                {
                    float type = -1;
                    switch (item.Type)
                    {
                        case "Поселок":
                            type = 2.65f;
                            break;
                        case "Город":
                            type = 2f;
                            break;
                        case "Мегаполис":
                            type = 1.35f;
                            break;
                    }

                    float defolt = 1f;
                    if (_economy.defolt) defolt = 2f;

                    double season_function = Math.Sin(_date.Month - 3 / 2 + Math.PI);
                    float delta = (int)Math.Ceiling(defolt * item.TransportSaturation / 100f * (1 / 2 * season_function + 0.5) * item.Infected * type * (1 - item.Vaccinated * 1.0 / item.Population));

                    int k = period_step % 4;
                    int increase_infected = (int)(delta);

                    //"выздоровление"
                    switch (k)
                    {
                        case 0:
                            item.infected_period[0] = (int)delta;
                            increase_infected = increase_infected - (int)(item.infected_period[1] * 0.15) - (int)(item.infected_period[2] * 0.6) - (int)(item.infected_period[3] * 0.25);
                            break;
                        case 1:
                            item.infected_period[1] = (int)delta;
                            increase_infected = increase_infected - (int)(item.infected_period[0] * 0.25) - (int)(item.infected_period[2] * 0.15) - (int)(item.infected_period[3] * 0.6);
                            break;
                        case 2:
                            item.infected_period[2] = (int)delta;
                            increase_infected = increase_infected - (int)(item.infected_period[0] * 0.6) - (int)(item.infected_period[1] * 0.25) - (int)(item.infected_period[3] * 0.15);
                            break;
                        case 3:
                            item.infected_period[3] = (int)delta;
                            increase_infected = increase_infected - (int)(item.infected_period[0] * 0.15) - (int)(item.infected_period[1] * 0.6) - (int)(item.infected_period[2] * 0.25);
                            break;
                    }

                    if (item.Infected + increase_infected <= item.Population)
                    {
                        item.Infected += increase_infected;
                        if (item.Infected < 0)
                        {
                            item.Infected = 0;
                            increase_infected = 0;
                        }
                        country_increase_infected += increase_infected;
                        country_infected += increase_infected;

                    }
                    else
                    {
                        item.Infected = item.Population;
                        increase_infected = 0;
                    }

                    if (this.lbl_town_name.Text == item.Name)
                        lbl_town_infected.Text = item.Infected.ToString() + " (" + increase_infected.ToString() + ")";

                    if (item.Infected >= item.Population * 0.45)
                    {
                        item.Pandemic = true;
                        if (this.lbl_town_name.Text == item.Name)
                            pictureBox_town_pandemic.Visible = true;
                    }
                    else
                    {
                        item.Pandemic = false;
                        if (this.lbl_town_name.Text == item.Name)
                            pictureBox_town_pandemic.Visible = false;
                    }

                    item.Days += 7;
                    item.CheckFullInfected();

                }
            }
        }

        private void Go_Car()
        {
            Random rand = new Random();
            int i = rand.Next(0, _allPlaces.Count);
            int j = i;
            int k = rand.Next(0, StartForm.Graph.adj[i].Count);
            if (StartForm.Graph.adj[i].Count != 0)
            {
                j = StartForm.Graph.adj[i][k].To();

                int n = rand.Next(0, 100);
                bool infect = n < (int)(_allPlaces[i].Infected * 1.0 / _allPlaces[i].Population * 100);
                double coeff = StartForm.Graph.adj[i][k].GetWeight();
                _tr.Car_Move(_allPlaces[i]
                            , _allPlaces[j]
                            , infect
                            , (int) (_allPlaces[StartForm.Graph.adj[i][k].From()].Infected
                                    / _allPlaces[StartForm.Graph.adj[i][k].From()].Population
                                    * coeff * 1000) + 1
                            );
            }
        }
        private void budget_changes()
        {
            foreach (var j in _allPlaces)
                if (!j.Pandemic && j.Enabled)
                {
                    _economy.Collect_Taxes((int)(j.Population * 0.65 * (1 - j.Infected * 1.0 / j.Population)));
                    if (!_economy.defolt) _economy.Payments(j.Infected);
                }
        }

        private void trackBar_vaccine_country_Scroll(object sender, EventArgs e)
        {
            if ((country_population * 1.0 / trackBar_vaccine_country.Maximum / 2 * trackBar_vaccine_country.Value) * _economy.Vaccine_cost < 1000000)
                this.lbl_vaccine_country.Text = Math.Round(((country_population * 1.0 / trackBar_vaccine_country.Maximum / 2 * trackBar_vaccine_country.Value) / 1000 * _economy.Vaccine_cost), 2).ToString() + "K";
            else this.lbl_vaccine_country.Text = Math.Round(((country_population * 1.0 / trackBar_vaccine_country.Maximum / 2 * trackBar_vaccine_country.Value) / 1000000 * _economy.Vaccine_cost), 2).ToString() + "KK";

            var normilizedMaximum = trackBar_vaccine_country.Maximum - trackBar_vaccine_country.Minimum; // рассчитываем нормализованный максимум (тоесть при минимуме равном нулю)
            var normilizedValue = trackBar_vaccine_country.Value - trackBar_vaccine_country.Minimum; // рассчитываем нормализованное значение (тоесть при минимуме равном нулю)
            var percents = (float)normilizedValue * 100 / normilizedMaximum; // расчитываем процент продвижения ползунка трекбара
            var newX = percents / 100 * (red_cursor_country.Parent.Width - red_cursor_country.Width - 5); // расчитываем новый X стрелочки

            red_cursor_country.Location = new Point((int)newX, red_cursor_country.Location.Y);
            red_cursor_country.Parent.Refresh();

            ColorChange colorChange = new ColorChange();
            colorChange.ColorRedToGreen((int)(1000 - trackBar_vaccine_country.Value * 1.0 / trackBar_vaccine_country.Maximum * 1000));
            panel_trackbar_country.BackColor = Color.FromArgb(colorChange.r, colorChange.g, colorChange.b);

        }

        private void button_country_vaccinated_Click(object sender, EventArgs e)
        {
            double percent = (country_population * 1.0 / trackBar_vaccine_country.Maximum / 2 * trackBar_vaccine_country.Value) * 1.0 / country_population;
            if (_economy.Budget >= country_population * percent * _economy.Vaccine_cost * 1.0 / 2 /*_economy.Budget >= 0*/ &&
                country_population > country_vaccinated)
                foreach (var j in _allPlaces)
                    if (j.Infected < j.Population && j.Enabled)
                    {
                        if (j.Population * percent + j.Vaccinated <= j.Population)
                            j.Vaccinated += (int)(j.Population * percent);
                        else
                            j.Vaccinated = j.Population;

                        country_vaccinated += (int)(j.Population * percent);
                        _economy.Budget -= (long)(j.Population * percent * _economy.Vaccine_cost);
                    }

        }


        private void button_speedUp_Click(object sender, EventArgs e)
        {
            TrackBar_speed = 50;
        }

        private void button_2speedUp_Click(object sender, EventArgs e)
        {
            TrackBar_speed = 70;
        }

        private void button_speedDown_Click(object sender, EventArgs e)
        {
            TrackBar_speed = -50;
        }

        private void button_2speedDown_Click(object sender, EventArgs e)
        {
            TrackBar_speed = -70;
        }

        private void button_default_Click(object sender, EventArgs e)
        {
            TrackBar_speed = 0;
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
               for (int k = 0; k < _allPlaces.Count; k++)
                  foreach (var s in StartForm.Graph.adj[k])
                  {
                      g.DrawLine ( new Pen(Color.Orange, 4)
                                 , new Point(_allPlaces[k].Location.X + _allPlaces[k].Width / 2, _allPlaces[k].Location.Y + _allPlaces[k].Width / 2)
                                 , new Point(_allPlaces[s.To()].Location.X + _allPlaces[s.To()].Width / 2, _allPlaces[s.To()].Location.Y + _allPlaces[s.To()].Width / 2)
                        );
                  }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            List<int> used = new List<int>();
            List<int> path = new List<int>();
            for (int i = 0; i < StartForm.Graph.V; ++i)
                used.Add(0);
            used[0] = int.MaxValue;
            int count = 0;

            bool check = false;
            while (!check)
            {
                path.Clear();
                for (int i = 1; i < StartForm.Graph.V; ++i)
                    if (used[i] == 0)
                    {
                        StartForm.Graph.DFS(i, used, path);
                        break;
                    }

                bool infect = false;
                for (int i = 0; i < path.Count; ++i)
                    if (_allPlaces[path[i]].Infected != 0)
                    {
                        infect = true;
                        break;
                    }
                if (infect)
                {
                    redrawPlaces = false;
                    for (int i = 0; i < path.Count; ++i)
                    {
                        _allPlaces[path[i]].BackColor = Color.Red;
                    }
                    await Task.Delay(1000);
                    redrawPlaces = true;
                }
                count++;
                bool f = false;
                for (int i = 1; i < StartForm.Graph.V; ++i)
                    if (used[i] == 0)
                    {
                        f = true;
                        break;
                    }
                if (!f) check = true;
                
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            foreach (var j in _allPlaces)
                if (j.PlaceId == int.Parse(this.lbl_id.Text))
                {
                    int n = j.PlaceId;
                    List<int> path = new List<int>();
                    path = StartForm.Graph.BFS(n);

                    List<int> notPath = new List<int>();
                    redrawPlaces = false;
                    for (int i = 0; i < _allPlaces.Count; ++i)
                    {
                        if (!path.Exists(item => item == i))
                        {
                            _allPlaces[i].BackColor = Color.DarkGoldenrod;
                        }
                    }
                    await Task.Delay(1000);
                    redrawPlaces = true;
                }
        }
    }
}