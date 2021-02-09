using System;
using System.Collections.Generic;
using System.Text;

namespace PricticeDapper0802.Entities
{
    public class LetterBody
    {
        public string To { get; set; }

        public string From { get; set; }

        public string Subject { get; set; }

        public string Letter { get; set; }

        public DateTime Date { get; set; }
    }
}
