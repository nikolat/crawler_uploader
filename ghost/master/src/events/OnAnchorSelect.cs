using System;
using System.Collections.Generic;

namespace Ukagaka.NET.Events
{
	class OnAnchorSelect : EventBase
	{
		public OnAnchorSelect(Shiori s, Dictionary<string, string> header) : base(s, header)
		{
		}
	}
}
