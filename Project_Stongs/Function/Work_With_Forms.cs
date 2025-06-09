using System.Linq;
using System.Windows.Forms;

namespace Project_Stongs.Function
{
    internal class Work_With_Forms
    {
        private static NumericUpDown _lastChangedNumericUpDown;
        public static void SetupForm(Form form, Form owner)
        {
            form.Width = 1920;// ширина
            form.Height = 1080;// высота
            form.StartPosition = FormStartPosition.CenterScreen;// установка 
            form.MaximizeBox = false;  // Отключает кнопку "Развернуть"
            form.Owner = owner;        // Устанавливает владельца формы
        }
        /// <summary>
        /// функция чтобы прятать надписи перед подсчетом
        /// </summary>
        /// <param name="form"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="Hide"></param>
        public static void HideLabel(Form form,int startIndex,int endIndex,bool Hide)//подумать про объединение фукций
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                var label = form.Controls.Find($"label{i}", true).FirstOrDefault() as Label;
                if (label != null)
                {
                    if (Hide == true)
                    {
                        label.Hide();
                    }
                    else
                    {
                        label.Show();
                    }
                }
            }
        }
        /// <summary>
        /// функция слежки за последним измененным numericUpDown)     
        /// </summary>
        /// <param name="form"></param>
        public static void AttachNumericUpDownHandlers(Form form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.ValueChanged += (sender, e) =>
                    {
                        _lastChangedNumericUpDown = sender as NumericUpDown;
                    };
                }
            }
        }

        /// <summary>
        /// Метод для выполнения умножения на 10^6
        /// </summary>
        public static void MultiplyLastChanged() 
        {
            if (_lastChangedNumericUpDown != null)
            {
                _lastChangedNumericUpDown.Value *= 1_000_000;
            }
            else
            {
                MessageBox.Show("Не найден последний изменённый NumericUpDown.");
            }
        }

        /// <summary>
        /// Метод для выполнения умножения на 10^9
        /// </summary>
        public static void MultiplyBillion() 
        {
            if (_lastChangedNumericUpDown != null)
            {
                _lastChangedNumericUpDown.Value *= 1_000_000_000;
            }
            else
            {
                MessageBox.Show("Не найден последний изменённый NumericUpDown.");
            }
        }

        /// <summary>
        /// Метод для привязки функций домнаженя
        /// </summary>
        /// <param name="button1"></param>
        /// <param name="button2"></param>
        public static void AttachButtonHandler(System.Windows.Forms.Button button1, System.Windows.Forms.Button button2) 
        {
            button1.Click += (sender, e) =>
            {
                MultiplyLastChanged();
            };
            button2.Click += (sender, e) =>
            {
                MultiplyBillion();
            };
        }
        /// <summary>
        /// прячет данные для вывода ответа пока они пустые
        /// </summary>
        /// <param name="form"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="Hide"></param>
        public static void HideTextBox(Form form, int startIndex, int endIndex,bool Hide)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                var textBox = form.Controls.Find($"textBox{i}", true).FirstOrDefault() as System.Windows.Forms.TextBox;
                if (textBox != null)
                {
                    if (Hide == true)
                    {
                        textBox.Hide();
                    }
                    else
                    {
                        textBox.Show();
                    }
                }
            }
        }
        /// <summary>
        /// установка максимальных и минимальных значений
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        public static void Numeric_Maximum(Form form,int num1, int num2)
        {
            for (int i = num1; i <= num2; i++)
            {
                string controlName = $"numericUpDown{i}";
                var control = form.Controls.Find(controlName, true).FirstOrDefault() as NumericUpDown;
                if (control != null)
                {
                    control.Maximum = decimal.MaxValue;
                    control.Minimum = decimal.MinValue;

                }
            }

        }
    }
}
