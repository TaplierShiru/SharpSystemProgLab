using CreationBusinessDLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SPLab.CSVFileControl
{
    class CSVFileModel : ICSVFileModel
    {
        private Type _classType;
        private Assembly _dll_info;
        private object _file_controller;
        private string _path_to_dll = @"D:\University\СП\Лаба\SharpSystemProgLab\Test_dlls\" +
                                      @"business_dll\CreationBusinessDLL\CreationBusinessDLL\" +
                                      @"bin\Debug\CreationBusinessDLL.dll";
        public List<FileInfo> GetList
        {
            get
            {
                if (this._file_controller is null)
                {
                    return null;
                }
                List<FileInfo> fileInfoList = new List<FileInfo>();
                for (int i = 0; i < this.GetSize(); i++)
                {
                    string[] taken_params = this.GetAtIndex(i);
                    fileInfoList.Add(new FileInfo(taken_params[0], taken_params[1], taken_params[2], i));
                }
                return fileInfoList;
            }
        }
        public CSVFileModel()
        {
            
        }

        public void Compile()
        {
            this._dll_info = Assembly.LoadFile(this._path_to_dll);
            this._classType = this._dll_info.GetType("CreationBusinessDLL.CSV.CSVFileController");
            this._file_controller = Activator.CreateInstance(this._classType);
        }

        public void Load(string path)
        {
            this._classType.GetMethod("Load").Invoke(this._file_controller, new object[] {
                @"D:\University\СП\Лаба\SharpSystemProgLab\Main_program\SPLab\SPLab\CSVFileControl\DLL\test.csv" 
            });
            
        }

        public void Add(string fileName, string version, string dataOfCreation)
        {
            this._classType.GetMethod(
                    "Add", 
                    new Type[] { typeof(string), typeof(string), typeof(string) }
                ).Invoke(this._file_controller, new object[] {
                    fileName, version, dataOfCreation
                }
            );
        }

        public void Add(string path)
        {
            this._classType.GetMethod(
                    "Add",
                    new Type[] { typeof(string) }
                ).Invoke(this._file_controller, new object[] {
                    path
                }
            );

            Trace.WriteLine(GetList.Count);
        }

        public void Remove(int indx)
        {
            this._classType.GetMethod(
                    "Remove",
                    new Type[] { typeof(int) }
                ).Invoke(this._file_controller, new object[] {
                    indx
                }
            );

            Trace.WriteLine("Remove: " + indx);
        }
        public int GetSize()
        {
            var size = this._classType.GetProperty("GetListSize").GetValue(this._file_controller);
            return size is null ? 0 : (int)size;
        }

        public string[] GetAtIndex(int indx)
        {
            return (string[])this._classType.GetMethod(
                    "GetAtIndex", 
                    new Type[] { typeof(int) }
                ).Invoke(this._file_controller, new object[] { indx });
        }
    }
}
