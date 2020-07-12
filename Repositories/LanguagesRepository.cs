using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WinForms.Repositories
{
    class LanguagesRepository
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<Language>> All()
        {
            var streamTask = client.GetStreamAsync("https://ncpr-2020-english-backend.herokuapp.com/api/languages");
            var languages = await JsonSerializer.DeserializeAsync<List<Language>>(await streamTask);
            return languages;
        }

        public static async Task<bool> Add(Language language) 
        {
            var content = new StringContent(JsonSerializer.Serialize(language), Encoding.Default, "application/json");
            var response = await client.PostAsync("https://ncpr-2020-english-backend.herokuapp.com/api/languages", content);
            return response.StatusCode == HttpStatusCode.OK;
        }
    }

    class Language
    {
        [JsonPropertyName("languageId")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
