using NUnit.Framework;
using Shouldly;
using swxben.helpers.StringExtensions;

namespace swxben.helpers.tests.StringExtensionsTests
{
    [TestFixture]
    public class HashSHA256ExtensionTests
    {
        [Test]
        public void string_is_hashed()
        {
            "password".HashSHA256().ShouldBe("XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg=");
        }

        [Test]
        public void empty_string_is_hashed()
        {
            "".HashSHA256().ShouldBe("47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=");
        }

        [Test]
        public void null_string_is_treated_as_empty_string()
        {
            HashSHA256Extension.HashSHA256(default(string)).ShouldBe("47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=");
        }
    }
}
