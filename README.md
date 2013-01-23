swxben.helpers
==============

C#/.NET helpers - mostly extension methods


## Installation
Install via [NuGet](http://nuget.org/packages/swxben.helpers), either in Visual Studio (right-click project, Manage NuGet Packages, search for `swxben.helpers`) or via the package manager console using `Install-Package swxben.helpers`.


## Usage


### swxben.helpers.StringExtensions


#### HashSHA256

Hashes a string using SHA256. Null strings are treated as empty strings.

	"password".HashSHA256() == "XohImNooBHFR0OVvjcYpJ3NgPQ1qq73WKhHvch0VQtg="
	"".HashSHA256() == "47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU="
	default(string).HashSHA256() == "47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU="


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


#### SentenceCase / ToSentenceCase

Takes an `underscore_separated` or `PascalCaseNotation` string and converts it to `A Quite Naive Sentence Cased String`.

    "one_two_three_four_and_five".SentenceCase() == "One Two Three Four And Five"
    "OneTwoThreeFourAndFive".SentenceCase() == "One Two Three Four And Five"


### swxben.helpers.DecimalExtensions


#### FormatCompact

Formats a decimal to at least the specified precision (default is 2 decimal places).

    0.123456m.FormatCompact() == "0.123456"
    0.123m.FormatCompact() == "0.123"
    0.123m.FormatCompact(6) == "0.123000"
    0.0m.FormatCompact(6) == "0.000000"
    0.0m.FormatCompact(0) == "0"
    0.1m.FormatCompact(0) == "0.1"
    100.0m.FormatCompact() == "100.00"
    100.0m.FormatCompact(0) == "100"


## Contribute

If you want to contribute to this project, start by forking the repo: <https://github.com/swxben/swxben.helpers>. Create an issue if applicable, create a branch in your fork, and create a pull request when it's ready. Thanks!

### Contributors


## Licenses

All files [CC BY-SA 3.0](http://creativecommons.org/licenses/by-sa/3.0/) unless otherwise specified.

### Third party licenses

Third party libraries or resources have been included in this project under their respective licenses.
