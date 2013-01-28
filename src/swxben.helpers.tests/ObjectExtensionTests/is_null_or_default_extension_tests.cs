using NUnit.Framework;
using Shouldly;
using swxben.helpers.ObjectExtensions;

namespace swxben.helpers.tests.ObjectExtensionTests
{
    [TestFixture]
    class is_null_or_default_extension_tests
    {
        class Foo { public string Bar { get; set; } }

        [Test]
        public void false_for_non_default_value_type()
        {
            1.23m.IsNullOrDefault().ShouldBe(false);
        }

        [Test]
        public void false_for_non_null_reference_type()
        {
            new Foo().IsNullOrDefault().ShouldBe(false);
        }

        [Test]
        public void true_for_default_value_type()
        {
            0.0m.IsNullOrDefault().ShouldBe(true);
        }

        [Test]
        public void true_for_explicitly_default_value_type()
        {
            default(int).IsNullOrDefault().ShouldBe(true);
        }

        [Test]
        public void true_for_null_reference_type()
        {
            Foo foo = null;
            foo.IsNullOrDefault().ShouldBe(true);
        }
    }
}
