using System;
using System.Windows.Forms;
using WindowsFormsApp1;
using ClosedXML.Excel;
using static Project_Stongs.Function.Mathematics;
using Project_Stongs.Function;

namespace Project_Stongs.Forms
{
    public partial class Full_Result : Form
    {
        Main_menu main_menu=new Main_menu();
        public decimal costly_result { get; set; }
        public decimal comparative_result { get; set; }
        public decimal dcf_result { get; set; }
        public decimal mkp_result { get; set; }
        public decimal full_result { get; set; }
        public decimal k_costly;
        public decimal k_comarative;
        public decimal k_DCF;
        public decimal k_MKP;
        public Full_Result()
        {
        }
        public Full_Result(Main_menu _main_menu)
        {
            InitializeComponent();
            main_menu=_main_menu;
        }
        /// <summary>
        /// Кнопка выхода в главное меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            main_menu.Show();
        }
        private void button1_Click(object sender, EventArgs e)//показать резульаты
        {
            Mathematics full_final_result = new Mathematics();
            k_costly = numericUpDown1.Value;
            k_comarative= numericUpDown2.Value;
            k_DCF = numericUpDown3.Value;
            k_MKP = numericUpDown4.Value;
            full_final_result.Change_k(k_costly,k_comarative,k_DCF,k_MKP);
            Full_Result result = full_final_result.Comprehensive_Assessment(ref textBox6);
            textBox4.Text = result.costly_result.ToString();
            textBox3.Text = result.comparative_result.ToString();
            textBox2.Text = result.dcf_result.ToString();
            textBox1.Text = result.mkp_result.ToString();
            textBox5.Text = result.full_result.ToString();

        }
        /// <summary>
        /// сохранение результатов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            decimal[] years = Mathematics.Get_years();
            // Диалог выбора пути и имени файла
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                Title = "Сохранить как Excel-файл"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Лист1");
                        //Задание размеров столбцов
                        worksheet.Column("A").Width = 40;
                        worksheet.Column("B").Width = 20;
                        worksheet.Column("C").Width = 30;

                        // Вывод данных
                        worksheet.Cell("A1").Value = "Название компании:";
                        worksheet.Cell("B1").Value = textBox6.Text;

                        worksheet.Cell("A2").Value = "Затратный метод";
                        worksheet.Cell("B2").Value = textBox4.Text;

                        worksheet.Cell("A3").Value = "Сравнительный метод";
                        worksheet.Cell("B3").Value = textBox3.Text;

                        worksheet.Cell("A4").Value = "Метод DCF";
                        worksheet.Cell("B4").Value = textBox2.Text;

                        worksheet.Cell("A5").Value = "Метод МКП";
                        worksheet.Cell("B5").Value = textBox1.Text;

                        worksheet.Cell("A6").Value = "Итоговая справедливая стоимость";
                        worksheet.Cell("B6").Value = textBox5.Text;

                        worksheet.Cell("C1").Value = "Коэффициенты весомости";
                        worksheet.Cell("C2").Value = numericUpDown1.Value;
                        worksheet.Cell("C3").Value = numericUpDown2.Value;
                        worksheet.Cell("C4").Value = numericUpDown3.Value;
                        worksheet.Cell("C5").Value = numericUpDown4.Value;

                        worksheet.Cell("A7").Value = "Анализируемые годы: "+years[0] + " - " + years[4];

                      

                        // Сохранение
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Файл успешно сохранён!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
                }
            }
        }
    }
}
