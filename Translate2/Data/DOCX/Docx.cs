using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translate2.Data.DOCX
{
    internal class Docx
    {
        public Docx(string filePath) 
        {
            FilePath = filePath;
            m_Paras = new List<string>();
            try
            {
                using (WordprocessingDocument doc = WordprocessingDocument.Open(FilePath, false))
                {
                    var body = doc.MainDocumentPart.Document.Body;
                    // 获取主文档部分
                    var mainPart = doc.MainDocumentPart;

                    // 获取文档中的所有段落
                    var paragraphs = mainPart.Document.Body.Elements<Paragraph>();

                    // 遍历每个段落并输出文本
                    foreach (var para in paragraphs)
                    {
                        if(!string.IsNullOrEmpty(para.InnerText))
                            m_Paras.Add(para.InnerText.Trim());
                    }
                    Console.WriteLine(ParaCount);
                }
              

            }
            catch (IOException ex)
            {
                Console.WriteLine($"发生IO错误：{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误：{ex.Message}");
            }
            Console.WriteLine(ParaCount);
        }
        internal string FilePath
        {
            get;
            private set; 
            
        }
        public int ParaCount=>m_Paras.Count;
        private Document m_Doc;
        private List<string> m_Paras;
        public string GetParaByIndex(int index)
        {
            return m_Paras[index];
        }
        public List<string> GetAllParas()
        {
            return m_Paras;
        }
    }
}
