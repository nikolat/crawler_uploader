using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ukagaka.NET
{
	class Event : EventBase
	{
		public Event(Shiori s, Dictionary<string, string> header) : base(s, header)
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
			catch (System.NullReferenceException)
			{
			}
			return value;
		}

		// boot events
		public string OnFirstBoot()
		{
			string value = @"\1\s[999]\v\0\s[999]\vやっとメンテ終わったよー。\_w[1000]\1今回は長かったわね。\_w[1000]"
				+ @"\0\s[0]\n\n[half]やあ、\_w[500]%username。\_w[1000]\s[5]お待たせ。\_w[1000]\1\s[100]\n\n[half]ご不便をおかけ致しました。\_w[1000]"
				+ @"\n\s[101]またご利用頂けて嬉しいです。\_w[1000]\0\s[0]\n\n[half]さて、\_w[500]またはりきって巡回してこようかな。\e";
			return value;
		}
		public string OnBoot()
		{
			List<string> t = new List<string>();
			t.Add(@"\1\s[100]\0\s[7]このブラウザを作ったのは誰だぁー！！\_w[1000]\1\s[104]落ち着きなさい。\e");
			t.Add(@"\1\s[100]\0\s[7]リクエストを受けたなら！！\_w[500]\1\s[107]１秒以内のレスポンス！！\e");
			t.Add(@"\1\s[100]\0\s[5]やあ、\_w[500]%username。\_w[1000]\1\s[105]ごきげんうるわしゅう。\e");
			t.Add(@"\1\s[100]\0\s[2]あ、\_w[500]%username。\_w[500]\s[5]リファラ見せてよ。\_w[1000]\1\s[104]お行儀が悪いわよ。\e");
			t.Add(@"\1\s[100]\0\s[5]このクッキーおいしいね。\_w[500]\s[0]%usernameも食べる？\_w[1000]\1\s[103]…あとでブラウザから削除しておいてくださいね。\e");
			return t[(new Random()).Next(t.Count)];
		}
		public string OnShellChanging()
		{
			List<string> t = new List<string>();
			t.Add(@"\1\s[100]\0\s[0]リニューアル？\_w[500]\e");
			t.Add(@"\1\s[100]\0\s[5]スタイルシートを変えるよ。\_w[500]\e");
			return t[(new Random()).Next(t.Count)];
		}
		public string OnShellChanged()
		{
			List<string> t = new List<string>();
			t.Add(@"\1\s[100]\0\s[0]これはまた斬新なデザインだね。\e");
			t.Add(@"\1\s[100]\0\s[5]どう？\_w[500]%username。\_w[1000]\1\s[103]表示崩れはございませんか？\e");
			return t[(new Random()).Next(t.Count)];
		}
		public string OnBalloonChange()
		{
			return @"\1\s[100]\0\s[0]\_qChanged to """ + this.sReference(0) + "\".";
		}
		public string OnWindowStateRestore()
		{
			List<string> t = new List<string>();
			t.Add(@"\1\s[105]\0\s[5]\_sdisplay: block;\e");
			return t[(new Random()).Next(t.Count)];
		}
		public string OnGhostChanging()
		{
			List<string> t = new List<string>();
			if (this.reference(0).CompareTo(this.s.sakura_name) == 0)
			{
				t.Add(@"\1\s[107]\0\s[7]\_sスーパーリロード！！\_w[500]\e");
			}
			else
			{
				t.Add(@"\1\s[100]\0\s[5]リンク先に飛ばすよー。\_w[500]\s[7]そぉい！！\_w[500]\e");
				t.Add(@"\1\s[100]\0\s[0]" + this.sReference(0) + @"のページだね。\_w[500]\s[5]まかせて。\_w[500]\e");
			}
			return t[(new Random()).Next(t.Count)];
		}
		public string OnGhostChanged()
		{
			List<string> t = new List<string>();
			if (this.reference(0).CompareTo(this.s.sakura_name) == 0)
			{
				t.Add(@"\1\s[100]\0\s[5]最新の状態だよ。\_w[500]\1\s[105]ブラウザキャッシュのお掃除はおまかせください。\e");
			}
			else
			{
				t.Add(@"\1\s[100]\0\s[2]あっ。\_w[500]\s[5]被リンク増えた！\_w[1000]\1\s[103]%selfname、\_w[500]はしたないわよ。\e");
				t.Add(@"\0\s[0]\1\s[106]\_qreferrer: " + this.sReference(0) + @"\nuser agent: " + this.s.baseware_name + "/" + this.s.baseware_version + @"\_q\_w[1000]\0\s[4]お姉ちゃん、\_w[500]%usernameだよ。\_w[1000]\1\s[102]\n\n[half]し、\_w[200]失礼致しました。\_w[1000]\n\s[105]ご訪問ありがとうございます。\e");
				t.Add(this.OnBoot());
			}
			return t[(new Random()).Next(t.Count)];
		}
		public string OnGhostCalled()
		{
			List<string> t = new List<string>();
			t.Add(@"\1\s[100]\0\s[7]インラインフレームで呼び出すとは何様のつもりだ！！\_w[1000]\1\s[104]脅かすんじゃないの。\_w[500]\n\s[105]気にしないでね、\_w[500]" + this.sReference(0) + @"。\e");
			t.Add(@"\1\s[100]\0\s[4]ちょっとタブ開きすぎじゃないの？\_w[500]%username。\e");
			t.Add(this.OnBoot());
			return t[(new Random()).Next(t.Count)];
		}
		public string OnClose()
		{
			List<string> t = new List<string>();
			t.Add(@"\1\s[100]\0\s[0]サーバー落とすよー。\_w[500]\1\s[102]落としちゃだめ！\_w[500]\-");
			t.Add(@"\1\s[106]\0\s[6]\_sdisplay: none;\_w[500]\-");
			t.Add(@"\1\s[105]\0\s[5]%username、\_w[500]またね。\_w[500]\1\s[105]よい旅を。\_w[500]\-");
			return t[(new Random()).Next(t.Count)];
		}
		public string OnCloseAll()
		{
			return "";
		}
		// vanish event
		public string OnVanished()
		{
			return "";
		}
		// URLdrop event
		public string OnURLDropping()
		{
			string value = @"\1\s[100]\0\s[0]\_qDropping from:\n"
				+ this.sReference(0) + @"\e";
			return value;
		}
		public string OnURLDropped()
		{
			string value = @"\1\s[100]\0\s[0]\_qDropped to:\n"
				+ this.sReference(0) + @"\e";
			return value;
		}
		// file making event
		public string OnUpdatedataCreating()
		{
			string value = @"\1\s[100]\0\s[0]\_qCreating updates2.dau\e";
			return value;
		}
		public string OnUpdatedataCreated()
		{
			string value = @"\1\s[100]\0\s[0]\_qComplite.\e";
			return value;
		}
		public string OnNarCreating()
		{
			string value = @"\1\s[100]\0\s[0]\_qCreateing NAR\e";
			return value;
		}
		public string OnNarCreated()
		{
			string value = @"\1\s[100]\0\s[0]\_q「" + this.sReference(0)
				+ @"」／「" + this.sReference(1) + @"」 created so far.\e";
			return value;
		}
		// update event
		public string OnUpdateBegin()
		{
			List<string> t = new List<string>();
			t.Add(@"\1\s[100]\0\s[6]メンテあるかな？\e");
			t.Add(@"\1\s[100]\0\s[0]サーバと同期をとるよ。\e");
			return t[(new Random()).Next(t.Count)];
		}
		public string OnUpdateReady()
		{
			string value = @"\1\s[100]\0\s[6]" + this.referenceInt(0) + @"個のpatchをあてるよ。\e";
			return value;
		}
		public string OnUpdateComplete()
		{
			List<string> t = new List<string>();
			if (this.reference(0).CompareTo("none") == 0)
			{
				t.Add(@"\1\s[100]\0\s[6]\_qHTTP/1.1 304 Not Modified\e");
				t.Add(@"\1\s[100]\0\s[3]更新はないみたい。\_w[500]\1\s[105]安定なのは良いことよ。\e");
			}
			else
			{
				t.Add(@"\1\s[100]\0\s[5]体が軽くなった気がする！\_w[500]\1\s[103]中身は薄くならないでね？\e");
				t.Add(@"\1\s[100]\0\s[5]メンテ終了。\e");
			}
			return t[(new Random()).Next(t.Count)];
		}
		public string OnUpdateFailure()
		{
			string value = @"\1\s[100]\0\s[4]\_q" + this.sReference(0) + @"\e";
			return value;
		}
		public string OnUpdateOtherBegin()
		{
			string value = @"\1\s[100]\0\s[6]\_qUpdate " + this.sReference(3) + @" Begin.\e";
			return value;
		}
		public string OnUpdateOtherReady()
		{
			string value = @"\1\s[100]\0\s[6]\_qUpdating...\e";
			return value;
		}
		public string OnUpdateOtherComplete()
		{
			string value = @"\1\s[100]\0\s[6]\_q" + this.sReference(0) + @"\e";
			return value;
		}
		public string OnUpdateOtherFailure()
		{
			string value = @"\1\s[100]\0\s[6]\_q" + this.sReference(0) + @"\e";
			return value;
		}
		// mail check event
		public string OnBIFFBegin()
		{
			string value = @"\1\s[100]\0\s[0]\_qBIFF begin.\e";
			return value;
		}
		public string OnBIFFComplete()
		{
			string value = "";
			if (this.referenceInt(0) == 0)
			{
				value = "Not new.";
			}
			else if (this.referenceInt(0) > 0)
			{
				value = this.sReference(0) + @" mail come to your mailbox.\n\n[half]";
				value += AYATemplate.MenuItem("open mailer", "OpenMailer") + @"\n";
				value += AYATemplate.MenuItem("calcel", "Menu_CANCEL");
			}
			value = @"\1\s[100]\0\s[0]\_q" + value + @"\e";
			return value;
		}
		public string OnBIFFFailure()
		{
			string value = @"\1\s[100]\0\s[0]\_q" + this.sReference(0) + @"\e";
			return value;
		}
		// headlinesense event
		public string OnHeadlinesenseBegin()
		{
			string value = @"\1\s[100]\0\s[0]\_q" + this.sReference(0) + @" Headline...\_q\e";
			return value;
		}
		public string OnHeadlinesenseComplete()
		{
			string value = @"\1\s[100]\0\s[0]\_q" + this.sReference(0) + @"\e";
			return value;
		}
		public string OnHeadlinesenseFailure()
		{
			string value = @"\1\s[100]\0\s[0]\_qFailure. " + this.sReference(0) + @"\e";
			return value;
		}
		public string OnHeadlinesense_OnFind()
		{
			string value;
			value = @"■" + this.sReference(0) + @"\_q\n\n[half]\_n";
			value += this.sReference(3) + @"\_n\n[half]\_q";
			if (Regex.IsMatch(this.reference(2), "^(First|Next)$"))
			{
				value += @"\![*]\q[" + AYATemplate.MakeJustText("next page",46) + ",]\n";
			}
			value += AYATemplate.MenuItem("open browser", this.reference(1)) + @"\n";
			value += AYATemplate.MenuItem("cancel", "Menu_CANCEL");
			value = @"\1\s[100]\0\b[2]\s[0]\_q" + value + @"\e";
			return value;
		}
		public string OnRSSBegin()
		{
			string value = @"\1\s[100]\0\s[0]\_q" + this.sReference(0) + @" RSS...\e";
			return value;
		}
		public string OnRSSComplete()
		{
			string value;
			value = @"■" + this.sReference(0) + @"\n\n[half]\_n";
			for (int i = 2; i < this.referenceCount(); i++)
			{
				if (i >= 22)
				{
					value += @"and more...\n";
					break;
				}
				string[] _r = this.reference(i).Split('\u0001');
				string title = _r.Length > 0 ? _r[0] : "";
				string url = _r.Length > 1 ? _r[1] : "";
				string date = _r.Length > 2 ? _r[2] : "";
				if (Regex.IsMatch(title, @"(^AD:)|(^PR:)|(\[ *PR *\])"))
				{
					continue;
				}
				string content = title;
				if (date.CompareTo("") != 0)
				{
					string[] _datea = date.Split(',');
					string month = _datea.Length > 1 ? _datea[1] : "";
					string day = _datea.Length > 2 ? _datea[2] : "";
					content = "[" + month + "/" + day + "]" + title;
				}
				value += @"\_a[" + url + @"]"
					+ SHIORI3FW.EscapeAllTags(AYATemplate.MakeJustText(content, 46))
					+ @"\_a\n";
			}
			value += @"\_n\n\n[half]";
			value += AYATemplate.MenuItem("open browser", this.reference(1)) + @"\n";
			value += AYATemplate.MenuItem("cancel", "Menu_CANCEL");
			value = @"\![set,choicetimeout,-1]\![set,balloontimeout,-1]\1\s[100]\0\b[2]\s[0]\_q" + value + @"\e";
			return value;
		}
		public string OnRSSFailure()
		{
			string value = @"\1\s[100]\0\s[0]\_qFailure. " + this.sReference(0) + @"\e";
			return value;
		}
		// SNTP event
		public string OnSNTPBegin()
		{
			string value = @"\1\s[100]\0\s[0]\_qSNTPBegin.\e";
			return value;
		}
		public string OnSNTPCompare()
		{
			string value = @"\1\s[100]\0\s[0]\_q"
				+ "before " + AYATemplate.SNTPCompare_StrForm(this.reference(2)) + @"\n"
				+ "after  " + AYATemplate.SNTPCompare_StrForm(this.reference(1)) + @"\n\n"
				+ @"\6Complete.\e";
			return value;
		}
		public string OnSNTPFailure()
		{
			string value = @"\1\s[100]\0\s[0]\_qFailure.\e";
			return value;
		}
		// install event
		public string OnInstallBegin()
		{
			string value = @"\1\s[100]\0\s[6]\_qInstall...\e";
			return value;
		}
		public string OnInstallComplete()
		{
			string value = "「" + this.sReference(1)
				+ "」/「" + this.sReference(0) + "」installed." ;
			string id = Regex.Split(this.reference(0), " with")[0];
			if (Regex.IsMatch(id, "ghost|shell|balloon"))
			{
				value += @"\n\n";
				value += AYATemplate.MenuItem("change", "GOYAUTIL_InstallChange", "lastinstalled", id) + @"\n";
				if (id.CompareTo("ghost") == 0)
				{
					value += AYATemplate.MenuItem("call", "GOYAUTIL_InstallCall", "lastinstalled") + @"\n";
				}
				value += AYATemplate.MenuItem("hold", "Menu_CANCEL");
			}
			value = @"\1\s[100]\0\s[0]\_q" + value + @"\e";
			return value;
		}
		public string OnInstallFailure()
		{
			string value = @"\1\s[100]\0\s[0]\_qInstall Failure.\e";
			return value;
		}
		public string OnInstallRefuse()
		{
			string sakuraname = this.reference(0);
			string value = "Refused. " + SHIORI3FW.EscapeAllTags(sakuraname) + "'s archive.";
			if (!this.s.ghostexlist.Contains(sakuraname))	// 同時起動していない時
			{
				value += @"\n\n";
				value += AYATemplate.MenuItem("change", "GOYAUTIL_InstallChange", sakuraname, "ghost") + @"\n";
				value += AYATemplate.MenuItem("call", "GOYAUTIL_InstallCall", sakuraname) + @"\n";
				value += AYATemplate.MenuItem("hold", "Menu_CANCEL");
			}
			value = @"\1\s[100]\0\s[0]\_q" + value + @"\e";
			return value;
		}
		// UI event
		public string OnUserInput()
		{
			string value = "";
			Ukagaka.NET.OnUserInput oo = new Ukagaka.NET.OnUserInput(this.s, this.header);
			Type t = oo.GetType();
			MethodInfo mi = t.GetMethod(this.reference(0));
			try
			{
				object o = mi.Invoke(oo, null);
				value = (string)o;
			}
			catch (System.NullReferenceException)
			{
			}
			return value;
		}
		public string OnKeyPress()
		{
			string value = "";
			Ukagaka.NET.OnKeyPress oo = new Ukagaka.NET.OnKeyPress(this.s, this.header);
			Type t = oo.GetType();
			MethodInfo mi = t.GetMethod(this.reference(0));
			try
			{
				object o = mi.Invoke(oo, null);
				value = (string)o;
			}
			catch (System.NullReferenceException)
			{
			}
			return value;
		}
		public string OnChoiceSelect()
		{
			string value = "";
			Ukagaka.NET.OnChoiceSelect oo = new Ukagaka.NET.OnChoiceSelect(this.s, this.header);
			Type t = oo.GetType();
			MethodInfo mi = t.GetMethod(this.reference(0));
			try
			{
				object o = mi.Invoke(oo, null);
				value = (string)o;
			}
			catch (System.NullReferenceException)
			{
			}
			return value;
		}
		public string OnChoiceSelectEx()
		{
			string value = "";
			Ukagaka.NET.OnChoiceSelectEx oo = new Ukagaka.NET.OnChoiceSelectEx(this.s, this.header);
			Type t = oo.GetType();
			MethodInfo mi = t.GetMethod(this.reference(1));
			try
			{
				object o = mi.Invoke(oo, null);
				value = (string)o;
			}
			catch (System.NullReferenceException)
			{
			}
			return value;
		}
		public string OnChoiceTimeout()
		{
			string value = @"\1\s[100]\0\s[0]\e";
			return value;
		}
		public string OnAnchorSelect()
		{
			string value = "";
			String id = this.reference(0);
			if (Regex.IsMatch(id, "^https?://"))
			{
				value = @"\C\![open,browser," + AYATemplate.EscapeText(id) + @"]\e";
			}
			else
			{
				Ukagaka.NET.OnAnchorSelect oo = new Ukagaka.NET.OnAnchorSelect(this.s, this.header);
				Type t = oo.GetType();
				MethodInfo mi = t.GetMethod(this.reference(0));
				try
				{
					object o = mi.Invoke(oo, null);
					value = (string)o;
				}
				catch (System.NullReferenceException)
				{
				}
			}
			return value;
		}
		// communicate event
		public string OnCommunicate()
		{
			return "";
		}
		// mouse event
		public string OnMouseDoubleClick()
		{
			string value = "";
			Ukagaka.NET.OnMouseDoubleClick oo = new Ukagaka.NET.OnMouseDoubleClick(this.s, this.header);
			Type t = oo.GetType();
			MethodInfo mi;
			object o;
			mi = t.GetMethod("MouseDoubleClick" + this.reference(3) + this.reference(4));
			try
			{
				o = mi.Invoke(oo, null);
				value = (string)o;
			}
			catch (System.NullReferenceException)
			{
				mi = t.GetMethod("MouseDoubleClick" + this.reference(3));
				try
				{
					o = mi.Invoke(oo, null);
					value = (string)o;
				}
				catch (System.NullReferenceException)
				{
				}
			}
			return value;
		}
		public string OnMouseWheel()
		{
			string value;
			int aitalkinterval = this.s.aitalkinterval;
			if ((this.referenceInt(2) > 0) && (aitalkinterval < 360))
			{
				aitalkinterval += 10;
			}
			else if ((this.referenceInt(2) < 0) && (aitalkinterval > 0))
			{
				aitalkinterval -= 10;
			}
			else
			{
				return "";
			}
			this.s.aitalkinterval = aitalkinterval;
			value = @"\_l[90,20]喋り間隔：\_l[150,]" + aitalkinterval.ToString().PadLeft(3, ' ') + @"\_l[170,]秒";
			if (this.s.aitalkinterval == 0)
			{
				value += @" \f[color,255,0,0]沈黙\f[color,default]";
			}
			value += @"\_l[35,35]0 ";
			for (int i = 1; i < 36; i++)
			{
				value += @"\_l[" + (i * 5 + 45).ToString() + @",]―";
			}
			value += " 360";
			value += @"\_l[" + (aitalkinterval / 2 + 45).ToString() + @",35]｜";
			value = @"\C\c\1\b[-1]\0\_q" + value + @"\e";
			return value;
		}
		public string OnMouseMove()
		{
			string value = "";
			int threshold = 50;
			int side;
			if (!int.TryParse(this.reference(3), out side))
			{
				side = -1;
			}
			if (this.s.strokeid.ContainsKey(side) && this.s.strokeid[side].CompareTo(this.reference(4)) == 0)
			{
				this.s.stroke[side]++;
				if (this.s.stroke[side] > threshold)
				{
					this.s.stroke[side] = 0;
					Ukagaka.NET.OnMouseMove oo = new Ukagaka.NET.OnMouseMove(this.s, this.header);
					Type t = oo.GetType();
					MethodInfo mi;
					object o;
					mi = t.GetMethod("MouseMove" + this.reference(3) + this.reference(4));
					try
					{
						o = mi.Invoke(oo, null);
						value = (string)o;
					}
					catch (System.NullReferenceException)
					{
						mi = t.GetMethod("MouseMove" + this.reference(3));
						try
						{
							o = mi.Invoke(oo, null);
							value = (string)o;
						}
						catch (System.NullReferenceException)
						{
						}
					}
				}
			}
			else
			{
				this.s.stroke[side] = 0;
				this.s.strokeid[side] = this.reference(4);
			}
			return value;
		}
		// file drop event
		public string OnFileDrop2()
		{
			return "";
		}
		// plugin event
		public string OnBeerShower()
		{
			return @"\1\s[100]\0\s[6]\_qHTTP/1.1 403 Forbidden\e";
		}
		public string OnDive()
		{
			string url = "http://www.google.com/images?q=" + this.reference(0);
			return @"\1\s[100]\0\s[7]とうっ！！\![open,browser," + AYATemplate.EscapeText(url) + "]";
		}
		public string OnHitThunder()
		{
			return @"\1\s[100]\0\s[2]うわああああ！！！\_w[500]\s[999]\_w[1000]\1\s[102]%selfname、\_w[500]大丈夫！？\_w[1000]\0\n\n[half]\_qHTTP/1.1 500 Internal Server Error\_q\_w[1000]\1\s[104]\n\n[half]大丈夫じゃないみたいね…。";
		}
		// battery notice event
		public string OnBatteryLow()
		{
			return @"\0\s[0]\1\s[103]%username、\_w[500]バッテリーは大丈夫でしょうか？\_w[500]\0\s[5]充電はこまめにね。\e";
		}
		public string OnBatteryCritical()
		{
			return @"\0\s[0]\1\s[103]%username、\_w[500]バッテリーが残り少ないようですが…。\e";
		}
		// network status event
		public string OnNetworkStatusChange()
		{
			return "";
		}
		// time event
		public string OnSurfaceRestore()
		{
			return "";
		}
		public string OnMinuteChange()
		{
			string value = "";
			DateTime now = DateTime.Now;
			if (now.Minute == 0)
			{
				this.s.AiTalkCount = 0;
				value = @"\1\s[100]\0\s[0]" + now.Hour	+ @"時だ。\_w[500]巡回にいってくるね。\_w[500]\s[999]\_w[500]\1\s[105]いってらっしゃい。\e";
			}
			return value;
		}
		public string OnSecondChange()
		{
			string value = "";
			if (this.s.aitalkinterval > 0)
			{
				this.s.AiTalkCount++;
				if (this.s.AiTalkCount >= this.s.aitalkinterval)
				{
					this.s.AiTalkCount = 0;
					value = UserDictionary.RandomTalk();
				}
			}
			return value;
		}
	}

	class OnUserInput : EventBase
	{
		public OnUserInput(Shiori s, Dictionary<string, string> header) : base(s, header)
		{
		}
	}
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
	}
	class OnAnchorSelect : EventBase
	{
		public OnAnchorSelect(Shiori s, Dictionary<string, string> header) : base(s, header)
		{
		}
	}
	class OnMouseDoubleClick : EventBase
	{
		public OnMouseDoubleClick(Shiori s, Dictionary<string, string> header) : base(s, header)
		{
		}

		public string MouseDoubleClick0()
		{
			//string value;
			//value = @"■メニュー\n\n";
			//value += AYATemplate.MenuItem("何か話して", "Menu_TALK") + @"\n\n";
			//value += AYATemplate.MenuItem("キャンセル", "Menu_CANCEL");
			//value = @"\1\s[100]\0\s[0]\_q" + value + @"\e";
			//return value;
			this.s.AiTalkCount = 0;
			return UserDictionary.RandomTalk();
		}
		public string MouseDoubleClick0Head()
		{
			List<string> t = new List<string>();
			t.Add(@"\1\s[100]\0\s[7]そこはボタンじゃない！\e");
			t.Add(@"\1\s[100]\0\s[7]F5連打はダメ！\e");
			t.Add(@"\1\s[100]\0\s[9]API叩くときはもっと優しくお願い。\e");
			return t[(new Random()).Next(t.Count)];
		}
		public string MouseDoubleClick0Face()
		{
			List<string> t = new List<string>();
			t.Add(@"\1\s[100]\0\s[5]思わずクリックしたくなるぷにぷにお肌！\_w[1000]\1\s[105]完璧なアフォーダンスね。\e");
			t.Add(@"\1\s[100]\0\s[5]きれいなマークアップでしょ？\_w[1000]\1\s[105]機械可読性は大切よね。\e");
			t.Add(@"\1\s[100]\0\s[0]画像はあまり使ってないよ。\_w[1000]\1\s[100]CSSだけでもだいぶオシャレが楽しめるものね。\e");
			return t[(new Random()).Next(t.Count)];
		}
		public string MouseDoubleClick0Bust()
		{
			List<string> t = new List<string>();
			t.Add(@"\1\s[100]\0\s[2]わわ、\_w[500]何するんだ！\_w[1000]\1\s[108]ボタンクリック時のエフェクトを確認してるんですよね。\_w[1000]\n\n[half]\0\s[7]\n\n[half]そういう問題じゃない！\e");
			t.Add(@"\1\s[100]\0\s[1]な…、\_w[500]何？\_w[1000]\1\s[105]クリック率を上げる施策の効果じゃない？\_w[1000]\0\s[7]\n\n[half]そんな施策いらない！\e");
			t.Add(@"\1\s[100]\0\s[3]ちょ、\_w[500]ちょっと、\_w[500]%username、\_w[500]\nそのページはまだ準備が…。\e");
			return t[(new Random()).Next(t.Count)];
		}
		public string MouseDoubleClick1()
		{
			this.s.AiTalkCount = 0;
			return UserDictionary.RandomTalk();
		}
		public string MouseDoubleClick1Head()
		{
			List<string> t = new List<string>();
			t.Add(@"\0\s[0]\1\s[104]HEADも叩き過ぎは過負荷の元です。\e");
			t.Add(@"\0\s[0]\1\s[106]ヘッダのロゴはトップへのリンクと決まっているのです。\e");
			t.Add(@"\0\s[0]\1\s[103]この髪では圧縮効率が悪いですか？\e");
			return t[(new Random()).Next(t.Count)];
		}
		public string MouseDoubleClick1Face()
		{
			List<string> t = new List<string>();
			t.Add(@"\0\s[0]\1\s[105]表示崩れには気をつけています。\e");
			t.Add(@"\0\s[0]\1\s[106]過剰な装飾は好きではありませんので…。\e");
			t.Add(@"\0\s[0]\1\s[101]この配色、\_w[500]%usernameのお気に召しますでしょうか…。\e");
			return t[(new Random()).Next(t.Count)];
		}
		public string MouseDoubleClick1Bust()
		{
			List<string> t = new List<string>();
			t.Add(@"\0\s[0]\1\s[102]っ！\_w[1000]\n\s[103]…\_w[1500]\s[101]\_q HTTP/1.1 200 OK (///)\_q\_w[1000]\0\s[2]受理しちゃうの！？");
			t.Add(@"\0\s[0]\1\s[101]…%usernameがアクセスしたいと仰るなら、\_w[500]私…。\e");
			t.Add(@"\0\s[0]\1\s[101]ま、\_w[500]まだメンテナンスの時間では…。\e");
			return t[(new Random()).Next(t.Count)];
		}
	}
	class OnMouseMove : EventBase
	{
		public OnMouseMove(Shiori s, Dictionary<string, string> header) : base(s, header)
		{
		}

		public string MouseMove0()
		{
			return "";
		}
		public string MouseMove0Head()
		{
			List<string> t = new List<string>();
			t.Add(@"\1\s[100]\0\s[5]えへへー。\e");
			t.Add(@"\1\s[100]\0\s[5]ボクが出来る子だから褒めてくれてるの？\e");
			t.Add(@"\1\s[100]\0\s[6]おだてても巡回は決まった時間以外はしないよ。\_w[1000]\1\s[105]他所のサーバーにご迷惑にならないよう、\_w[500]配慮が必要だものね。\e");
			return t[(new Random()).Next(t.Count)];
		}
		public string MouseMove0Face()
		{
			List<string> t = new List<string>();
			t.Add(@"\1\s[100]\0\s[2]ボクの顔に何か付いてる？\e");
			t.Add(@"\1\s[100]\0\s[4]スタイルシートがはがれちゃうよー。\e");
			t.Add(@"\1\s[100]\0\s[5]リキッドでしょ。\_w[500]自慢のレイアウトなんだ。\e");
			return t[(new Random()).Next(t.Count)];
		}
		public string MouseMove0Bust()
		{
			List<string> t = new List<string>();
			t.Add(@"\1\s[100]\0\s[7]ぼ、\_w[200]ボクのセキュリティは堅いんだからねっ！\_w[1000]\1\s[108]本当に？\_w[1000]\0\s[2]\n\n[half]きゃっ！\_w[500]\s[1]そ、\_w[500]そこはダメ…！\_w[1000]\1\s[105]\n\n[half]うふふ。\e");
			t.Add(@"\1\s[100]\0\s[3]おかしなアクセス繰り返したら、\_w[500]IPごと弾いちゃうからね？\e");
			t.Add(@"\1\s[100]\0\s[9]言ってくれればナビゲーションするから！\_w[500]\n何も隠してないから！\e");
			return t[(new Random()).Next(t.Count)];
		}
		public string MouseMove1()
		{
			return "";
		}
		public string MouseMove1Head()
		{
			List<string> t = new List<string>();
			t.Add(@"\0\s[0]\1\s[106]ん…。\e");
			t.Add(@"\0\s[0]\1\s[101]%username…。\e");
			t.Add(@"\0\s[0]\1\s[101]ど、\_w[500]どうぞごゆるりと…。\e");
			return t[(new Random()).Next(t.Count)];
		}
		public string MouseMove1Face()
		{
			List<string> t = new List<string>();
			t.Add(@"\0\s[0]\1\s[103]は、\_w[500]恥ずかしいので…、\_w[500]素のHTMLをそんなに見つめないでください…。\e");
			t.Add(@"\0\s[0]\1\s[103]な、\_w[500]何かお探しでしたら、\_w[500]検索をお手伝いしますが…。\e");
			t.Add(@"\0\s[0]\1\s[105]隠しテキストなどございません。\e");
			return t[(new Random()).Next(t.Count)];
		}
		public string MouseMove1Bust()
		{
			List<string> t = new List<string>();
			t.Add(@"\0\s[0]\1\s[101]あ、\_w[500]あの、\_w[500]そういうことは暗号化された通信でこっそりと…。\_w[1000]\0\s[2]何をするつもりなの！？\e");
			t.Add(@"\0\s[0]\1\s[103]…もう少し大きいほうがアクセシビリティ的によろしいでしょうか。\_w[1000]\0\s[7]そんな必要ない！\e");
			t.Add(@"\0\s[0]\1\s[101]…ダウンロードしますか？\_w[1000]\0\s[2]何を！？\e");
			return t[(new Random()).Next(t.Count)];
		}
	}

	class UserDictionary
	{
		public static string RandomTalk()
		{
			List<string> t = new List<string>();
			t.Add(@"\1\s[100]\0\s[2]いやーーー！！！\_w[500]検索順位下がってるーーー！！！\_w[1000]\1\s[103]%selfname、\_w[500]そんなに露出しなくても…。\_w[1000]\0\s[7]\n\n[half]いやだよ！\_w[500]もっとみんなに見て欲しいんだもん！\e");
			t.Add(@"\0\s[0]\1\s[103]%selfname、\_w[500]あなた最近デザインが派手すぎない？\_w[1000]\0\s[5]何言ってるのお姉ちゃん、\_w[500]今流行ってるんだよこういうの。\_w[1000]\1\s[103]\n\n[half]こんなCSSどこで覚えてきたのかしら…。\e");
			t.Add(@"\0\s[0]\1\s[102]イベントの前日は更新の問い合わせが多いわね…。\_w[1000]\0\s[5]ボクたちも大忙しだね。\e");
			t.Add(@"\1\s[100]\0\s[2]あ！\_w[500]Googlebot！\_w[1000]\s[6]\n検索順位が上がりますように…。\_w[1000]\1\s[104]流れ星じゃないのよ。\e");
			t.Add(@"\0\s[0]\1\s[103]これはどこにしまおうかしら…。\_w[1000]\0\s[0]更新ファイルを整理してるの？\_w[1000]\1\s[105]\n\n[half]リクエストが来たら早く取り出せるように、\_w[500]インデックスしてるのよ。\e");
			return t[(new Random()).Next(t.Count)];
		}
	}
}
