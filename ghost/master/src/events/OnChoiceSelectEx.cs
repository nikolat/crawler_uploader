using System;
using System.Collections.Generic;

namespace Ukagaka.NET.Events
{
	class OnChoiceSelectEx : EventBase
	{
		public OnChoiceSelectEx(Shiori s, Dictionary<string, string> header) : base(s, header)
		{
		}

		public string GOYAUTIL_InstallChange()
		{
			return @"\![change," + AYATemplate.EscapeText(this.reference(3)) + "," + AYATemplate.EscapeText(this.reference(2)) + "]";
		}
		public string GOYAUTIL_InstallCall()
		{
			return @"\![call,ghost," + AYATemplate.EscapeText(this.reference(2)) + "]";
		}
		public string InstallRSS()
		{
			return @"\![execute,install,url," + AYATemplate.EscapeText(this.reference(2)) + @",feed]\e";
		}
	}
}
