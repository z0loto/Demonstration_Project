using Project_Stongs;
using Project_Stongs.Function;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Сostly_approach : Form
    {
        private Form _form1;


        
       public Сostly_approach(Form form1)
        {
            InitializeComponent();
            Work_With_Forms.Numeric_Maximum(this, 1, 3);

            Mathematics.Autocomplete_comparative_costly(ref numericUpDown1, ref numericUpDown2, ref numericUpDown3);

            //функции для слежки и привязки кнопок домножения на последний измененный numeric
            Work_With_Forms.AttachNumericUpDownHandlers(this);
            Work_With_Forms.AttachButtonHandler(button3, button4);

            //спрятать кнопки по указанию дизайнера
            label6.Visible = false;
            textBox4.Visible = false;
            _form1 = form1;
        }
        /// <summary>
        /// кнопка расчитать
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Mathematics decision_costly = new Mathematics();
            textBox4.Text= (decision_costly.Costly_approach(numericUpDown1.Value, numericUpDown2.Value, numericUpDown3.Value)).ToString();

            //показать спрятанные кнопки
            label6.Visible = true;
            textBox4.Visible = true;

        }
        private void button5_Click(object sender, EventArgs e)//вывод примера
        {
            numericUpDown1.Value = 1095000000000;
            numericUpDown2.Value = 2179000000;
            numericUpDown3.Value = 148000000;


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
    }
}
