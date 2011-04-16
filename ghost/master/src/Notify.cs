using System;
using System.Reflection;
using System.Collections.Generic;

namespace Ukagaka.NET
{
	class Notify : EventBase
	{
		public Notify(Shiori s, Dictionary<string, string> header) : base(s, header)
		{
		}

		public void ReceiveEvent()
		{
			string callid = this.header["ID"].Replace('.', '_');
			if (!callid.StartsWith("On"))
				callid = "On_" + callid;
			Type t = this.GetType();
			MethodInfo mi = t.GetMethod(callid);
			try
			{
				mi.Invoke(this, null);
			}
			catch (System.NullReferenceException)
			{
			}
		}

		public void OnNotifySelfInfo()
		{
			this.s.sakura_name = this.reference(1);
		}
		public void On_basewareversion()
		{
			this.s.baseware_version = this.reference(0);
			this.s.baseware_name = this.reference(1);
		}
		public void On_hwnd()
		{
			this.s.hwnd = (IntPtr)int.Parse(this.reference(0).Split('\x01')[0]);
		}
		public void On_uniqueid()
		{
			this.s.uniqueID = this.reference(0);
		}
		public void On_otherghostname()
		{
			this.s.ghostexlist = new List<string>();
			foreach (string r in this._reference)
			{
				this.s.ghostexlist.Add(r.Split('\u0001')[0]);
			}
		}
		public void On_installedghostname()
		{
			this.s.installedghostlist = new List<string>(this._reference);
		}
	}
}
