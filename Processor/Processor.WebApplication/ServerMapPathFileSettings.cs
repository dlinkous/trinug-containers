using System;
using System.Web;
using Processor.IO.File;

namespace Processor.WebApplication
{
	internal class ServerMapPathFileSettings : IFileSettings
	{
		public string RootPath
		{
			get
			{
				return HttpContext.Current.Server.MapPath("~/");
			}
		}
	}
}