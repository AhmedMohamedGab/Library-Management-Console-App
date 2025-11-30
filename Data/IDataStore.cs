using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Data
{
    internal interface IDataStore
    {
        List<T> Load<T>(string fileName);
        void Save<T>(string fileName, List<T> items);
    }
}
