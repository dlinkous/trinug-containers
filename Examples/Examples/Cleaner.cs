using System;
using System.Linq;

namespace Examples
{
	internal class Cleaner : ICleaner
	{
		private readonly ILogger logger;

		public Cleaner(ILogger logger)
		{
			this.logger = logger;
		}

		public string CleanWhitespace(string input)
		{
			logger.Log($"Before: '{input}'");
			var cleaned = new string(input.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
			logger.Log($"After: '{cleaned}'");
			return cleaned;
		}
	}
}
