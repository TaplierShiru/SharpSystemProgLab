using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SPLab.LowMathControl
{
    class LowMathModel : ILowMathModel
    {
        public string VarA { get; set; }
        public string VarB { get; set; }

        public int Calculate()
        {
            int var_a, var_b;
            try
            {
                if (!(int.TryParse(VarA, out var_a) && int.TryParse(VarB, out var_b)))
                {
                    throw new Exception("Число введено неправильно!\n");
                }
                return (int)this.ByteOr(var_a, var_b);
            }
            catch
            {
                return -1;
            }
        }
        private int ByteOr(int var_a, int var_b)
        {
            Assembly asm = Assembly.Load(System.IO.File.ReadAllBytes(
                @"D:\University\СП\Лаба\SharpSystemProgLab\Test_dlls\low_dll\low_dll\low_dll\bin\Debug\LowMathByteOr.dll"
            ));
            Type t = asm.GetType("LowMathByteOr_DLL");
            return (int)t.GetMethod(
                "ByteOr",
                BindingFlags.Instance | BindingFlags.Public
            ).Invoke(Activator.CreateInstance(t), new object[] { var_a, var_b });
        }

    }

}
