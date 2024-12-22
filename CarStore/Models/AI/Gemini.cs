using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarStore.Models.AI
{
    public class GeminiChatbot
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string apiKey;

        public GeminiChatbot(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task<string> GenerateResponseAsync(string prompt, List<ChatHistory> history)
        {
            string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={apiKey}";

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                },
                generationConfig = new
                {
                    temperature = 0.9,
                    topK = 50,
                    topP = 0.95,
                    maxOutputTokens = 4096,
                    stopSequences = new string[] { }
                },
                safetySettings = new string[] { }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                return ExtractTextFromResponse(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Request error: " + e.Message);
                return $"Request error: {e.Message}";
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
                return $"Unexpected error: {e.Message}";
            }
        }

        private string ExtractTextFromResponse(string responseBody)
        {
            var startIndex = responseBody.IndexOf("\"text\": \"") + 9;
            var endIndex = responseBody.IndexOf("\"", startIndex);
            return responseBody.Substring(startIndex, endIndex - startIndex);
        }
    }

    public class ChatHistory
    {
        public string role
        {
            get; set;
        }
        public List<string> parts
        {
            get; set;
        }
    }
}
