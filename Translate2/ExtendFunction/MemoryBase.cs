using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Translate2.ExtendFunction;
using Translate2;

namespace Translate2.MemBase
{
    public class MemoryBase
    {
        private Dictionary<string, string> memoryDictionary;
        private FuzzyMatchingTool fuzzyMatcher;
        public MemoryBase()
        {
            memoryDictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            fuzzyMatcher = new FuzzyMatchingTool();
            LoadDictionary(ref memoryDictionary, "../../memoryDictionary/dictionary.txt");
        }
        public string UseTheDictionary(string target)
        {
            string resultString = "";
            target = target.Trim();
            if(memoryDictionary.ContainsKey(target))
            {
                resultString = "翻译过相同的句子：";
                resultString += target;
                resultString += Environment.NewLine + memoryDictionary[target];
            }
            resultString += Environment.NewLine + "相似度最高的句子：";
            resultString += Environment.NewLine + fuzzyMatcher.multiFuzzyMatching(memoryDictionary, target);
            return resultString;
        }

        public KeyValuePair<KeyValuePair<string, string>, int> getMostSimilarEntry(string target)
        {
            var result = fuzzyMatcher.getMostSimilar(memoryDictionary, target);
            return result;
        }

        private void LoadDictionary(ref Dictionary<string, string> dictionary, string filePath)
        {
            // string outputFile = "../../normalDictionary/output_file.txt";
            string lastRead = null;
            try
            {
                // using (StreamWriter writer = new StreamWriter(outputFile))
                // {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(line)) continue;
                        if (lastRead == null)
                        {
                            lastRead = line;
                        }
                        else
                        {
                            if (dictionary.ContainsKey(lastRead))
                            {
                                dictionary[lastRead] += Environment.NewLine + line + Environment.NewLine;
                            }
                            else
                            {
                                dictionary[lastRead] = line + Environment.NewLine;
                            }

                            // writer.WriteLine($"{lastRead}\r\n{line}\r\n");
                            lastRead = null;
                        }
                    }

                    // 处理文件以单词结尾而没有对应释义的情况
                    if (lastRead != null)
                    {
                        dictionary[lastRead] = string.Empty;
                        // writer.WriteLine($"{lastRead}\r\n{dictionary[lastRead]}");
                    }
                }
                // }
                // MessageBox.Show("读取完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载词典失败: {ex.Message}", "错误");
            }
        }
    }
}