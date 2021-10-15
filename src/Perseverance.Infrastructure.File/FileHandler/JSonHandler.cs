using Newtonsoft.Json;
using System.IO;

namespace Perseverance.Infrastructure.File.FileHandler
{
    public class JSonHandler
    {
        private string _basePath;

        public JSonHandler()
        {
            _basePath = Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="data"></param>
        public void WriteFile(string fileName, object data)
        {
            string dataString = JsonConvert.SerializeObject(data);

            EnsureFolderExist(_basePath, "Data");

            string[] paths = { _basePath, "Data", fileName };
            string fullPath = $"{Path.Combine(paths)}.json";

            System.IO.File.WriteAllText(fullPath, dataString, System.Text.Encoding.UTF8);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool FileExist(string fileName)
        {
            string[] paths = { _basePath, "Data", fileName };
            string fullPath = $"{Path.Combine(paths)}.json";
            return System.IO.File.Exists(fullPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public T ReadFileData<T>(string fileName)
        {
            string[] paths = { _basePath, "Data", fileName };
            string fullPath = $"{Path.Combine(paths)}.json";

            StreamReader r = new StreamReader(fullPath);
            string jsonString = r.ReadToEnd();

            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        private void EnsureFolderExist(string basePath, string folderName)
        {
            string fullPath = Path.Combine(basePath, folderName);

            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);
        }
    }
}
