using System;
using System.Collections.Generic;
using System.Linq;
using Project_Stongs.Forms;
using System.Windows.Forms;

namespace Project_Stongs.Function
{
    internal class Mathematics
    {
        static decimal capital;
        static decimal ordinary_shares;
        static decimal VIP_shares;

        //конец первого подхода

        static decimal rate_discouting;//ставка дисконтирования

        static decimal[] years = new decimal[5];//для хранения и автозаполнения срока анализа
        static string name_company;

        /// <summary>
        /// Хранит стоимость акции в соответствии с каждым из методов
        /// </summary>
        static Dictionary<string, decimal> data_price = new Dictionary<string, decimal> {
                {"costly",0},
                {"comparative",0 },
                {"DCF",0 },
                {"MKP",0 }
            };
        /// <summary>
        /// Хранит коэффициенты
        /// </summary>
        static Dictionary<string, decimal> koef = new Dictionary<string, decimal>
        {
            {"costly",4 },
            {"comparative",4 },
            {"DCF",4 },
            {"MKP",4 }
        };
        /// <summary>
        /// изменение коэф для подсчета итоговой стоиимости
        /// </summary>
        /// <param name="_k_costly"></param>
        /// <param name="_k_comparative"></param>
        /// <param name="_k_DCF"></param>
        /// <param name="_k_mkp"></param>
        public void Change_k(decimal _k_costly, decimal _k_comparative, decimal _k_DCF, decimal _k_mkp)
        {

            koef["costly"] = _k_costly;
            koef["comparative"] = _k_comparative;
            koef["DCF"] = _k_DCF;
            koef["MKP"] = _k_mkp;
        }
        public Mathematics()
        {
        }

