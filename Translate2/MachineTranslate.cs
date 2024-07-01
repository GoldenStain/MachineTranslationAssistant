using System.Net.Http;
using System.Text;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Newtonsoft.Json; // 需要安装 Newtonsoft.Json NuGet 包

namespace MachineTranslation
{
    public class Translator
    {
        private readonly string _apiKey;

        public Translator(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<string> TranslateText(string text, string targetLanguage, string userAppid = null, string baiduKey = null)//待翻译文本，目标语言，可选参数：百度的appid，用户可以在管理控制台查看
        {
            string url = "https://fanyi-api.baidu.com/api/trans/vip/translate";

            string baiduSign = string.Empty;

            if (userAppid && baiduKey)
            {
                Random random = new Random();
                int randomNumber = random.Next(1, 100);
                string randomString = randomNumber.Tostring();// randomString就是salt
                BaiduTranslateSignatureGenerator baiduTranslateSignatureGenerator = new BaiduTranslateSignatureGenerator(userAppid, baiduKey);
                baiduSign = baiduTranslateSignatureGenerator.GenerateSignature(text, randomString); //生成签名
            }

            var content = new StringContent(
                JsonConvert.SerializeObject(
                    new { q = text, from = auto, to = targetLanguage, appid = userAppid, }),
                Encoding.UTF8,
                "application/json");

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(url, content);
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<TranslationResponse>(responseContent).Data.Translations[0].TranslatedText;
                }
                else
                {
                    throw new Exception($"翻译失败：{responseContent}");
                }
            }
        }
    }

    public class TranslationResponse
    {
        public Data Data { get; set; }
    }

    public class Data
    {
        public List<Translation> Translations { get; set; }
    }

    public class Translation
    {
        public string TranslatedText { get; set; }
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
                return Convert.ToHexString(hashBytes).ToLower();
            }
        }
    }
}

