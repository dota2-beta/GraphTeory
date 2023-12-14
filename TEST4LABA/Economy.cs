namespace TEST4LABA
{
    internal class Economy
    {
        private long _budget;
        private int _vaccine_cost;
        private int _average_salary;
        private PictureBox _defolt_pic;
        public long Budget { get => _budget; set { _budget = value; } }
        public int Vaccine_cost { get => _vaccine_cost; set { _vaccine_cost = value; } }
        public int Average_salary { get => _average_salary; set { _average_salary = value; } }
        public bool defolt;

        public void Check_Defolt()
        {
            if (_budget < 0)
            {
                defolt = true;
                _defolt_pic.Visible = true;
            }
            else
            {
                defolt = false;
                _defolt_pic.Visible = false;
            }
        }
        public void Collect_Taxes(int people)
        {
            this._budget += (long)(0.0009 * this._average_salary * people);
        }
        public void Payments(int infected_people)
        {
            if (this._budget - (long)infected_people * 1500 >= 0)
                this._budget -= (long)infected_people * 1500;
        }
        public Economy(long budget, int vaccine_cost, int average_salary, PictureBox defolt_pic)
        {
            this._budget = budget;
            this._vaccine_cost = vaccine_cost;
            this._average_salary = average_salary;
            this._defolt_pic = defolt_pic;
        }
    }
}
