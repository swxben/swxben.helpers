using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using swxben.helpers.StringExtensions;
using Shouldly;

namespace swxben.helpers.tests.StringExtensionsTests
{
    [TestFixture]
    public class SafeReplaceExtensionTests
    {
        [Test]
        public void null_returns_null()
        {
            string s = null;
            s.SafeReplace("a", "b").ShouldBe(null);
            s.SafeReplace('a', 'b').ShouldBe(null);
        }

        [Test]
        public void replaces_on_non_null()
        {
            string s = "abcd";
            s.SafeReplace("a", "b").ShouldBe("bbcd");
            s.SafeReplace('a', 'b').ShouldBe("bbcd");
        }
    }
}
