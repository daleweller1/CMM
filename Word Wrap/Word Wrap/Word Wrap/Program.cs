using System;
using System.Text;

namespace Word_Wrap
{
    public class Program
    {

        private readonly static string sampleString = StringContainer.sampleString;
        private readonly static string newLine = Environment.NewLine;

        public static void Main(string[] args)
        {
            var paragraphs = GetParagraphs(sampleString);

            foreach (var p in paragraphs)
            {
                string wrapped = WordWrap(p, 80);
                Console.Write(wrapped + newLine + newLine);
            };
        }

        public static string WordWrap(string s, int limit)
        {
            var sb = new StringBuilder();
            int currentLineLength = 0;
            s = s.Replace(newLine, " "); // Replace all unnecessary line breaks with spaces

            string[] words = s.Split(" ");

            foreach (var word in words)
            {
                if (word.Length > 0) // This lets the code ignore empty strings delimited by whitespace in a long blank string -- i.e., "             "
                {
                    if ((currentLineLength + word.Length + 1) > limit) // Won't fit next word
                    {
                        sb.Append(newLine);
                        currentLineLength = 0;
                    }

                    sb.Append(word + " ");
                    currentLineLength += word.Length + 1;
                }
            }

            sb.Remove(sb.Length - 1, 1); // Remove the trailing " " at the end of the string

            return sb.ToString();
        }

        public static string[] GetParagraphs(string s)
        {
            return s.Split(newLine + newLine);
        }
    }
}
