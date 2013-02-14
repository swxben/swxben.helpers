using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace swxben.helpers.Cli
{
    public class CommandLineOptions
    {
        readonly string[] _args;

        public CommandLineOptions(string[] args)
        {
            _args = args;
        }

        public bool CheckOption(string option)
        {
            var check = GetCheck(option);
            var checkWithArg = GetCheckWithArg(option);

            return _args
                .Select(a => a.ToLower())
                .Any(a => a == check || a.StartsWith(checkWithArg));
        }

        public string GetOptionValue(string option)
        {
            var checkWithArg = GetCheckWithArg(option);
            return _args
                .Where(s => s.ToLower().StartsWith(checkWithArg))
                .Select(s => s.Remove(0, checkWithArg.Length))
                .Select(s => s.Trim('"', '\''))
                .FirstOrDefault();
        }

        string GetCheck(string option) { return string.Format("--{0}", option.ToLower()); }
        string GetCheckWithArg(string option) { return string.Format("--{0}=", option.ToLower()); }
    }
}
