using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    class LinksRepository
    {
        private List<string> links;

        public LinksRepository()
        {
            links = new List<string>();
        }

        private StringFormatter sf;
        public StringFormatter Formatter
        {
            set
            {
                if (value is null) throw new ArgumentNullException();
                sf = value;
            }
            get
            {
                return sf;
            }
        }

        public void Add(string link)
        {
            if (link == null)
                throw new NullReferenceException();

            links.Add(sf.WebString(link));
        }

        public string GetLink(int index)
        {
            return links[index];
        }
    }
}
