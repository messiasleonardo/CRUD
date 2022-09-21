// See https://aka.ms/new-console-template for more information
using CRUD.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

HttpClient httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Accept.Clear();
httpClient.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json"));
var webResponse = httpClient.GetAsync("https://localhost:7280/api/Dados").GetAwaiter().GetResult();
var jsonResponse = webResponse.Content.ReadAsStringAsync().Result;
var response = JsonConvert.DeserializeObject<List<Customer>>(jsonResponse);
Console.WriteLine(jsonResponse);
Console.ReadLine();