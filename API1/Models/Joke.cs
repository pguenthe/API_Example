using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Models
{
    public class Joke
    {
        public string Type { get; set; }

        public JokeContent Value { get; set; }
    }

    public class JokeContent {
        public int Id { get; set; }
        public string Joke { get; set; }
        public string[] Categories { get; set; }
    }

    public class JokeList
    {
        public string Type { get; set; }

        public JokeContent[] Value { get; set; }
    }
}
