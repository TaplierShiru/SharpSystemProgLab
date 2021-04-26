using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SPLab.LowMathControl
{
    /// <summary>
    /// Класс реализующий Model часть LowMath виджета
    /// Который рассчитывает значение при помощи низкоуровневого языка
    /// </summary>
    class LowMathModel : ILowMathModel
    {
        /// <inheritdoc/>
        public string VarA { get; set; }

        /// <inheritdoc/>
        public string VarB { get; set; }

        /// <inheritdoc/>
        public string ErrorMess { get; set; }

        /// <inheritdoc/>
        public uint? Calculate()
        {
            uint var_a, var_b;
            try
            {
                var res = this.ChecktypeOfError();
                var_a = res[0];
                var_b = res[1];
                return (uint)this.ByteOr(var_a, var_b);
            }
            catch (FormatException)
            {
                // null считается за плохое значение
                // и не будет отображено 
                return null;
            }
        }

        /// <summary>
        /// Выполнение байтовой операции OR при помощи вызова функции на низкоуровневом языке
        /// </summary>
        /// <param name="var_a">Первая переменная А</param>
        /// <param name="var_b">Вторая переменная В</param>
        /// <returns>Итоговый результат операция - A OR B (битовое или)</returns>
        private uint ByteOr(uint var_a, uint var_b)
        {
            Assembly asm = Assembly.Load(System.IO.File.ReadAllBytes(
                @"D:\University\СП\Лаба\SharpSystemProgLab\Test_dlls\low_dll\low_dll\low_dll\bin\Debug\LowMathByteOr.dll"
            ));
            Type t = asm.GetType("LowMathByteOr_DLL");
            return (uint)t.GetMethod(
                "ByteOr",
                BindingFlags.Instance | BindingFlags.Public
            ).Invoke(Activator.CreateInstance(t), new object[] { var_a, var_b });
        }

        /// <summary>
        /// Проверяет свойства VarA, VarB на наличие ошибок и возможности их конвертации в uint
        /// </summary>
        /// <returns>Переменная A и B</returns>
        private uint[] ChecktypeOfError()
        {
            long var_a, var_b;
            ErrorMess = "";

            if (!long.TryParse(VarA, out var_a))
            {
                ErrorMess = "Ошибка: Первая переменная введена неверно\n";
                throw new FormatException("Число введено неправильно!\n");
            }

            if (!long.TryParse(VarB, out var_b))
            {
                ErrorMess += "Ошибка: Вторая переменная введена неверно\n";
                throw new FormatException("Число введено неправильно!\n");
            }

            if (var_a < 0 || var_a >= uint.MaxValue)
            {
                ErrorMess += "Ошибка: Первая переменная имеет отрицательное значение\n или слишком большое значение\n";
                throw new FormatException("Число введено неправильно!\n");
            }

            if (var_b < 0 || var_b >= uint.MaxValue)
            {
                ErrorMess += "Ошибка: Вторая переменная имеет отрицательное значение\n или слишком большое значение\n";
                throw new FormatException("Число введено неправильно!\n");
            }

            return new uint[] { (uint)var_a, (uint)var_b };
        }

    }

}
