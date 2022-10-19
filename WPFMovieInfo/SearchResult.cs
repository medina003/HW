using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMovieInfo
{

    public class SearchResult
    {
        public D[] d { get; set; }
        public string q { get; set; }
        public int v { get; set; }
     
    }

    public class D
    {
        public I i { get; set; }
        public string id { get; set; }
        public string l { get; set; }
        public string q { get; set; }
        public string qid { get; set; }
        public int rank { get; set; }
        public string s { get; set; }
        public int y { get; set; }
        public string yr { get; set; }
        public override string ToString()
        {
            return $"{l} {q} {yr}";
        }
    }

    public class I
    {
        public int height { get; set; }
        public string imageUrl { get; set; }
        public int width { get; set; }
    }

}
