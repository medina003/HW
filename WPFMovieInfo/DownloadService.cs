using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WPFMovieInfo
{
    public static class DownloadService
    {
        public static async Task<string?> FindMovie(string? name)
        {
            WebClient client = new();
            string url = @"https://online-movie-database.p.rapidapi.com/auto-complete?q=";
            client.Headers.Add("X-RapidAPI-Key", "771e57c330msh40a40223bf90afdp1c4c1cjsn40b84fed566b");
            client.Headers.Add("X-RapidAPI-Host", "online-movie-database.p.rapidapi.com");
            return await client.DownloadStringTaskAsync(new Uri($"{url}{name}"));
        }
    }
}
