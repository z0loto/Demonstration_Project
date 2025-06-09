using System;
using System.Linq;
using System.Windows.Forms;
using Project_Stongs.Function;

namespace Project_Stongs.Forms
{
    public partial class Method_DCF : Form
    {
        private Form _form1;
        public Method_DCF(Form form1)
        {
            InitializeComponent();
            _form1 = form1;
            label4.Visible = false;
            textBox5.Visible = false;
            Work_With_Forms.Numeric_Maximum(this, 1, 14);
            decimal[] years=new decimal[5];//значения отсюда перенесятся в форму при автозаполнении
            Mathematics.Autocomplete_dcf_mkp(ref years,ref numericUpDown13,ref numericUpDown2);//автозаполнение между методами
            Auto_complete(years);//автозаполнение лет
            Work_With_Forms.AttachNumericUpDownHandlers(this);//слежка за последним измененным numeric

            Work_With_Forms.AttachButtonHandler(button3, button4); // Привязка кнопки для домножения

        }
        /// <summary>
        /// автозаполнение лет
        /// </summary>
        /// <param name="years"></param>
        void Auto_complete(decimal[] years)
        {
            if (years[0] != 0)
            {
                numericUpDown1.Value = years[0];
                numericUpDown3.Value = years[1];
                numericUpDown4.Value = years[2];
                numericUpDown5.Value = years[3];
                numericUpDown6.Value = years[4];
            }

        }
        /// <summary>
        /// достаточно ввести один год чтобы заполнить все ячейки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //автоматическое проствление лет
            numericUpDown3.Value = numericUpDown1.Value + 1;
            numericUpDown4.Value = numericUpDown1.Value + 2;
            numericUpDown5.Value = numericUpDown1.Value + 3;
            numericUpDown6.Value = numericUpDown1.Value + 4;
        }
        /// <summary>
        /// кнопка назад
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
        /// кнопка рассчитать
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            decimal[] years = new decimal[5];
            years[0] = numericUpDown1.Value;
            years[1] = numericUpDown3.Value;
            years[2] = numericUpDown4.Value;
            years[3] = numericUpDown5.Value;
            years[4] = numericUpDown6.Value;

            decimal[] fcf=new decimal[5];
            fcf[0] = numericUpDown11.Value;
            fcf[1] = numericUpDown10.Value;
            fcf[2] = numericUpDown9.Value;
            fcf[3] = numericUpDown8.Value;
            fcf[4] = numericUpDown7.Value;
            Mathematics decison_dcf_approach = new Mathematics();

            
            textBox5.Text = (decison_dcf_approach.Method_DCF(years, fcf, numericUpDown13.Value, numericUpDown2.Value, numericUpDown12.Value, numericUpDown14.Value)).ToString();
            label4.Visible = true;
            textBox5.Visible = true;
        }
        /// <summary>
        /// вывод данных для примера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 2018;

            numericUpDown11.Value = 1478 * (decimal)Math.Pow(10, 8);
            numericUpDown10.Value =1528 * (decimal)Math.Pow(10, 8);
            numericUpDown9.Value =957 * (decimal)Math.Pow(10, 8);
            numericUpDown8.Value =1484 * (decimal)Math.Pow(10, 8);
            numericUpDown7.Value =1968 * (decimal)Math.Pow(10, 8);

            numericUpDown2.Value = 15;

            numericUpDown13.Value = 5;

            numericUpDown12.Value = 4;

            numericUpDown14.Value =2326 * (decimal)Math.Pow(10, 6);
        }
        /// <summary>
        /// расчет исторического темпа роста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            Mathematics tempGrownt = new Mathematics();
            numericUpDown13.Value = (tempGrownt.FutureTempGrownt(numericUpDown11.Value, numericUpDown7.Value));
        }
        /// <summary>
        /// выбор ставки дисконтирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Work_With_ComboBox box = new Work_With_ComboBox();
            numericUpDown2.Value = box.comboBox_Choice(comboBox1.SelectedItem?.ToString());
        }
    }
}
