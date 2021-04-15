using CreationBusinessDLL.CSV;
using CreationBusinessDLL.DataBase;
using CreationBusinessDLL.Interfaces;
using CreationBusinessDLL.SharpAnalyzer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationBusinessDLL
{
    class Program
    {
        static void Main33(string[] args)
        {
            var controller = new CSVFileController();
            Console.WriteLine(controller.GetListSize);
            controller.Remove(1);
            Console.WriteLine(controller.GetListSize);
            Console.ReadKey();
        }


        static void Main(string[] args)
        {

            using (FileContext db = new FileContext())
            {

                // получаем объекты из бд и выводим на консоль
                var files = db.Files;
                Console.WriteLine("Список объектов:");
                foreach (ICSVFileInfo u in files)
                {
                    Console.WriteLine("{0} {1} - {2}", u.FileName, u.Version, u.DataOfCreation);
                }
            }

            Console.ReadKey();
        }


        static void Main22(string[] args)
        {

            var writer = new CSVFileWriter("test.csv");

            var csv_elem_1 = new CSVFileInfo("blabla", "v1.3", "222");
            var csv_elem_2 = new CSVFileInfo("blsssa", "2.3", "112");
            var csv_elem_3 = new CSVFileInfo("bl", "v22.3", "332");

            writer.WriteCSV(csv_elem_1);
            writer.WriteCSV(csv_elem_2);
            writer.WriteCSV(csv_elem_3);
            writer.Flush();
            writer.Close();


            var reader = new CSVFileReader("test.csv");
            var list = reader.ReadCSV<CSVFileInfo>();


            foreach (var elem in list)
            {
                foreach (var single_elem in elem.GetCSVData)
                {
                    Console.Write(single_elem.ToString() + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            var controller = new CSVFileController();
            controller.Add(@"D:\Game's\RivaTuner Statistics Server\EncoderServer.exe");
            controller.Load("test.csv");
            Console.WriteLine(controller.GetAtIndex(0)[1]);

            Console.ReadKey();

        }

        static void Main3(string[] args)
        {

            using (FileContext db = new FileContext())
            {
                // создаем два объекта User
                var file1 = new CSVFileInfo { FileName = "Steam", Version = "v34.2", DataOfCreation = "22.02.25" };
                var file2 = new CSVFileInfo { FileName = "Visual", Version = "v1.2", DataOfCreation = "01.02.22" };

                // добавляем их в бд
                db.Files.Add(file1);
                db.Files.Add(file2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var files = db.Files;
                Console.WriteLine("Список объектов:");
                foreach (ICSVFileInfo u in files)
                {
                    Console.WriteLine("{0} {1} - {2}", u.FileName, u.Version, u.DataOfCreation);
                }
            }

            using (FileContext db = new FileContext())
            {
                var files = db.Files.Where(p => p.FileName == "Steam");
                foreach (ICSVFileInfo u in files)
                {
                    Console.WriteLine("{0} {1} - {2}", u.FileName, u.Version, u.DataOfCreation);
                }
            }

            Console.Read();
        }

        static void Main2(string[] args)
        { 
            string code = @"
for(int i = 0; i < 100; i++){
1
}
            ";
            var analyzer = new SharpForAnalyzer(code);
            analyzer.AnalyzeCode();

            Console.WriteLine(analyzer.GetErrorMessage);
            Console.WriteLine(analyzer.GetNumFor);

            Console.ReadKey();
        }

        static void Main1(string[] args)
        {
            
            var writer = new CSVFileWriter("test.csv");

            var csv_elem_1 = new CSVFileInfo("blabla", "v1.3", "222");
            var csv_elem_2 = new CSVFileInfo("blsssa", "2.3", "112");
            var csv_elem_3 = new CSVFileInfo("bl", "v22.3", "332");

            writer.WriteCSV(csv_elem_1);
            writer.WriteCSV(csv_elem_2);
            writer.WriteCSV(csv_elem_3);
            writer.Flush();
            writer.Close();
            

            var reader = new CSVFileReader("test.csv");
            var list = reader.ReadCSV<CSVFileInfo>();


            foreach( var elem in list)
            {
                foreach (var single_elem in elem.GetCSVData)
                {
                    Console.Write(single_elem.ToString() + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            var controller = new CSVFileController();
            controller.Add(@"D:\Game's\RivaTuner Statistics Server\EncoderServer.exe");
            Console.WriteLine(controller.GetAtIndex(0)[1]);

            Console.ReadKey();
        }
    }
}
