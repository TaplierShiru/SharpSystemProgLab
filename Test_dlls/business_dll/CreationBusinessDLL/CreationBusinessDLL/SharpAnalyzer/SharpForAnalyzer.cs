using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.SharpAnalyzer
{
    class SharpForAnalyzer : ISharpForAnalyzer
    {
        private string _input_str = null;
        private int? _num_fors = null;
        private string _error = null;

        public bool Analyze(string in_str)
        {
            throw new NotImplementedException();
        }

        public KeyValuePair<int, string> GetError()
        {
            throw new NotImplementedException();
        }

        public int GetNumFor()
        {
            throw new NotImplementedException();
        }
    }
}
