using System;
using System.Windows.Forms;
using Project_Stongs.Function;
using WindowsFormsApp1;

namespace Project_Stongs.Forms
{
    public partial class profit_form : Form
    {
        private Main_menu _form1;
        public profit_form(Main_menu form1)
        {
            InitializeComponent();
            _form1 = form1;
        }
        private void Вва_Click(object sender, EventArgs e)
        {
            Hide();
            Method_DCF method_DCF = new Method_DCF(this);
            Work_With_Forms.SetupForm(method_DCF, this);
            method_DCF.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            _form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            _form1.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Method_MKP method_MKP = new Method_MKP(this);
            Work_With_Forms.SetupForm(method_MKP, this);
            method_MKP.ShowDialog();

        }
    }
}
