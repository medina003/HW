using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WPFMovieInfo
{
    public static class DeserealizeService
    {
        public static async Task<SearchResult?> Deserialize(string json)
        {
            return JsonSerializer.Deserialize<SearchResult>(json); 
        }
    }
}
