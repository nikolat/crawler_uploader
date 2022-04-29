using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ukagaka.NET
{
	class Resource : EventBase
	{
		public Resource(Shiori s, Dictionary<string, string> header) : base(s, header)
		{
		}

		public string MakeResponse()
		{
			string value = "";
			Type t = this.GetType();
			MethodInfo mi = t.GetMethod(this.header["ID"].Replace('.', '_'));
			try
			{
				object o = mi.Invoke(this, null);
				value = (string)o;
			}
			catch (NullReferenceException)
			{
			}
			return value;
		}

		// network update
		public string homeurl()
		{
			return "https://raw.githubusercontent.com/nikolat/crawler_uploader/master/";
		}
		public string useorigin1()
		{
			return "1";
		}
		// userinfo
		public string username()
		{
			return this.s.username;
		}
		// SHIORI info
		public string version()
		{
			return Shiori.SENDER + "/" + Shiori.SENDER_VERSION;
		}
		public string craftman()
		{
			return "setsuri";
		}
		public string craftmanw()
		{
			return "摂理";
		}
		public string name()
		{
			return "D.N.Proxy";
		}
		// visible custom
		public string portalrootbutton_visible()
		{
			return "1";
		}
		public string recommendrootbutton_visible()
		{
			return "1";
		}
		public string updatebutton_visible()
		{
			return "1";
		}
		public string vanishbutton_visible()
		{
			return "1";
		}
		// recommend sites
		public string sakura_portalsites()
		{
			string value = "";
			List<string[]> sites = new List<string[]>();
			sites.Add(new string[] { "Disc-2", "http://disc2.s56.xrea.com/", "disc_2.gif" });
			foreach (string[] site in sites)
			{
				value += string.Join("\x01", site) + "\x01\x02";
			}
			return value;
		}
		public string sakura_recommendsites()
		{
			string value = "";
			List<string[]> sites = new List<string[]>();
			sites.Add(new string[] { "偽SiReFaSo", "http://nikolat.starfree.jp/sirefaso/", "-" });
			sites.Add(new string[] { "偽SoSiReMi", "http://nikolat.starfree.jp/sosiremi/", "-" });
			sites.Add(new string[] { "-", "-", "-" });
			sites.Add(new string[] { "narをアップするところ", "http://narup.if.land.to/sr_data.cgi", "nar_up.pnr" });
			sites.Add(new string[] { "パン耳手帳", "", "viprpg.png" });
			foreach (string[] site in sites)
			{
				value += string.Join("\x01", site) + "\x01\x02";
			}
			return value;
		}
		public string kero_recommendsites()
		{
			string value = "";
			List<string[]> sites = new List<string[]>();
			sites.Add(new string[] { "MDN Web Docs", "https://developer.mozilla.org/en-US/", "-" });
			sites.Add(new string[] { "World Wide Web Consortium (W3C)", "http://www.w3.org/", "-" });
			sites.Add(new string[] { "-", "-", "-" });
			sites.Add(new string[] { "The Web KANZAKI", "http://www.kanzaki.com/", "-" });
			foreach (string[] site in sites)
			{
				value += string.Join("\x01", site) + "\x01\x02";
			}
			return value;
		}
		// balloon tooltip
		public string balloon_tooltip()
		{
			string value = "";
			if (Regex.IsMatch(this.reference(1), "^https?://"))
			{
				value = this.reference(1);
			}
			else if (this.reference(1).CompareTo("GOYAUTIL_InstallCallWithC") == 0)
			{
				value = "Call Ghost";
			}
			return value;
		}
	}
}
