using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLab.LowMathControl
{
    /// <summary>
    /// 
    /// </summary>
    interface ILowMathModel
    {
        /// <summary>
        /// 
        /// </summary>
        string VarA { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string VarB { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string ErrorMess { get; set; }

        /// <summary>
        /// 
        /// </summary>
        uint? Calculate();
    }
}
