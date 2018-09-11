using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace WebCrawler.Tests
{
    public class HtmlParserUnitTests
    {
        [Fact]
        public void GetValidLinks_WhenHtmlStringIsPassed_ReturnsListOfInternalLinks()
        {
            // Arrange
            const string htmlString = @"<html>
                <body>
                    <a href='http://www.internalsite.com/link1.html'>link 1</a>
                    <a href='http://www.internalsite.com/link2.html'>link 2</a>
                    <a href='http://www.internalsite.com/link3.html'>link 3</a>
                    <a href='http://www.externalsite.com/link3.html'>link 4</a>
                    <a href='http://www.externalsite.com/link3.html'>link 5</a>
                </body>
            </html>";

            var htmlParser = new HtmlParser();
            
            // Act
            var result = htmlParser.GetValidLinks("internalsite.com", htmlString);
            
            // Assert
            result.Count().Should().Be(3);
        }

        [Fact]
        public void GetValidLinks_WhenHtmlStringIsPassedWithNestedLinks_ReturnsListOfInternalLinks()
        {
            // Arrange
            const string htmlString = @"<html>
                <body>
                    <div>
                        <a href='http://www.internalsite.com/link1.html'>link 1</a>
                        <a href='http://www.internalsite.com/link2.html'>link 2</a>
                        <a href='http://www.internalsite.com/link3.html'>link 3</a>
                        <a href='http://www.externalsite.com/link3.html'>link 4</a>
                        <a href='http://www.externalsite.com/link3.html'>link 5</a>
                    </div>
                </body>
            </html>";

            var htmlParser = new HtmlParser();

            // Act
            var result = htmlParser.GetValidLinks("internalsite.com", htmlString);

            // Assert
            result.Count().Should().Be(3);
        }
    }
}
