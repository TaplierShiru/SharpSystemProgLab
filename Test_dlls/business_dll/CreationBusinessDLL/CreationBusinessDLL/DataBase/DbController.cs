using CreationBusinessDLL.CSV;
using CreationBusinessDLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.DataBase
{
    /// <summary>
    /// Класс реализующий действия над БД
    /// </summary>
    class DbController
    {

        /// <summary>
        /// Добавление новой записи в БД
        /// </summary>
        /// <param name="fileInfo">Информация об некотором файле, новая запись в БД</param>
        public static void AddFileInfo(CSVFileInfo fileInfo)
        {
            using (FileContext db = new FileContext())
            {
                db.Files.Add(fileInfo);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Удаление записи в бд
        /// </summary>
        /// <param name="fileInfo">Запись которую следует удалить</param>
        public static void DeleteFileInfo(CSVFileInfo fileInfo)
        {
            using (FileContext db = new FileContext())
            {
                db.Files.Remove(db.Files.Find(fileInfo.Id));
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Изменение/обновление существующий записи в БД
        /// </summary>
        /// <param name="old_fileInfo">Старая запись в бд</param>
        /// <param name="fileName">Новое имя файла</param>
        /// <param name="version">Новая версия файла</param>
        /// <param name="dataOfCreation">Новая дата создания</param>
        public static void EditFileInfo(CSVFileInfo old_fileInfo, string fileName, string version, string dataOfCreation)
        {

            using (FileContext db = new FileContext())
            {
                var found_fileInfo = db.Files.Find(old_fileInfo.Id);
                found_fileInfo.FileName = fileName;
                found_fileInfo.Version = version;
                found_fileInfo.DataOfCreation = dataOfCreation;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Возврат всех записей из БД
        /// </summary>
        public static List<CSVFileInfo> GetFiles()
        {
            using (FileContext db = new FileContext())
            {
                return db.Files.ToList();
            }
        }

    }
}
