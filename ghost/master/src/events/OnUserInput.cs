using System;
using System.Collections.Generic;

namespace Ukagaka.NET.Events
{
	class OnUserInput : EventBase
	{
		public OnUserInput(Shiori s, Dictionary<string, string> header) : base(s, header)
		{
		}
	}
}
