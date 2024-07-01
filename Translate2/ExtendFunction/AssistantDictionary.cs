using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Translate2.ExtendFunction;

namespace Translate2.AssistantDictionary
{
    public class MyDictionary
    {
        private FuzzyMatchingTool fuzzyMatcher;
        private Dictionary<string, string> dictionary;
        private string keyOfDictionary = string.Empty;
        public MyDictionary()
        {
            // string currentDirectory = Directory.GetCurrentDirectory();
            // MessageBox.Show("Current Directory: " + currentDirectory);

            fuzzyMatcher = new FuzzyMatchingTool();
            dictionary = new Dictionary<string, string>();
            // compareFile();
            // MessageBox.Show("complete");
            LoadDictionary(ref dictionary, "../../normalDictionary/dictionary.txt");
        }

        private int FindFirstDifference(string line1, string line2)
        {
            int minLength = Math.Min(line1.Length, line2.Length);

            for (int i = 0; i < minLength; i++)
            {
                if (line1[i] != line2[i])
                {
                    return i + 1; // 返回列号，从1开始计数
                }
            }

            return minLength + 1; // 如果一个是另一个的前缀，返回长度+1的位置
        }

        private void compareFile()
        {
            string filePath1 = "../../normalDictionary/dictionary.txt",
                filePath2 = "../../normalDictionary/output_file.txt";
            try
            {
                using (StreamReader reader1 = new StreamReader(filePath1))
                using (StreamReader reader2 = new StreamReader(filePath2))
                {
                    string line1 = "", line2 = "";
                    int lineNumber = 0;

                    while ((line1 = reader1.ReadLine()) != null && (line2 = reader2.ReadLine()) != null)
                    {
                        lineNumber++;
                        if (!line1.Equals(line2))
                        {
                            int column = FindFirstDifference(line1, line2);
                            MessageBox.Show($"Files differ at line {lineNumber}, column {column}");
                            return;
                        }
                    }

                    if (line1 != null || reader1.ReadLine() != null || line2 != null || reader2.ReadLine() != null)
                    {
                        Console.WriteLine($"Files differ at line {lineNumber + 1}, one file has extra lines.");
                    }
                    else
                    {
                        Console.WriteLine("Files are identical.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void LoadDictionary(ref Dictionary<string, string> dictionary, string filePath)
        {
            string outputFile = "../../normalDictionary/output_file.txt";
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
                // MessageBox.Show($"加载词典失败: {ex.Message}", "错误");
            }
        }

        private void LoadDictionaryFalse(ref Dictionary <string, string> dictionary, string filePath)
        {
            try
            {
                // 词典读取逻辑，待修改
                int lineCount = 0;
                foreach (var line in File.ReadAllLines(filePath))
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;
                    lineCount = (lineCount + 1) % 2;
                    if (lineCount == 0) //释义
                    {
                        if (dictionary.ContainsKey(keyOfDictionary))
                            dictionary[keyOfDictionary] += "\r\n" + line.Trim();
                        else
                        {
                            dictionary[keyOfDictionary] = line.Trim();
                        }
                    }
                    else //词条 
                    {
                        keyOfDictionary = line.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show($"failed loading dictionary: {ex.Message}", "Error");
            }
            // MessageBox.Show($"the size is : {dictionary.Count}");
        }

        public string UseTheDictionary(string target)
        {
            int costTime = 0;
            target = target.Trim();
            string resultString = SearchDictionary(target, ref costTime);
            if (resultString == target)
            {
                return dictionary[target];
            }
            else if (resultString != target)
            {
                if (resultString != null)
                {
                    resultString = "你是否想找\r\n" + resultString + "\r\n" + dictionary[resultString] + $"\r\n模糊匹配用时：{costTime}ms\r\n";
                    return resultString;
                }
                else
                    return $"对不起，找不到该单词\r\n 匹配用时：{costTime}ms\r\n";
            }
            return null;
        }

        private string SearchDictionary(string target, ref int costTime)
        {
            if (dictionary.ContainsKey(target))
            {
                return target;
            }
            else
            {
                return fuzzyMatcher.FuzzyMatching(dictionary, target, ref costTime);
            }
        }
    }
    public class DataReader
    {
        private string _filePath;
        private string _stringContent;

        public DataReader()
        {
        }

        public DataReader(string filePath)
        {
            _filePath = filePath;
        }

        public DataReader FromFile(string filePath)
        {
            _filePath = filePath;
            return this;
        }

        public DataReader FromString(string content)
        {
            _stringContent = content;
            return this;
        }

        public void ReadString()
        {
            if (string.IsNullOrEmpty(_stringContent))
            {
                Console.WriteLine("No string content to read.");
                return;
            }

            Console.WriteLine("Reading from string:");
            using (StringReader reader = new StringReader(_stringContent))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public void ReadFile()
        {
            if (string.IsNullOrEmpty(_filePath))
            {
                Console.WriteLine("No file path specified.");
                return;
            }

            Console.WriteLine("Reading from file:");
            try
            {
                using (StreamReader reader = new StreamReader(_filePath, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"File not found: {e.Message}");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An I/O error occurred: {e.Message}");
            }
        }

        public void GenerateTestFile()
        {
            if (string.IsNullOrEmpty(_filePath))
            {
                Console.WriteLine("No file path specified for generating test file.");
                return;
            }

            using (StreamWriter writer = new StreamWriter(_filePath, false, Encoding.UTF8))
            {
                writer.WriteLine("This is a test file.");
                writer.WriteLine("It contains multiple lines of text.");
                writer.WriteLine("Each line will be read and displayed on the console.");
                writer.WriteLine("This is the end of the file.");
            }
        }

        public void ProcessData(string data)
        {
            Console.WriteLine("Processing data:");
            string[] words = data.Split(' ');
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }

        public string ReadFileToString()
        {
            if (string.IsNullOrEmpty(_filePath))
            {
                Console.WriteLine("No file path specified.");
                return string.Empty;
            }

            try
            {
                using (StreamReader reader = new StreamReader(_filePath, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
                return string.Empty;
            }
        }

        public void ReadAndProcessFile()
        {
            string content = ReadFileToString();
            if (!string.IsNullOrEmpty(content))
            {
                ProcessData(content);
            }
        }
    }
}