using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMom2.Models
{
    public class Headline
    {
        public string Text { get; set; }

        public Headline(string text)
        {
            Text = text;
        }
    }
}
