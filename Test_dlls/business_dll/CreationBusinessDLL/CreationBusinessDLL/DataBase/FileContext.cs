using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreationBusinessDLL.CSV;

namespace CreationBusinessDLL.DataBase
{
    /// <summary>
    /// Класс для работы с базой данных
    /// </summary>
    class FileContext : DbContext
    {
        /// <summary>
        /// Коллекция описывающая данные хранящиеся в БД
        /// В данном случае это коллекция информации об файле
        /// </summary>
        public DbSet<CSVFileInfo> Files { get; set; }

        public FileContext()
            : base("DBConnection")
        { }

    }
}
