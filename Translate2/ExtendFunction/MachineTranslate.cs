using System.Net.Http;
using System.Text;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office2016.Drawing.Command;

namespace MachineTranslation
{
    public class Translator
    {
        private readonly string _apiKey;
        private readonly string _baseUrl = "https://fanyi-api.baidu.com/api/trans/vip/translate";
        private string resultString;

        public Translator()
        {
            _apiKey = "uacq7V6k6wjqDvpc_QQ3";
        }
        public Translator(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<string> TranslateText(string text, string targetLanguage, string userAppid = "20240415002024918")
        {
            if (string.IsNullOrEmpty(userAppid))
            {
                throw new ArgumentNullException(nameof(userAppid), "百度API的AppID不能为空");
            }

            string randomString = GenerateRandomString();
            string salt = randomString; // salt通常与randomString相同，但根据您的API要求可能会有所不同  
            string sign = GenerateSignature(text, salt, userAppid, _apiKey);

            using (var client = new HttpClient())
            {
                var formValues = new Dictionary<string, string>
                {
                    { "q", text },
                    { "from", "auto" },
                    { "to", targetLanguage },
                    { "appid", userAppid },
                    { "salt", salt },
                    { "sign", sign }
                };

                var content = new FormUrlEncodedContent(formValues);

                HttpResponseMessage response = await client.PostAsync(_baseUrl, content);

                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        // 反序列化响应内容为 TranslationResponse 对象  
                        TranslationResponse translationResponse = JsonConvert.DeserializeObject<TranslationResponse>(responseContent);

                        // 检查是否有错误码  
                        if (translationResponse.ErrorCode.HasValue && translationResponse.ErrorCode != 0 && translationResponse.ErrorCode != 54003)
                        {
                            // 如果有错误码且不为0，抛出异常并包含错误码信息  
                            //throw new Exception($"翻译失败，错误码：{translationResponse.ErrorCode}");
                            MessageBox.Show($"出现错误码： {translationResponse.ErrorCode}");
                        }
                        bool flag = false;
                        // 检查翻译结果列表是否为空或没有元素  
                        if (translationResponse.TransResult != null && translationResponse.TransResult.Count > 0)
                        {
                            flag = true;
                            // 返回第一个翻译结果的译文  
                            resultString = translationResponse.TransResult[0].Dst;
                            for (int i = 1; i < translationResponse.TransResult.Count; i++)
                                resultString = resultString + "\r\n" + translationResponse.TransResult[i].Dst;
                            return resultString;
                        }
                        else
                        {
                            // 如果没有找到翻译结果，抛出异常  
                            //throw new Exception("未找到翻译结果");
                            if (!flag)
                            {
                                MessageBox.Show("未找到翻译结果");
                                return null;
                            }
                            else
                                return resultString;
                        }
                    }
                    catch (JsonReaderException e)
                    {
                        // 如果 JSON 反序列化失败，抛出异常  
                        throw new Exception("解析翻译响应失败", e);
                    }
                }
                else
                {
                    // 如果请求没有成功，抛出异常并包含响应内容  
                    throw new Exception($"翻译失败：{response.StatusCode} - {responseContent}");
                }
            }
        }

        private string GenerateRandomString()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 999999); // 假设生成一个6位数的随机字符串  
            return randomNumber.ToString();
        }

        private string GenerateSignature(string text, string salt, string appId, string secretKey)
        {
            // MD5生成密钥
            string toSign = appId + text + salt + secretKey;
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(toSign);
                byte[] hash = md5.ComputeHash(data);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }



    public class BaiduTranslateSignatureGenerator
    {
        private readonly string appid;
        private readonly string secretKey;

        public BaiduTranslateSignatureGenerator(string appid, string secretKey)
        {
            this.appid = appid;
            this.secretKey = secretKey;
        }

        public string GenerateSignature(string query, string salt)
        {
            // Concatenate the request parameters
            string concatenatedString = appid + query + salt + secretKey;

            // Generate the MD5 hash
            using (var md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(concatenatedString));
                //return Convert.ToHexString(hashBytes).ToLower();
                string hexString = hashBytes.Aggregate("", (current, b) => current + b.ToString("x2"));
                return hexString;
            }
        }
    }



    public class TranslationResultItem
    {
        [JsonProperty("src")]
        public string Src { get; set; }

        [JsonProperty("dst")]
        public string Dst { get; set; }
    }

    public class TranslationResponse
    {
        [JsonProperty("from")]
        public string From { get; set; } // 源语言  

        [JsonProperty("to")]
        public string To { get; set; } // 目标语言  

        [JsonProperty("trans_result")]
        public List<TranslationResultItem> TransResult { get; set; } // 翻译结果数组  

        [JsonProperty("error_code")]
        public int? ErrorCode { get; set; } // 错误码，使用可空类型表示可能不存在  

        // 构造函数  
        public TranslationResponse()
        {
            TransResult = new List<TranslationResultItem>();
        }
    }
}

