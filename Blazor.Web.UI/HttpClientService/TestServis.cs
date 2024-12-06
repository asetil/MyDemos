using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blazor.Web.UI.HttpClientService
{
    public class TestServis
    {
        private readonly HttpClient _httpClient;

        public TestServis()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            _httpClient = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(200) // Timeout ayarı
            };
        }

        public async Task<List<Comment>> GetComment()
        {

            try
            {
                var stopwatch = Stopwatch.StartNew();

                var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts/1/comments");
                stopwatch.Stop();

                Console.WriteLine($"Yanıt süresi: {stopwatch.ElapsedMilliseconds} ms");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Comment[] comments = JsonSerializer.Deserialize<Comment[]>(content);
                    Console.WriteLine("Başarılı yanıt: " + content);
                    return comments.ToList();
                }
                else
                {
                    Console.WriteLine($"Hata: {response.StatusCode}, Detay: {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine("Zaman aşımına uğradı veya görev iptal edildi: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Beklenmeyen bir hata: " + ex.Message);
            }
            return null;
        }

        public class Comment
        {
            [JsonPropertyName("postId")]
            public int PostId { get; set; }
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonPropertyName("name")]
            public string Name { get; set; }
            [JsonPropertyName("email")]
            public string Email { get; set; }
            [JsonPropertyName("body")]
            public string Body { get; set; }
        }



    }
}
