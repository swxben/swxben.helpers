swxben.helpers
==============

C#/.NET helpers - mostly extension methods. Some are based on Ruby methods, some are ripped from PHP's bad practices.


## Installation
Install via [NuGet](http://nuget.org/packages/swxben.helpers), either in Visual Studio (right-click project, Manage NuGet Packages, search for `swxben.helpers`) or via the package manager console using `Install-Package swxben.helpers`.


## Usage


### swxben.helpers.Cli

#### CommandLineOptions

Helps parse simple command line options of the form `--OptionName`, optionally `--OptionName=value`. Can either be used standalone or by subclassing to encapsulate a program's command line options. Option names are **case insensitive**, so `--OptionName` and `--optionname` are equivalent.

    static void Main(string[] args)
    {
        var options = new CommandLineOptions(args);
        var debug = options.CheckOption("debug");
        var name = options.GetOptionValue("name");
    }
    // could be called like: foo.exe --debug --name="I am Foo"

    // or via subclassing:
    class FooOptions : CommandLineOptions
    {
        public bool Debug{ get { return CheckOption("debug"); }
        public string Name { get { return GetOptionValue("name"); }

        public FooOptions(string[] args) : base(args) {}
    }
    static void Main(string[] args)
    {
        var options = new FooOptions(args);
        var debug = options.Debug;
        var name = options.Name;
    }

`GetOptionValue()` returns null if the value is not provided, so for example a configuration could be selected on the command line using the following:

    class FooOptions : CommandLineOptions
    {
        public IConfiguration Configuration { get; private set; }
        public FooOptions(string[] args) : base(args)
        {
            Configuration= = (GetOptionValue("configuration") ?? "live") == live ?
                (IConfiguration)new LiveConfiguration() :
                (IConfiguration)new DevelopmentConfiguration();
        }
    }
    // ""foo.exe --configuration=live" or "foo.exe" with no arguments runs with the live configuration,
    // while "foo --configuration=bar" defaults to the development configuration

Double and single quotes are also stripped from the start and end of the argument value:

    new CommandLineOptions(new[] { "--foo=\"test\""}).GetOptionValue("foo") == "test"


### swxben.helpers.DecimalExtensions


#### FormatCompact

Formats a decimal to _at least_ the specified precision - default is 2 decimal places. It doesn't limit or round to the specified precision. It will show the larger of (as much precision as required OR the specified precision).

    0.123456m.FormatCompact() == "0.123456"
    0.123m.FormatCompact() == "0.123"
    0.123m.FormatCompact(6) == "0.123000"
    0.0m.FormatCompact(6) == "0.000000"
    0.0m.FormatCompact(0) == "0"
    0.1m.FormatCompact(0) == "0.1"
    100.0m.FormatCompact() == "100.00"
    100.0m.FormatCompact(0) == "100"


### swxben.helpers.ObjectExtensions

#### IsNullOrDefault

Returns boolean `true` if the value of type `T` is null or equal to `default(T)`.

    1.23m.IsNullOrDefault.ShouldBe(false);
    new Foo().IsNullOrDefault().ShouldBe(false);
    0.0m.IsNullOrDefault().ShouldBe(true);
    default(int).IsNullOrDefault().ShouldBe(true);
    Foo foo = null; foo.IsNullOrDefault().ShouldBe(true);


### swxben.helpers.StringExtensions


#### EncodeEmailAddress

Randomly encodes an email address using HTML entities, similar to how Markdown automatically encodes an email address. The `mailto:` prefix should be included.

	"mailto:helloworld@swxben.com".EncodeEmailAddress() == "&#109;&#97;&#x69;l&#116;o&#x3a;&#x68;&#101;&#x6c;&#108;&#x6f;&#119;&#111;&#114;&#108;&#100;&#64;&#115;&#x77;&#x78;&#x62;&#x65;&#110;&#46;&#x63;&#x6f;&#109;"


#### HashSHA256

Hashes a string using SHA256. Null strings are treated as empty strings.

	"password".HashSHA256() == "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg="
	"".HashSHA256() == "47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU="
	default(string).HashSHA256() == "47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU="


#### HtmlEncode / HtmlDecode

Wraps `System.Net.HttpUtility`.

    "one & two".HtmlEncode() == "one &amp; two"
    "one &amp; two".HtmlDecode() == "one & two"


#### Humanise / Humanize

Takes an `underscore_separated` or `PascalCaseNotation` string and converts it to a generally human readable string, maintaining capitalisation with special exceptions for "a", "and", "as", "for", "to", "in" and "from".

    "one_two_three_four_and_five".Humanise() == "one two three four and five"
    "OneTwoThreeFourAndFive".Humanise() == "One Two Three Four and Five"


#### HumanJoin

Joins an array of strings into a comma separated list with 'and' used between the penultimate and ultimate items.

	(new[]{"one", "two", "three"}).HumanJoin() == "one, two and three"


#### Left

Returns the first _count_ characters. If _count_ is greater than the length of the string the entire string is returned.

    "abcdefg".Left(4) == "abcd"
    "abc".Left(10) == "abc"


#### Lines

Reads a string line by line via an `IEnumerable<string>` (using `StringReader(s).ReadLine()`). This is similar to [Ruby's String.lines method](http://www.ruby-doc.org/core-1.9.3/String.html#method-i-lines).

    "one\rtwo\r\nthree".Lines() == new[] { "one", "two", "three" }


#### MakeFileNameSafe

Removes invalid characters from a string to make it a valid file name (within reason).

    "invalid<>file\name.txt".MakeFileNameSafe() == "invalidfilename.txt"


#### nl2br

Like PHP's `nl2br()` core method. Replaces `Environment.NewLine` with `"<br/>"`.


#### SentenceCase / ToSentenceCase

Takes an `underscore_separated` or `PascalCaseNotation` string and converts it to `A Quite Naive Sentence Cased String`.

    "one_two_three_four_and_five".SentenceCase() == "One Two Three Four And Five"
    "OneTwoThreeFourAndFive".SentenceCase() == "One Two Three Four And Five"


## Contribute

If you want to contribute to this project, start by forking the repo: <https://github.com/swxben/swxben.helpers>. Create an issue if applicable, create a branch in your fork, and create a pull request when it's ready. Thanks!

### Contributors


## Licenses

All files [CC BY-SA 3.0](http://creativecommons.org/licenses/by-sa/3.0/) unless otherwise specified.

### Third party licenses

Third party libraries or resources have been included in this project under their respective licenses.
