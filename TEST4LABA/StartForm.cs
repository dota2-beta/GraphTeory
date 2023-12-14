using System.Collections.Specialized;
using System.ComponentModel;
using System.Transactions;

namespace TEST4LABA
{
    public partial class StartForm : Form
    {
        
        public static List<int> listPlaceId;
        public static EdgeWeightedDigraph Graph;
        public static int period;
        public static DateTime modelDate;
        public static int cost_one_vaccine;
        public static long budget;
        public static DataGridView date;
        public static int average_salary;

        private List<double[]> lstAdj;
        private int _townCount;
        public StartForm()
        {
            InitializeComponent();

            _townCount = -1;

        }

        private void ClearDGV()
        {
            for (int i = 0; i < dGV_main.Rows.Count; )
                 this.dGV_main.Rows.Remove(this.dGV_main.Rows[i]);
        }

        private void temp_Load(object sender, EventArgs e)
        {
        }
        private bool Check()
        {
            int population;
            bool state = true;
            bool correct_positive = true;
            bool is_empty = false;
            bool checkdrg = true;
            if (dGV_main.RowCount == 0)
            {
                errorProvider1.SetError(dGV_main, "Таблица пуста");
                is_empty = true;
            }

            for (int i = 0; i < dGV_main.RowCount; ++i)
            {
                for (int j = 2; j <= 5; ++j)
                {
                    if (dGV_main.Rows[i].Cells[j].Value != null)
                    {
                        state = int.TryParse(dGV_main.Rows[i].Cells[j].Value.ToString(), out population);
                        _ = j == 3 ? (correct_positive = population >= 0) : (correct_positive = population > 0);
                    }
                    else state = false;

                    if (!state || !correct_positive) break;
                }
                if (!state || !correct_positive) break;

                int temp;
                int.TryParse(dGV_main.Rows[i].Cells[2].Value.ToString(), out population);
                int.TryParse(dGV_main.Rows[i].Cells[3].Value.ToString(), out temp);
                if (temp > population) dGV_main.Rows[i].Cells[3].Value = population;
                int.TryParse(dGV_main.Rows[i].Cells[4].Value.ToString(), out temp);
                if (temp > population) dGV_main.Rows[i].Cells[4].Value = population;

                int.TryParse(dGV_main.Rows[i].Cells[5].Value.ToString(), out temp);
                if (temp > 100) dGV_main.Rows[i].Cells[5].Value = 100;
            }
            if (!checkdrg)
                errorProvider1.SetError(dGV_main, "Данные введены некорректно");
            if (!state || !correct_positive)
                errorProvider1.SetError(dGV_main, "Данные введены некорректно");
            int number;
            bool state_textbox = int.TryParse(textBox_period.Text, out number);
            if(!state_textbox)
                errorProvider1.SetError(textBox_period, "Данные введены некорректно");
            if(state_textbox)
                if (int.Parse(textBox_period.Text) <= 0)
                {
                    errorProvider1.SetError(textBox_period, "Данные введены некорректно");
                    state_textbox = false;
                }

            bool check_day = int.TryParse(textBox_day.Text, out number);
            if (!check_day)
                errorProvider1.SetError(textBox_day, "Данные введены некорректно");
            if (check_day)
                if (number <= 0 || number > 31)
                {
                    errorProvider1.SetError(textBox_day, "Дата введена неверно");
                    check_day = false;
                }

            bool check_month = int.TryParse(textBox_month.Text, out number);
            if (!check_month)
                errorProvider1.SetError(textBox_month, "Данные введены некорректно");
            if (check_month)
                if (number <= 0 || number > 31)
                {
                    errorProvider1.SetError(textBox_month, "Дата введена неверно");
                    check_month = false;
                }

            bool check_year = int.TryParse(textBox_year.Text, out number);
            if (!check_year)
                errorProvider1.SetError(textBox_year, "Данные введены некорректно");

            bool check_vacc_cost = int.TryParse(textBox_VaccineCost.Text, out number);
            if (!check_vacc_cost)
                errorProvider1.SetError(textBox_VaccineCost, "Данные введены некорректно");
            if (check_vacc_cost)
                if(number <= 0)
                {
                    check_vacc_cost = false;
                    errorProvider1.SetError(textBox_VaccineCost, "Неверная стоимость");
                }

            bool check_salary = int.TryParse(textBox_average_salary.Text, out number);
            if (!check_salary)
                errorProvider1.SetError(textBox_average_salary, "Данные введены некорректно");
            if (check_salary)
                if (number <= 0)
                {
                    check_salary = false;
                    errorProvider1.SetError(textBox_average_salary, "Неверная зарплата");
                }

            long bud;
            bool check_budget = long.TryParse(textBox_budget.Text, out bud);
            if (!check_budget)
                errorProvider1.SetError(textBox_budget, "Данные введены некорректно");  

            return !is_empty && state && correct_positive  && state_textbox && 
                check_day &&  check_month && check_year  && check_vacc_cost && 
                check_salary && check_budget && checkdrg;
        }

