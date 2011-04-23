using System;
using System.Collections.Generic;

namespace Ukagaka.NET.Events
{
	class OnChoiceSelect : EventBase
	{
		public OnChoiceSelect(Shiori s, Dictionary<string, string> header) : base(s, header)
		{
		}

		public string Menu_CANCEL()
		{
			return @"\1\s[100]\0\s[0]\e";
		}
		public string Menu_TALK()
		{
			this.s.AiTalkCount = 0;
			return UserDictionary.RandomTalk();
		}
		public string OpenMailer()
		{
			return @"\![open,mailer]";
		}
	}
}
