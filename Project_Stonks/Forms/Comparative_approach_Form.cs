using Project_Stongs.Function;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Project_Stongs.Forms
{

    public partial class Comparative_approach_Form : Form
    {

        private Form _form1;

        public decimal[] capitalize = new decimal[3];
        public decimal[] pe = new decimal[3];
        public decimal[] ps = new decimal[3];
        public decimal[] pb = new decimal[3];
        public decimal[] assessment_pe = new decimal[3];
        public decimal[] assessment_ps = new decimal[3];
        public decimal[] assessment_pb = new decimal[3];
        public decimal[] comparative_approach = new decimal[3];

        
        public Comparative_approach_Form() { }

        public Comparative_approach_Form(Form form1)
        {
            InitializeComponent();//инициализация формы 
            Mathematics.Autocomplete_comparative_costly(ref numericUpDown1, ref numericUpDown4, ref numericUpDown7);//автозаполнение уже известных данных
            _form1 = form1;
            Work_With_Forms.Numeric_Maximum(this,1, 21);
            Decimal_place();//добавление двух знаков после запятой

            //функция слежки за последним измененным numericUpDown)
            Work_With_Forms.AttachNumericUpDownHandlers(this);

            // Привязка кнопок для домножения на 10^6 и 10^9
            Work_With_Forms.AttachButtonHandler(button3, button4);
        }
        /// <summary>
        /// добавление двух знаков после запятой
        /// </summary>
        void Decimal_place()
        {
            for (int i = 16; i <= 21; i++)
            {
                string controlName = $"numericUpDown{i}";
                var control = this.Controls.Find(controlName, true).FirstOrDefault() as NumericUpDown;
                if (control != null)
                {
                    control.DecimalPlaces = 2; // Разрешает два знака после запятой


                }
            }

        }
        /// <summary>
        /// Кнопка Рассчитать
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //подготовка данных к отправке
            decimal[] capital=new decimal[3];
            decimal[] ordinary_shares = new decimal[3];
            decimal[] vip_shares = new decimal[3];
            decimal[] revenue = new decimal[3];
            decimal[] profit = new decimal[3];
            decimal[] cost_ordinary_shares = new decimal[3];
            decimal[] cost_vip_shares = new decimal[3];
            capital = Filling_mas(capital, 1, 3);
            ordinary_shares= Filling_mas(ordinary_shares, 4, 6);
            vip_shares = Filling_mas(vip_shares, 7, 9);
            revenue = Filling_mas(revenue, 10, 12);
            profit=Filling_mas(profit, 13, 15);
            cost_ordinary_shares = Filling_mas(cost_ordinary_shares, 16, 18);
            cost_vip_shares = Filling_mas(cost_vip_shares, 19, 21);
            //далее эти данные отправляем в математику

            Mathematics decison_comparative_approach = new Mathematics();
            Comparative_approach_Form result= decison_comparative_approach.Comparative_approach(capital, ordinary_shares,vip_shares,revenue,profit,cost_ordinary_shares,cost_vip_shares,textBox16.Text);

            if (result != null)
            {
                Filling_form(result.capitalize, 1, 3);
                Filling_form(result.pe, 4, 6);
                Filling_form(result.pb, 7, 9);
                Filling_form(result.ps, 10, 12);
                Filling_form(result.comparative_approach, 13, 15);

                Work_With_Forms.HideLabel(this, 9, 13, false);
                Work_With_Forms.HideTextBox(this, 1, 20, false);
            }

        }
        /// <summary>
        /// функци для заполнения массива от элемента numericUpDown{num1} до numericUpDown{num2}
        /// </summary>
        /// <param name="fillme"></param>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        decimal[] Filling_mas(decimal[] fillme,int num1,int num2)
        {
            int fillmas = 0;
            for (int i = num1; i <= num2; i++)
            {
                string controlName = $"numericUpDown{i}";
                var control = this.Controls.Find(controlName, true).FirstOrDefault() as NumericUpDown;
                if (control != null)
                {
                    fillme[fillmas]=control.Value;
                        fillmas++;
                }
            }
            return fillme;
        }
        /// <summary>
        /// вывод данных на форму
        /// </summary>
        /// <param name="fillme"></param>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        void Filling_form(decimal[] fillme, int num1, int num2)
        {
            int number = 0;
            for (int i = num1; i <= num2; i++)
            {
                string controlName = $"textBox{i}";
                var control = this.Controls.Find(controlName, true).FirstOrDefault() as System.Windows.Forms.TextBox;
                if (control != null)
                {
                    control.Text = fillme[number].ToString();
                    number++;
                }
            }
        }
        /// <summary>
        /// Выбор формы в зависимости от используемого метода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
                _form1.Show();
                _form1.Refresh();
           
        }
        /// <summary>
        /// данные для примера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 1095000000000;
            numericUpDown2.Value = 5532000000000;
            numericUpDown3.Value = 4515000000000;
            numericUpDown4.Value = 2179 * (decimal)Math.Pow(10, 6);
            numericUpDown5.Value = 10598 * (decimal)Math.Pow(10, 6);
            numericUpDown6.Value = 650000000;
            numericUpDown7.Value = 148000000;
            numericUpDown10.Value = 1427 * (decimal)Math.Pow(10, 9);
            numericUpDown11.Value = 8761 * (decimal)Math.Pow(10, 9);
            numericUpDown12.Value = 9431 * (decimal)Math.Pow(10, 9);
            numericUpDown13.Value = 2849 * (decimal)Math.Pow(10, 8);
            numericUpDown14.Value = 1057 * (decimal)Math.Pow(10, 9);
            numericUpDown15.Value = 7734 * (decimal)Math.Pow(10, 8);
            numericUpDown16.Value = 502;
            numericUpDown17.Value = 484;
            numericUpDown18.Value = 5115;
            numericUpDown19.Value = 500;
            textBox16.Text = "Татнефть";
            textBox17.Text = "Роснефть";
            textBox18.Text = "Лукойл";
        }
    }
}
