using NUnit.Framework;
using swxben.helpers.StringExtensions;
using Shouldly;

namespace swxben.helpers.tests.StringExtensionsTests
{
    [TestFixture]
    public class HtmlEncodeExtensionTests
    {
        [Test]
        public void ampersand()
        {
            "one & two".HtmlEncode().ShouldBe("one &amp; two");
        }

        [Test]
        public void and_back()
        {
            "one &amp; two".HtmlDecode().ShouldBe("one & two");
        }
    }
}
