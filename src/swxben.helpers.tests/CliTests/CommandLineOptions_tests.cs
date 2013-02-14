using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using swxben.helpers.Cli;
using Shouldly;

namespace swxben.helpers.tests.Cli
{
    [TestFixture]
    class CommandLineOptions_tests
    {
        [Test]
        public void check_option_works()
        {
            var options = new CommandLineOptions(new[]{"", "vasdc", "--eesf", "--FOO", "--bar", "--test=abc"});
            options.CheckOption("foo").ShouldBe(true);
            options.CheckOption("BAR").ShouldBe(true);
            options.CheckOption("baaramewe").ShouldBe(false);
            options.CheckOption("test").ShouldBe(true);
        }

        [Test]
        public void get_option_value_works()
        {
            var options = new CommandLineOptions(new[] { "", "vasdc", "--eesf", "--FOO=\"one 'two' three\"", "--bar", "--test=abc", "--test2='one \"two\" three'" });
            options.GetOptionValue("xxx").ShouldBe(null);
            options.GetOptionValue("bar").ShouldBe(null);
            options.GetOptionValue("test").ShouldBe("abc");
            options.GetOptionValue("foo").ShouldBe("one 'two' three");
            options.GetOptionValue("test2").ShouldBe("one \"two\" three");
        }
    }
}
