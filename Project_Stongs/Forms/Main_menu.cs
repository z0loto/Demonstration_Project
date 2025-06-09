using Project_Stongs.Forms;
using Project_Stongs.Function;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Main_menu : Form
    {
        /// <summary>
        /// Конструктор для инициализации
        /// </summary>
        public Main_menu()
        {
            this.Width = 1920;
            this.Height = 1080;
            InitializeComponent();
            
            this.StartPosition = FormStartPosition.CenterScreen;// позиционирует форму по центру экрана при запуске.
            this.MaximizeBox = false; // Отключает кнопку "Развернуть"
        }
        /// <summary>
        /// затратный метод
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Сostly_approach costly=new Сostly_approach(this);
            Work_With_Forms.SetupForm(costly, this);
      
            costly.ShowDialog();
        }
        /// <summary>
        /// сравнительный метод
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Comparative_approach_Form comparative = new Comparative_approach_Form(this);
            Work_With_Forms.SetupForm(comparative, this);
            comparative.ShowDialog();
        }
        /// <summary>
        /// доходный метод
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click_1(object sender, EventArgs e)
        {
            Hide();
            profit_form profit = new profit_form(this);
            Work_With_Forms.SetupForm(profit, this);
            profit.ShowDialog();
        }
        /// <summary>
        /// комплексная оценка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            Hide();
            Comprehensive_Assessment full_methods = new Comprehensive_Assessment(this);
            Work_With_Forms.SetupForm(full_methods, this);
            full_methods.ShowDialog();
            
        }

      
    }
}
