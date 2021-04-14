using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLab.LowMathControl
{
    interface ILowMathModel
    {
        string VarA { get; set; }
        string VarB { get; set; }

        int Calculate();
    }
}
