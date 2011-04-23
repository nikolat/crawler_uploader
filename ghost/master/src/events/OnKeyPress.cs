using System;
using System.Collections.Generic;

namespace Ukagaka.NET.Events
{
	class OnKeyPress : EventBase
	{
		public OnKeyPress(Shiori s, Dictionary<string, string> header) : base(s, header)
		{
		}

		public string r()
		{
			return @"\![reload,shiori]\1\s[100]\0\s[0]リロードしたよ。\e";
		}
		public string t()
		{
			this.s.AiTalkCount = 0;
			return UserDictionary.RandomTalk();
		}
	}
}
