using System;
using System.Linq;
using System.Windows.Forms;
using Project_Stongs.Function;

namespace Project_Stongs.Forms
{
    public partial class Method_MKP : Form
    {
        private Form _form1;
        public Method_MKP(Form form1)
        {
            InitializeComponent();
            _form1 =form1;
            Work_With_Forms.Numeric_Maximum(this, 1, 24);
            decimal[] years = new decimal[5];//значения отсюда нужно перенести в строчки
            Mathematics.Autocomplete_dcf_mkp(ref years, ref numericUpDown23, ref numericUpDown24);
            Auto_complete(years);
            Change_Precision_Output();
            //часть отвечающая за умножение на млн и млрд
            Work_With_Forms.AttachNumericUpDownHandlers(this);
            // Привязка кнопки
            Work_With_Forms.AttachButtonHandler(button3, button4);
            //коненц
        }
        /// <summary>
        /// автозаполнение лет
        /// </summary>
        /// <param name="years"></param>
        void Auto_complete(decimal[] years)
        {
            if (years[0] != 0)
            {
                numericUpDown7.Value = years[0];
                numericUpDown3.Value = years[1];
                numericUpDown4.Value = years[2];
                numericUpDown5.Value = years[3];
                numericUpDown6.Value = years[4];
            }

        }
        /// <summary>
        /// Изменение точности numeric
        /// </summary>
        void Change_Precision_Output()
        {
            for (int i = 8; i <= 17; i++)
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
        /// Кнопка назад
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
        /// Кнопка расчитать
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            decimal[] years = new decimal[5];
            years[0] = numericUpDown7.Value;
            years[1] = numericUpDown3.Value;
            years[2] = numericUpDown4.Value;
            years[3] = numericUpDown5.Value;
            years[4] = numericUpDown6.Value;
            decimal[] cost_original_shares = new decimal[5];
            cost_original_shares[0]= numericUpDown8.Value;
            cost_original_shares[1]= numericUpDown9.Value;
            cost_original_shares[2]= numericUpDown10.Value;
            cost_original_shares[3]= numericUpDown11.Value;
            cost_original_shares[4]= numericUpDown12.Value;

            decimal[] cost_VIP_shares = new decimal[5];
            cost_VIP_shares[0]= numericUpDown17.Value;
            cost_VIP_shares[1]=numericUpDown16.Value;
            cost_VIP_shares[2]=numericUpDown15.Value;
            cost_VIP_shares[3]=numericUpDown14.Value;
            cost_VIP_shares[4]=numericUpDown13.Value;

            decimal[] clear_profit=new decimal[5];
            clear_profit[0]=numericUpDown22.Value;
            clear_profit[1] = numericUpDown21.Value;
            clear_profit[2] = numericUpDown20.Value;
            clear_profit[3] = numericUpDown19.Value;
            clear_profit[4] = numericUpDown18.Value;
            Mathematics decison_mkp_approach = new Mathematics();

            textBox5.Text=(decison_mkp_approach.Profit_MKP(numericUpDown1.Value, numericUpDown2.Value, years, cost_original_shares, cost_VIP_shares,clear_profit, numericUpDown23.Value, numericUpDown24.Value)).ToString();
        

        }
        /// <summary>
        /// автоматическое проствление лет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown3.Value = numericUpDown7.Value + 1;
            numericUpDown4.Value = numericUpDown7.Value + 2;
            numericUpDown5.Value = numericUpDown7.Value + 3;
            numericUpDown6.Value = numericUpDown7.Value + 4;
        }
        /// <summary>
        /// заполнение данными для примера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 2179 * (decimal)Math.Pow(10, 6);
            numericUpDown2.Value = 148*(decimal)Math.Pow(10,6);
            numericUpDown7.Value = 2018;
            numericUpDown8.Value =(decimal)737.9;
            numericUpDown9.Value = (decimal)759.7;
            numericUpDown10.Value = (decimal)514.2;
            numericUpDown11.Value = (decimal)499.6;
            numericUpDown12.Value = (decimal)348.5;

            numericUpDown17.Value = (decimal)522;
            numericUpDown16.Value = 734;
            numericUpDown15.Value = (decimal)476.5;
            numericUpDown14.Value = (decimal)459.9;
            numericUpDown13.Value = (decimal)340.7;

            numericUpDown22.Value =2118 * (decimal)Math.Pow(10, 8);
            numericUpDown21.Value =1923 * (decimal)Math.Pow(10, 8);
            numericUpDown20.Value =1035 * (decimal)Math.Pow(10, 8);
            numericUpDown19.Value =1984 * (decimal)Math.Pow(10, 8);
            numericUpDown18.Value =2849 * (decimal)Math.Pow(10, 8);

            numericUpDown24.Value = 20;
            numericUpDown23.Value = 5;
        }
        /// <summary>
        /// Подсчет прогназируемого роста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            Mathematics tempGrownt = new Mathematics();
            numericUpDown23.Value = (tempGrownt.FutureTempGrownt(numericUpDown22.Value,numericUpDown18.Value));
        }
        /// <summary>
        /// выбор ставки дисконтирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Work_With_ComboBox box=new Work_With_ComboBox();
            numericUpDown24.Value = box.comboBox_Choice(comboBox1.SelectedItem?.ToString());
        }
    }
}
