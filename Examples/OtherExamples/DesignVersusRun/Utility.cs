using System;

namespace OtherExamples.DesignVersusRun
{
	internal class Utility
	{
		private readonly IDatabase database = null;
		private readonly IFileSystem fileSystem = null;
		private readonly IWebApi webApi = null;
		private readonly IMathUtilities mathUtilities = null;

		internal void Dependencies_Decided_At_Design_Time()
		{
			database.Backup();
			fileSystem.Save("/", "Call me Ishmael.");
			webApi.PostNews("Things are looking up!");
			var result = mathUtilities.CalculateMagicNumber(99);
		}

		internal void Objects_Decided_At_Run_Time()
		{
			var numbers = new byte[] { 1, 2, 3 };
			var anonymous = new { Id = 1001, Name = "Ishmael" };
			var customer = new Customer() { Id = 1001, Name = "Ishmael" };
		}
	}
}
