using CreationBusinessDLL.Interfaces;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.SharpAnalyzer
{
    /// <summary>
    /// Класс для анализа строки for из синтаксиса языка c#
    /// И подсчета количества выполнений цикла
    /// </summary>
    class SharpForAnalyzer : ISharpForAnalyzer
    {
        private int _num_for;
        private string _error_mess;
        private string _analyze_code;
        /// <inheritdoc/>
        public string AnalyzedCode { get => this._analyze_code; set => this._analyze_code = value; }
        /// <inheritdoc/>
        public string GetErrorMessage { get => this._error_mess; }
        /// <inheritdoc/>
        public int GetNumFor { get => this._num_for; }

        /// <summary>
        /// Создание класса для анализа строки
        /// </summary>
        public SharpForAnalyzer()
        {
            this._analyze_code = "";
            this._num_for = 0;
            this._error_mess = "";
        }


        /// <summary>
        /// Создание класса для анализа строки
        /// </summary>
        /// <param name="analyze_code">Кусок кода, который следует анализировать</param>
        public SharpForAnalyzer(string analyze_code) : this()
        {
            this._analyze_code = analyze_code;
        }

        /// <inheritdoc/>
        public bool AnalyzeCode()
        {
            var compiler = new CSharpCodeProvider();
            var parameters = new CompilerParameters(new string[] { "mscorlib.dll", "System.Core.dll" }, null, true);
            parameters.GenerateExecutable = true;

            string sourceCode = this.GenerateHelpCode();
            var results = compiler.CompileAssemblyFromSource(parameters, sourceCode);

            if (results.Errors.HasErrors)
            {
                this._error_mess = "";
                // There are can be several erorrs - iterate throught each
                foreach (var elem in results.Errors)
                {
                    // "path".cs(num row error, num column error) : error itself
                    string error = elem.ToString();
                    string grap_error = error.Substring(error.IndexOf(".cs")+3);
                    // Take error mess
                    string error_mess = grap_error.Substring(grap_error.IndexOf(')') + 1);
                    // Change lines of error
                    // (10, 20)
                    string[] position_error = grap_error.Substring(0, grap_error.IndexOf(')')).Substring(1).Split(',');
                    int row = int.Parse(position_error[0]) - 9;
                    int column = int.Parse(position_error[1]) - 2;
                    // Connect into other strings and create new error view
                    this._error_mess += "(" + row + ", " + column + ")" + error_mess + '\n';
                }
                return false;
            }
            else
            {
                dynamic Test = results.CompiledAssembly.CreateInstance("HelpCompileClass");
                this._num_for = Test.MethodHelp();
                this._error_mess = "Ошибок не обнаружено";
                return true;
            }

        }

        /// <summary>
        /// Возвращает код нужный для компиляции c# кода
        /// </summary>
        private string GenerateHelpCode()
        {
            return @"
            using System;
                public class HelpCompileClass
                {
                    public static void Main(string[] args){}
                    public int MethodHelp()
                    {
                        int counter = 0;
" + this.InsertToCode() + @"
                        return counter;
                    }
                }";
        }

        /// <summary>
        /// Вставка счетчика в анализируемый код
        /// чтобы успешно посчитать кол-во выполнений цикла
        /// </summary>
        private string InsertToCode()
        {
            int i = 0;
            while (i < AnalyzedCode.Length && AnalyzedCode[i] != '{')
            {
                i++;
            }
            if (i == AnalyzedCode.Length)
            {
                return AnalyzedCode;
            }
            else
            {
                return AnalyzedCode.Substring(0, i + 1) + "counter++;" + AnalyzedCode.Substring(i + 1);
            }
        }
    }

}

