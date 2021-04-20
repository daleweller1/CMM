using System;
using Xunit;

namespace WordWrap.Tests
{
    public class WordWrapTests
    {
        [Fact]
        public void OverEightyCharacters()
        {
            // Arrange
            string s = "This string has more than eighty characters. You'll find that this string has one hundred characters";
            string expected =
@"This string has more than eighty characters. You'll find that this string has
one hundred characters";

            // Act
            string actual = Program.ParagraphWrap(s, 80);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UnderEightyCharacters()
        {
            // Arrange
            string s = "This string has thirty-nine characters.";
            string expected = s;

            // Act
            string actual = Program.ParagraphWrap(s, 80);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoParagraphs_OneUnderEightyOneOverEighty()
        {
            // Arrange
            string s =
@"This paragraph should not get a line break.

This paragraph should definitely get a line break. This paragraph needs a line break. It is far too long to not have a line break. Actually, it should have two line breaks.";

            string expected =
@"This paragraph should not get a line break.

This paragraph should definitely get a line break. This paragraph needs a line
break. It is far too long to not have a line break. Actually, it should have two
line breaks.";

            // Act
            string actual = Program.FullWordWrap(s, 80);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhitespaceReturnsEmptyString()
        {
            // Arrange
            string s =
@"               
                             
          ";
            string expected = string.Empty;

            // Act
            string actual = Program.ParagraphWrap(s, 80);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetThreeParagraphs()
        {
            // Arrange
            string s =
@"One paragraph

Two paragraphs

Three paragraphs";

            string[] expected = { "One paragraph", "Two paragraphs", "Three paragraphs" };

            // Act
            string[] actual = Program.GetParagraphs(s);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
