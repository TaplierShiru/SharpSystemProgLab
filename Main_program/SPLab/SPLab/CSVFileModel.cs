using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SPLab
{
    class CSVFileModel
    {
        private List<FileInfo> _fileInfoList;
        public ICollectionView FileInfo { get; private set; }

        public CSVFileModel()
        {
            GenerateFilesTest();
        }

        private void GenerateFilesTest()
        {
            this._fileInfoList = new List<FileInfo>{
                new FileInfo{ DataOfCreation = "20.20.20", FileName = "Badyda", Version = "v1" },
                new FileInfo{ DataOfCreation = "20.2.20", FileName = "Badyda", Version = "v3" },
                new FileInfo{ DataOfCreation = "1.3.20", FileName = "dw", Version = "v2" },
                new FileInfo{ DataOfCreation = "3.20.2", FileName = "DADWA", Version = "v5" },
                new FileInfo{ DataOfCreation = "20.5.1", FileName = "ssss", Version = "v4" }
            };

            FileInfo = CollectionViewSource.GetDefaultView(this._fileInfoList);
        }
    }
}
