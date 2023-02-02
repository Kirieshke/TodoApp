using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.BusinessLogic
{
    public static class JsonFileUtils
    {
        public static void SimpleWrite(object obj, string fileName)
        {
            var jsonString = JsonConvert.SerializeObject(obj);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