        /// <summary>
        /// Мат. реализация затратного подхода
        /// </summary>
        /// <param name="_capital"></param>
        /// <param name="_ordinary_shares"></param>
        /// <param name="_VIP_shares"></param>
        /// <returns></returns>
        public decimal Costly_approach(decimal _capital, decimal _ordinary_shares, decimal _VIP_shares)//
        {
            if (_ordinary_shares + _VIP_shares == 0)
            {
                MessageBox.Show("Неправильные данные. Попробуйте еще раз.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;

            }

            capital = _capital;
            ordinary_shares = _ordinary_shares;
            VIP_shares = _VIP_shares;
            data_price["costly"] = Math.Round(_capital / (_ordinary_shares + _VIP_shares), 2);

            return data_price["costly"];
        }
        /// <summary>
        /// Мат. реализация сравнительного подхода
        /// </summary>
        /// <param name="capital"></param>
        /// <param name="ordinary_shares"></param>
        /// <param name="VIP_shares"></param>
        /// <param name="revenue"></param>
        /// <param name="profit"></param>
        /// <param name="price_ordinary_shares"></param>
        /// <param name="price_VIP_shares"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        public Comparative_approach_Form Comparative_approach(decimal[] capital, decimal[] ordinary_shares, decimal[] VIP_shares, decimal[] revenue, decimal[] profit, decimal[] price_ordinary_shares, decimal[] price_VIP_shares, string company)//Сравнительный подход.
        {
            for (int i = 0; i < 3; i++)
            {
                if (revenue[0] == 0 || profit[i] == 0 || capital[0] == 0 || VIP_shares[i] + ordinary_shares[i] == 0)
                {
                    MessageBox.Show("Неправильные данные. Попробуйте еще раз.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;

                }

            }


            decimal[] arrage_p = new decimal[3];//средний параметр p
            Comparative_approach_Form result_Comparative = new Comparative_approach_Form();
            for (int i = 0; i < 3; i++)
            {
                result_Comparative.capitalize[i] = ordinary_shares[i] * price_ordinary_shares[i] + VIP_shares[i] * price_VIP_shares[i];
                result_Comparative.pe[i] = Math.Round(result_Comparative.capitalize[i] / profit[i], 2);
                result_Comparative.ps[i] = Math.Round(result_Comparative.capitalize[i] / revenue[i], 2);
                result_Comparative.pb[i] = Math.Round(result_Comparative.capitalize[i] / capital[i], 2);

                arrage_p[0] += result_Comparative.pe[i];
                arrage_p[1] += result_Comparative.ps[i];
                arrage_p[2] += result_Comparative.pb[i];
                if (i == 2)
                {
                    arrage_p[0] /= 3;
                    arrage_p[1] /= 3;
                    arrage_p[2] /= 3;

                }
            }
            for (int i = 0; i < 3; i++)
            {
                result_Comparative.assessment_pe[i] = arrage_p[0] * profit[i] / (ordinary_shares[i] + VIP_shares[i]);
                result_Comparative.assessment_ps[i] = arrage_p[1] * revenue[i] / (ordinary_shares[i] + VIP_shares[i]);
                result_Comparative.assessment_pb[i] = arrage_p[2] * capital[i] / (ordinary_shares[i] + VIP_shares[i]);
                result_Comparative.comparative_approach[i] = Math.Round(result_Comparative.assessment_pe[i] / 3 + result_Comparative.assessment_ps[i] / 3 + result_Comparative.assessment_pb[i] / 3, 2);
            }
            name_company = company;
            data_price["comparative"] = result_Comparative.comparative_approach[0];
            return result_Comparative;


        }
        /// <summary>
        /// Мат реализация доходного подхода. Метод DCF.
        /// </summary>
        /// <param name="_years"></param>
        /// <param name="fcf"></param>
        /// <param name="projected_growth"></param>
        /// <param name="_rate_discouting"></param>
        /// <param name="after_projected_fcf"></param>
        /// <param name="_all_shares"></param>
        /// <returns></returns>
        public decimal Method_DCF(decimal[] _years, decimal[] fcf, decimal projected_growth, decimal _rate_discouting, decimal after_projected_fcf, decimal _all_shares)
        {
            decimal[] projected_fcf = new decimal[5];
            decimal[] dcfc = new decimal[5];
            decimal summ_dcfc = 0;
            decimal terminal_cost;
            decimal discounting_terminal_cost;
            decimal dcf;
            rate_discouting = _rate_discouting;


            if (fcf[0] == 0 || rate_discouting - after_projected_fcf == 0 || _all_shares == 0) //обработка ошибок(деление на 0)
            {
                MessageBox.Show("Неправильные данные. Попробуйте еще раз.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;

            }
            //формулы-формулы-формулы
            for (int i = 0; i < _years.Length; i++)
            {
                years[i] = _years[i];
            }
            projected_fcf[0] = fcf[4] + fcf[4] * projected_growth / 100;
            for (int i = 1; i < projected_fcf.Length; i++)
            {
                projected_fcf[i] = projected_fcf[i - 1] + projected_fcf[i - 1] * projected_growth / 100;
            }
            for (int i = 0; i < dcfc.Length; i++)
            {
                dcfc[i] = projected_fcf[i] / (decimal)(Math.Pow(1 + (double)rate_discouting / 100, i + 1));
            }
            for (int i = 0; i < dcfc.Length; i++)
            {
                summ_dcfc += dcfc[i];
            }
            terminal_cost = projected_fcf[4] * (1 + after_projected_fcf / 100) / ((rate_discouting - after_projected_fcf) / 100);
            discounting_terminal_cost = terminal_cost / (decimal)(Math.Pow(1 + (double)rate_discouting / 100, 5));
            dcf = discounting_terminal_cost + summ_dcfc;
            data_price["DCF"] = Math.Round(dcf / _all_shares, 2);
            return data_price["DCF"];
        }
        /// <summary>
        /// Мат реализация доходного подхода. Метод MKP
        /// </summary>
        /// <param name="_original_shares"></param>
        /// <param name="_VIP_shares"></param>
        /// <param name="_years"></param>
        /// <param name="cost_original_shares"></param>
        /// <param name="cost_VIP_shares"></param>
        /// <param name="clear_profit"></param>
        /// <param name="projected_temp_growth"></param>
        /// <param name="_rate_discouting"></param>
        /// <returns></returns>
        public decimal Profit_MKP(decimal _original_shares, decimal _VIP_shares, decimal[] _years, decimal[] cost_original_shares, decimal[] cost_VIP_shares, decimal[] clear_profit, decimal projected_temp_growth, decimal _rate_discouting)
        {
            decimal[] pe = new decimal[5];
            decimal[] projected_profit = new decimal[5];
            decimal[] discounting_projected_profit = new decimal[5];
            decimal arrage_pe = 0;
            decimal rightly_capitalize;
            ordinary_shares = _original_shares;
            VIP_shares = _VIP_shares;
            rate_discouting = _rate_discouting;

            for (int i = 0; i < pe.Length; i++)
            {
                if (clear_profit[i] == 0 || VIP_shares + ordinary_shares == 0)
                {
                    MessageBox.Show("Неправильные данные. Попробуйте еще раз.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;

                }
            }
            //формулы-формулы-формулы
            for (int i = 0; i < pe.Length; i++)
            {
                pe[i] = (cost_original_shares[i] * ordinary_shares + cost_VIP_shares[i] * VIP_shares) / clear_profit[i];
            }

            projected_profit[0] = clear_profit[4] + clear_profit[4] * (projected_temp_growth / 100);
            for (int i = 1; i < projected_profit.Length; i++)
            {
                projected_profit[i] = projected_profit[i - 1] + projected_profit[i - 1] * (projected_temp_growth / 100);
            }
            for (int i = 0; i < discounting_projected_profit.Length; i++)
            {
                discounting_projected_profit[i] = projected_profit[i] / (decimal)Math.Pow(1 + (double)rate_discouting / 100, i + 1);
            }
            for (int i = 0; i < pe.Length; i++)
            {
                arrage_pe += pe[i];
            }
            arrage_pe /= 5;
            rightly_capitalize = arrage_pe * discounting_projected_profit[4];

            data_price["MKP"] = Math.Round(rightly_capitalize / (VIP_shares + ordinary_shares), 2);
            return data_price["MKP"];
        }

        /// <summary>
        /// Отдельная функция для расчета прогнозируемого темпа роста
        /// </summary>
        /// <param name="price_start"></param>
        /// <param name="price_finish"></param>
        /// <returns></returns>
        public decimal FutureTempGrownt(decimal price_start, decimal price_finish)
        {
            if (price_start == 0 || price_finish == 0)
            {
                MessageBox.Show("Неправильные данные. Попробуйте еще раз.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            return (decimal)(Math.Pow((double)price_finish / (double)price_start, 1.0 / 4.0) - 1) * 100;
        }

        /// <summary>
        /// Мат. реализация комплексной оценки
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public Full_Result Comprehensive_Assessment(ref TextBox box)
        {
            Full_Result result = new Full_Result();

            result.costly_result = data_price["costly"];
            result.comparative_result = data_price["comparative"];
            result.dcf_result = data_price["DCF"];
            result.mkp_result = data_price["MKP"];

            // получаем ключи с k==0
            List<string> zeroKeys = koef
                .Where(pair => pair.Value == 0)
                .Select(pair => pair.Key)
                .ToList();

            foreach (string key in zeroKeys)
            {
                koef[key] = 1;
                data_price[key] *= 0;
            }
            box.Text = name_company;
            result.full_result = Math.Round(data_price["costly"] / koef["costly"] + data_price["comparative"] / koef["comparative"] + data_price["DCF"] / koef["DCF"] + data_price["MKP"] / koef["MKP"], 2);
            return result;


        }
        /// <summary>
        /// автозаполнение между costly и comparative
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="num3"></param>
        public static void Autocomplete_comparative_costly(ref NumericUpDown num1, ref NumericUpDown num2, ref NumericUpDown num3)
        {
            if (capital != 0)
            {
                num1.Maximum = decimal.MaxValue;
                num2.Maximum = decimal.MaxValue;
                num3.Maximum = decimal.MaxValue;
                num1.Value = capital;
                num2.Value = ordinary_shares;
                num3.Value = VIP_shares;
            }
        }
        /// <summary>
        /// автозаполнение между dcf и МКП
        /// </summary>
        /// <param name="_years"></param>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        public static void Autocomplete_dcf_mkp(ref decimal[] _years, ref NumericUpDown num1, ref NumericUpDown num2)
        {
            num1.Maximum = decimal.MaxValue;
            num2.Maximum = decimal.MaxValue;
            for (int i = 0; i < years.Length; i++)
            {
                _years[i] = years[i];
            }
            num2.Value = rate_discouting;

        }
        /// <summary>
        /// геттер для анализируемого периода
        /// </summary>
        /// <returns></returns>
        public static decimal[] Get_years()
        {
            return years;
        }
    }
}