        private void Clear()
        {
            errorProvider1.Clear();
        }

        //случайная генерация городов
        private void btn_random_gen_Click(object sender, EventArgs e)
        {
            ClearDGV();
            _townCount = -1;
            List<string> title = new List<string>();
            string[] str = {"Архангельск", "Асбест", "Астрахань", "Ачинск",
                "Балаково", "Балахна", "Балашиха", "Балашов", "Барнаул", "Батайск",
                "Белгород", "Белебей", "Белово", "Белогорск", "Белорецк", "Белореченск", "Бердск", "Березники",
                 "Владивосток,", "Владикавказ", "Владимир", "Волгоград", "Волгодонск", "Волжск", "Волжский",
                "Вологда", "Вольск", "Воркута", "Воронеж", "Москва", "Мурманск", "Саратов", "Санкт-Петербург" };
            for (int i = 0; i < str.Length; ++i)
                title.Add(str[i]);

            Random rnd = new Random();
            for (int i = 0; i < rnd.Next(5, 11); ++i)
            {
                this.dGV_main.Rows.Add(1);
                _townCount++;
                dGV_main.Rows[_townCount].Cells[0].Value = _townCount;

                int place = rnd.Next(0, 3);
                switch (place)
                {
                    case 0:
                        {
                            string temp = title[rnd.Next(0, title.Count - 1)];
                            this.dGV_main.Rows[_townCount].Cells[1].Value = temp;
                            this.dGV_main.Rows[_townCount].Cells[2].Value = rnd.Next(5000000, 20000000);
                            this.dGV_main.Rows[_townCount].Cells[3].Value = 0;
                            this.dGV_main.Rows[_townCount].Cells[4].Value = rnd.Next(3000, 8000);
                            this.dGV_main.Rows[_townCount].Cells[5].Value = rnd.Next(80, 100 + 1);
                            this.dGV_main.Rows[_townCount].Cells[6].Value = "Мегаполис";

                           for (int j = 0; j < title.Count; ++j)
                                if (title[j] == temp)
                                    title.Remove(temp);
                        }
                        break;
                        case 1:
                        {
                            string temp = title[rnd.Next(0, title.Count - 1)];
                            this.dGV_main.Rows[_townCount].Cells[1].Value = temp;
                            this.dGV_main.Rows[_townCount].Cells[2].Value = rnd.Next(75000, 5000000);
                            this.dGV_main.Rows[_townCount].Cells[3].Value = 0;
                            this.dGV_main.Rows[_townCount].Cells[4].Value = rnd.Next(500, 3000);
                            this.dGV_main.Rows[_townCount].Cells[5].Value = (byte)rnd.Next(40, 80);
                            this.dGV_main.Rows[_townCount].Cells[6].Value = "Город";

                            for (int j = 0; j < title.Count; ++j)
                                if (title[j] == temp)
                                    title.Remove(temp);
                        }
                        break;
                    case 2:
                        {
                            string temp = title[rnd.Next(0, title.Count - 1)];
                            this.dGV_main.Rows[_townCount].Cells[1].Value = temp;
                            this.dGV_main.Rows[_townCount].Cells[2].Value = rnd.Next(10000, 75000);
                            this.dGV_main.Rows[_townCount].Cells[3].Value = 0;
                            this.dGV_main.Rows[_townCount].Cells[4].Value = rnd.Next(0, 1000);
                            this.dGV_main.Rows[_townCount].Cells[5].Value = rnd.Next(5, 40);
                            this.dGV_main.Rows[_townCount].Cells[6].Value = "Поселок";

                            for (int j = 0; j < title.Count; ++j)
                                if (title[j] == temp)
                                    title.Remove(temp);
                        }
                        break;
                }
            }

        }

