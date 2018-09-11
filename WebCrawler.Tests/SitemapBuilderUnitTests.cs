using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using WebCrawler.Interfaces;
using WebCrawler.Services;
using Xunit;

namespace WebCrawler.Tests
{
    public class SiteMapBuilderUnitTests
    {
        // Fix test so mocked Parser returns different links
        /*
        [Fact]
        public async Task BuildSiteMap_WhenParentAndChildPagesAreFound_ReturnsSiteMapWithLinksFrom2Pages()
        {
            const string url = "ttps://hirespace.com/";

            const string htmlParentString = @"<html>
                <body>
                    <a href='http://www.internalsite.com/link1.html'>link 1</a>
                    <a href='http://www.internalsite.com/link2.html'>link 2</a>
                </body>
            </html>";

            var links = new List<string>
            {
                "Link1",
                "Link2"
            };


            var mockHtmlParser = Mock.Of<IHtmlParser>();
            Mock.Get(mockHtmlParser).Setup(h => h.GetValidLinks(It.IsAny<string>(), It.IsAny<string>())).Returns(links);

            var mockHtmlFetcher = Mock.Of<IHtmlFetcher>();
            Mock.Get(mockHtmlFetcher).Setup(h => h.GetHtmlStringAsync(It.IsAny<string>())).ReturnsAsync(htmlParentString);

            var builder = new SiteMapBuilder(mockHtmlParser, mockHtmlFetcher);

            var results = await builder.BuildSiteMap(url);

            results.Count().Should().Be(3);
        }
        */
    }

}
