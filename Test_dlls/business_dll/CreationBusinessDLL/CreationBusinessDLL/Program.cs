using CreationBusinessDLL.CSV;
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

        static void Main(string[] args)
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