        private void btn_Add_Town(object sender, EventArgs e)
        {
            dGV_main.Rows.Add(1);
            _townCount++;
            dGV_main.Rows[_townCount].Cells[0].Value = _townCount;
        }

        private void btn_Delete_Town(object sender, EventArgs e)
        {
            if (this.dGV_main.RowCount != 0)
            {
                for (int i = this.dGV_main.CurrentRow.Index; i < this.dGV_main.Rows.Count; ++i)
                    this.dGV_main.Rows[i].Cells[0].Value = (int)this.dGV_main.Rows[i].Cells[0].Value - 1;

                this.dGV_main.Rows.Remove(this.dGV_main.Rows[this.dGV_main.CurrentRow.Index]);
                _townCount--;
                
            }
            
        }
       
        private void btn_model_Click(object sender, EventArgs e)
        {
            Clear();
            bool state = Check();
            if (state)
            {
                for (int i = 0; i < this.dGV_main.RowCount; ++i)
                {
                    if (int.Parse(dGV_main.Rows[i].Cells[2].Value.ToString()) > 5000000)
                        dGV_main.Rows[i].Cells[6].Value = "Мегаполис";
                    else if (int.Parse(dGV_main.Rows[i].Cells[2].Value.ToString()) > 75000)
                        dGV_main.Rows[i].Cells[6].Value = "Город";
                    else dGV_main.Rows[i].Cells[6].Value = "Поселок";
                }
                listPlaceId = new List<int>();
                for (int i = 0; i < this.dGV_main.RowCount; ++i)
                    listPlaceId.Add(i);

                lstAdj = new List<double[]>();
                Random rnd = new Random();
                for (int i = 0; i < this.dGV_main.RowCount; ++i)
                {
                    if (dGV_main.Rows[i].Cells[7].Value != null)
                    {
                       string[] str = (dGV_main.Rows[i].Cells[7].Value.ToString()).Split(' ');
                       foreach (var doroga in str)
                           lstAdj.Add(new double[] { i, int.Parse(doroga), 1 + 3 * rnd.NextDouble() });
                       
                    }
                }
                int count = 0;
                foreach (var doroga in lstAdj)
                    count++;

                Graph = new EdgeWeightedDigraph(this.dGV_main.RowCount, count, lstAdj);
                //Console.WriteLine(Graph.ToString());
                
                period = int.Parse(textBox_period.Text);
                try
                {
                    modelDate = new DateTime(int.Parse(textBox_year.Text), int.Parse(textBox_month.Text), int.Parse(textBox_day.Text));
                    cost_one_vaccine = int.Parse(textBox_VaccineCost.Text);
                    budget = long.Parse(textBox_budget.Text);
                    date = this.dGV_main;
                    average_salary = int.Parse(textBox_average_salary.Text);

                    this.Visible = false;
                    new MainForm().ShowDialog();
                    this.Close();
                }
                catch (Exception)
                {
                    errorProvider1.SetError(textBox_year, "Дата введена неверно");
                }
            }
        }
    }
}
