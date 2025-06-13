using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Stongs.Function
{
    internal class Work_With_ComboBox
    {
        private Dictionary<string, double> discount = new Dictionary<string, double>()//обновлено 13.04.2025
        {
            {"Металлы и добыча", 19.3 },
            {"Химия и нефтехимия", 18.2 },
            {"Нефть и газ", 20.9 },
            {"Электроэнергетика", 19.8 },
            {"Телекоммуникации", 18.5 },
            {"Финансы", 22.0 },
            {"Транспорт", 22.0 },
            {"Потребительский сектор", 21.1 },
            {"Информационные технологии", 23.1 },
            {"Строительство", 21.0 },
            {"Средней/малой капитализации", 20.9 }
        };
        /// <summary>
        /// обработка события выбора сферы
        /// </summary>
        /// <param name="selectedWord"></param>
        /// <returns></returns>
        public decimal comboBox_Choice(string selectedWord)
        {
            if (selectedWord != null && discount.ContainsKey(selectedWord))
            {
                MessageBox.Show($"Вы выбрали сферу: {selectedWord}");
                return (decimal)discount[selectedWord];
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите значение из списка.");
                return 0;
            }
        }
    }
}
