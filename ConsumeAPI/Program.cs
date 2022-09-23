// See https://aka.ms/new-console-template for more information
using CRUD.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

UriBuilder builder = new UriBuilder("http://localhost:5053/api/Eventos/GetEventosAtuais");
builder.Query = "andar=25";

HttpClient httpClient = new HttpClient();
var result = httpClient.GetAsync(builder.Uri).Result;

using (StreamReader sr = new StreamReader(result.Content.ReadAsStreamAsync().Result))
{
    Console.WriteLine(sr.ReadToEnd());
}

Test test = new Test { number = 25 };
HttpClient client = new HttpClient();
client.BaseAddress = new Uri("http://localhost:5053/");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json"));
HttpResponseMessage response = await client.PostAsJsonAsync("api/Eventos/GetEventosAtuais", test);
response.EnsureSuccessStatusCode();
Console.WriteLine(response.Headers.Location);
Console.WriteLine(response.Content);
Console.ReadLine();


public class Test
{
    public int number { get; set; }
}