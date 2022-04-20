using System;

namespace Lab2
{
    class StringFormatter
    {
        public string WebString(string s)
        {
            if (s == null)
                throw new NullReferenceException();

            if (s.EndsWith(".git"))
                s = "git://" + s;

            if (!s.Contains("://"))
                s = "http://" + s;

            return s;
        }
    }
}
