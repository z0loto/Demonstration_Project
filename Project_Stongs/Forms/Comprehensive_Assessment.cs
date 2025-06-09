using System;
using System.Windows.Forms;
using Project_Stongs.Function;
using WindowsFormsApp1;

namespace Project_Stongs.Forms
{
    public partial class Comprehensive_Assessment : Form
    {
        private Main_menu _form1;
        public Comprehensive_Assessment(Main_menu form1)
        {
            InitializeComponent();
            _form1= form1;
        }
        /// <summary>
        /// затратный метод
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            button1.Visible = false;
            Сostly_approach full_costly = new Сostly_approach(this);
            Work_With_Forms.SetupForm(full_costly, this);

            full_costly.ShowDialog();

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
        }
        /// <summary>
        /// сравнительный метод
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            button3.Visible = false;
            Comparative_approach_Form full_comparative = new Comparative_approach_Form(this);
            Work_With_Forms.SetupForm(full_comparative, this);

            full_comparative.ShowDialog();

        }
        /// <summary>
        /// метод dcf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            Hide();
            button7.Visible = false;
            Method_DCF full_DCF = new Method_DCF(this);
            Work_With_Forms.SetupForm(full_DCF, this);

            full_DCF.ShowDialog();

        }
        /// <summary>
        /// метод MKP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            Hide();
            button6.Visible = false;
            Method_MKP full_MKP = new Method_MKP(this);
            Work_With_Forms.SetupForm(full_MKP, this);

            full_MKP.ShowDialog();
            
        }
        /// <summary>
        /// Кнопка Результат
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Close();//не работает сразу,hide добавлено чтобы спрятать форму сразу. После закрытия формы full_Result закроется и эта
            Full_Result full_Result = new Full_Result(_form1);
            Work_With_Forms.SetupForm(full_Result, this);
            full_Result.ShowDialog();

        }
    }
}
