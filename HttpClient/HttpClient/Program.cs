using System.Net.Http.Headers;
var client = new HttpClient();
var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/listquotes"),
    Headers =
    {
        { "X-RapidAPI-Key", "771e57c330msh40a40223bf90afdp1c4c1cjsn40b84fed566b" },
        { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
    },
};
using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    Console.WriteLine(body);
}