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
    class SharpForAnalyzer : ISharpForAnalyzer
    {
        private int _num_for;
        private string _error_mess;
        private string _analyze_code;
        public string AnalyzedCode { get => this._analyze_code; set => this._analyze_code = value; }
        public string GetErrorMessage { get => this._error_mess; }
        public int GetNumFor { get => this._num_for; }

        public SharpForAnalyzer()
        {
            this._analyze_code = "";
            this._num_for = 0;
            this._error_mess = "";
        }

        public SharpForAnalyzer(string analyze_code) : this()
        {
            this._analyze_code = analyze_code;
        }

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
                foreach (string elem in results.Errors)
                {
                    this._error_mess += elem + '\n';
                }
                return false;
            }
            else
            {
                dynamic Test = results.CompiledAssembly.CreateInstance("HelpCompileClass");
                this._num_for = Test.MethodHelp();

                return true;
            }

        }

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
        /// Insert additional code into Main method, 
        /// in order to calculate number of success for iterations
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

