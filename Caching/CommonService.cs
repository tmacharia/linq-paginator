using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Caching
{
    public class CommonService : ICommonService
    {
        #region Private Variables
        private readonly string _extension;
        private string _folder;
        #endregion

        public CommonService()
        {
            _folder = "LinqPaginator/Caching/";
            _extension = ".json";
        }
        public bool Initialize()
        {
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), _folder);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }


            _folder = folder;

            return Directory.Exists(_folder);
        }


        public string Read(string filename)
        {
            ValidateFileName(filename);

            string path = Path.Combine(_folder, filename + _extension);
            Log("Folder Path -> " + _folder, "FileName -> " + filename, "Extension -> " + _extension, "FullPath -> " + path);

            if (!File.Exists(path))
                throw new FileNotFoundException("A file with that name does exists in the application storage folder. Check the file name again", filename);
            else
            {
                return ReadFile(path);
            }
        }
        public TEntity Read<TEntity>(string filename)
        {
            ValidateFileName(filename);

            string path = Path.Combine(_folder, filename + _extension);

            TEntity entity = JsonConvert.DeserializeObject<TEntity>(ReadFile(path));

            return entity;
        }
        public Stream ReadAsStream(string filename)
        {
            ValidateFileName(filename);

            string path = Path.Combine(_folder, filename + _extension);
            Log("Folder Path -> " + _folder, "FileName -> " + filename, "Extension -> " + _extension, "FullPath -> " + path);

            if (!File.Exists(path))
                throw new FileNotFoundException("A file with that name does exists in the application storage folder. Check the file name again", filename);
            else
            {
                string s = ReadFile(path);

                return StringToStream(s);
            }
        }


        public bool Write(string filename, string contents)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentNullException("filename");

            string path = Path.Combine(_folder, filename + _extension);

            if (!File.Exists(path))
            {
                FileStream stream = File.Create(path);
                stream.Dispose();
            }

            // Write
            WriteFile(path, contents);

            return true;
        }
        public bool Write<TEntity>(TEntity entity, string filename)
        {
            // Validation first
            if (entity == null)
                throw new ArgumentNullException("entity data");

            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentNullException("filename");


            string path = Path.Combine(_folder, filename + _extension);

            if (!File.Exists(path))
            {
                FileStream stream = File.Create(path);
                stream.Dispose();
            }

            string json = JsonConvert.SerializeObject(entity);

            // Write
            WriteFile(path, json);

            return true;
        }


        public Stream StringToStream(string s)
        {
            MemoryStream memStream = new MemoryStream();

            StreamWriter writer = new StreamWriter(memStream);

            writer.Write(s);
            writer.Flush();
            memStream.Position = 0;

            return memStream;
        }
        public string StreamToString(Stream stream)
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                return sr.ReadToEnd();
            }
        }


        #region Private Section
        private string ReadFile(string filepath)
        {
            string content = string.Empty;
            FileStream stream = File.OpenRead(filepath);

            using (StreamReader sr = new StreamReader(stream))
            {
                content = sr.ReadToEnd();
            }

            stream.Dispose();

            return content;
        }
        private void WriteFile(string filepath, string data)
        {
            // Read file first
            string prev = ReadFile(filepath);

            if (prev == data)
                return;
            else if (!string.IsNullOrWhiteSpace(prev))
            {
                // Clear previous data
                ClearFileContents(filepath);
            }


            FileStream stream = File.OpenWrite(filepath);

            using (StreamWriter sw = new StreamWriter(stream))
            {
                sw.Write(data);
            }

            stream.Dispose();
        }
        private void Log(params string[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i+1, list[i]);
            }
        }
        private void ClearFileContents(string filepath)
        {
            FileStream fileStream = File.Open(filepath, FileMode.Open);

            /* 
             * Set the length of filestream to 0 and flush it to the physical file.
             *
             * Flushing the stream is important because this ensures that
             * the changes to the stream trickle down to the physical file.
             * 
             */
            fileStream.SetLength(0);
            fileStream.Close(); // This flushes the content, too.
            fileStream.Dispose();
        }
        private void ValidateFileName(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentNullException("filename");
        }
        #endregion
    }
}
