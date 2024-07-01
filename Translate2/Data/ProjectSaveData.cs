using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translate2.Data
{
    internal class ProjectSaveData
    {
        public ProjectSaveData(string path)
        {
            m_SavePath = path;
        } 
        
        public bool FromLoad=false;
        public Dictionary<string, string> Dict = new Dictionary<string, string>();
        public List<string> OriginTexts= new List<string>();
        public List<string> TranslateTexts=new List<string>();

        private string m_SavePath;
       
        private void Copy(ProjectSaveData data)
        {
            if (data == null) return;

            Dict = new Dictionary<string, string>();

            OriginTexts = new List<string>();

            TranslateTexts = new List<string>();
            foreach (var d in data.Dict)
            {
                Dict.Add(d.Key, d.Value); 
            }

            foreach (var d in data.OriginTexts)
            {
                OriginTexts.Add(d);
            }
            foreach(var d in data.TranslateTexts)
            {
                TranslateTexts.Add(d);
            }
        }

        public void Save()
        {
            string json=JsonConvert.SerializeObject(this);
            string path = m_SavePath;
            File.WriteAllText(path, json);
        }
        public void Load()
        {
            FromLoad = true;
            string path=m_SavePath;

            // 检查文件是否存在
            if (File.Exists(path))
            {
                try
                {
                    string jsonString = File.ReadAllText(path);
                    ProjectSaveData loadedData = JsonConvert.DeserializeObject<ProjectSaveData>(jsonString);
                    Copy(loadedData);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }

        }
    }
}
