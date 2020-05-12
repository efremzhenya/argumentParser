using System;
using System.Text.RegularExpressions;

namespace EnvironmentParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(parseArgument("asfaslhkahs {env.DOCKER_HOST} jkfhkjha {env.SomeVariable} skjh{env.USERNAME}faj"));
        }
        public static string parseArgument(string input) 
        {
            return string.IsNullOrEmpty(input) ? "" :
                Regex.Replace(input, @"{env\.\w+}", new MatchEvaluator(GetEnvironmentValue));
        }

        private static string GetEnvironmentValue(Match match)
        {
            var variable = match.Value.Remove(match.Value.Length - 1, 1).Remove(0, 5);
            return Environment.GetEnvironmentVariable(variable) ?? match.Value;
        }
    }
}
