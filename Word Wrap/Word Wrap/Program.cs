using System;
using System.Text;

namespace WordWrap
{
    public class Program
    {

        private readonly static string sampleString = StringContainer.sampleString;
        private readonly static string newLine = Environment.NewLine;

        public static void Main(string[] args)
        {
            Console.Write(FullWordWrap(sampleString, 80));
        }

        // Handles multiple paragraphs in one string
        public static string FullWordWrap(string str, int limit)
        {
            var sb = new StringBuilder();
            var paragraphs = GetParagraphs(str);

            foreach (var p in paragraphs)
            {
                string wrapped = ParagraphWrap(p, limit);
                sb.Append(wrapped + newLine + newLine);
            };

            return sb.ToString().TrimEnd(); // Trim trailing whitespace
        }

        public static string[] GetParagraphs(string str)
        {
            return str.Split(newLine + newLine);
        }

        // Handles individual paragraphs
        public static string ParagraphWrap(string str, int limit)
        {
            var sb = new StringBuilder();
            int currentLineLength = 0;
            str = str.Replace(newLine, " "); // First, replace all existing line breaks with spaces

            string[] words = str.Split(" ");

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                string followingWord = (i < words.Length - 1) ? words[i + 1] : string.Empty;

                if (word.Length > 0) // This lets the code ignore empty strings delimited by whitespace in a long blank string -- i.e., "             "
                {
                    if ((currentLineLength + word.Length) > limit) // Won't fit the word
                    {
                        sb.Append(newLine + word + " ");
                        currentLineLength = word.Length + 1;
                    }
                    else if ((currentLineLength + word.Length + 1 + followingWord.Length) > limit) // Will fit the word, but not also a space and the following word
                    {
                        sb.Append(word + newLine);
                        currentLineLength = 0;
                    }
                    else // Will fit the word, a space, and the following word
                    {
                        sb.Append(word + " ");
                        currentLineLength += word.Length + 1;
                    }
                }
            }

            return sb.ToString().TrimEnd(); // Trim trailing whitespace
        }

    }
}
