using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreationBusinessDLL.CSV;

namespace CreationBusinessDLL.DataBase
{
    class FileContext : DbContext
    {
        public DbSet<CSVFileInfo> Files { get; set; }

        public FileContext()
            : base("DBConnection")
        { }

    }
}
