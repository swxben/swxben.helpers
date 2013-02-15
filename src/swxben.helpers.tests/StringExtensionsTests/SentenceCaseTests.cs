using NUnit.Framework;
using Shouldly;
using swxben.helpers.StringExtensions;

namespace swxben.helpers.tests.StringExtensionsTests
{
    [TestFixture]
    public class SentenceCaseTests
    {
        [Test]
        public void works_pascal_case()
        {
            "OneTwoThree".SentenceCase().ShouldBe("One two three");
        }

        [Test]
        public void works_camel_case()
        {
            "oneTwoThree".SentenceCase().ShouldBe("One two three");
        }

        [Test]
        public void works_underscored()
        {
            "one_two_three".SentenceCase().ShouldBe("One two three");
        }
    }
}
