using CreationBusinessDLL.CSV;
using CreationBusinessDLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL.DataBase
{
    class DbController
    {

        public static void AddFileInfo(CSVFileInfo fileInfo)
        {
            using (FileContext db = new FileContext())
            {
                db.Files.Add(fileInfo);
                db.SaveChanges();
            }
        }
        public static void DeleteFileInfo(CSVFileInfo fileInfo)
        {
            using (FileContext db = new FileContext())
            {
                db.Files.Remove(
                    db.Files.Where(
                        x => x.FileName == fileInfo.FileName &&
                        x.Version == fileInfo.Version && 
                        x.DataOfCreation == fileInfo.DataOfCreation
                    ).FirstOrDefault()
                );
                db.SaveChanges();
            }
        }
        public static void EditFileInfo(CSVFileInfo old_fileInfo, string fileName, string version, string dataOfCreation)
        {

            using (FileContext db = new FileContext())
            {
                var found_fileInfo = db.Files.Where(
                        x => x.FileName == old_fileInfo.FileName &&
                        x.Version == old_fileInfo.Version &&
                        x.DataOfCreation == old_fileInfo.DataOfCreation
                ).FirstOrDefault();
                found_fileInfo.FileName = fileName;
                found_fileInfo.Version = version;
                found_fileInfo.DataOfCreation = dataOfCreation;
                db.SaveChanges();
            }
        }

        public static List<CSVFileInfo> GetFiles()
        {
            using (FileContext db = new FileContext())
            {
                return db.Files.ToList();
            }
        }

    }
}
