using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Ukagaka.NET.Events;

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
			catch (NullReferenceException)
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
			t.Add(@"\1\s[999]\0\s[999]お姉ちゃん、\_w[500]これはどう？\_w[1000]\1や、\_w[500]やめて、\_w[500]お願い…。\_w[1000]\0\n\n[half]じれったいなぁ。\_w[1000]ボクが優しく入れてあげるよ。\_w[1000]\1\n\n[half]だ、\_w[500]ダメ！\_w[500]そんな大きいの、\_w[500]入らない…！\_w[1500]\1\s[101]\0\s[2]\n\n[half]あれ？\_w[1000]%username、\_w[500]いたの？\_w[1000]\1\s[104]\n\n[half]%selfname、\_w[500]大きなファイルは分割して保存してるのよ。\_w[1000]無理に入れようとしないで。\e");
			t.Add(@"\1\s[100]\0\s[7]合言葉を言え！！\_w[1000]\1\s[104]意味もなく認証かけるんじゃないの。\e");
			t.Add(@"\1\s[100]\0\s[7]出たな！\_w[500]妖怪「文字化け」！\_w[1000]\1\s[104]%usernameじゃないの。\e");
			t.Add(@"\1\s[100]\0\s[7]誰だ！？\_w[1000]\s[4]\nなんだ、\_w[500]%usernameか。\_w[1000]\s[1]\nトップページから入ってきてよ。\_w[1000]\n\1\s[104]どこから入ろうが%usernameの勝手でしょ。\e");
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
			t.Add(@"\1\s[100]\0\s[5]%username、\_w[500]またね。\_w[500]\1\s[105]よい旅を。\_w[500]\-");
			t.Add(@"\1\s[100]\0\s[5]ネットは一日一時間！\_w[500]\1\s[104]短すぎない？\_w[500]\-");
			t.Add(@"\1\s[100]\0\s[7]バルス！\_w[500]\1\s[106]「閉じよ」の意。\_w[500]\-");
			t.Add(@"\1\s[100]\0\s[6]ボクは、\_w[500]集め続ける。\_w[500]\1\s[106]私は、\_w[500]守り続ける。\_w[500]\-");
			t.Add(@"\1\s[100]\0\s[6]Webは眠らない。\_w[500]\1\s[105]いつも、\_w[500]%usernameと共に。\_w[500]\-");
			t.Add(@"\1\s[100]\0\s[6]古きもの、\_w[500]我に知恵を授け給え。\_w[500]\1\s[105]新しきもの、\_w[500]彼に喜びを与え給え。\_w[500]\-");
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
			OnUserInput oo = new OnUserInput(this.s, this.header);
			Type t = oo.GetType();
			MethodInfo mi = t.GetMethod(this.reference(0));
			try
			{
				object o = mi.Invoke(oo, null);
				value = (string)o;
			}
			catch (NullReferenceException)
			{
			}
			return value;
		}
		public string OnKeyPress()
		{
			string value = "";
			OnKeyPress oo = new OnKeyPress(this.s, this.header);
			Type t = oo.GetType();
			MethodInfo mi = t.GetMethod(this.reference(0));
			try
			{
				object o = mi.Invoke(oo, null);
				value = (string)o;
			}
			catch (NullReferenceException)
			{
			}
			return value;
		}
		public string OnChoiceSelect()
		{
			string value = "";
			OnChoiceSelect oo = new OnChoiceSelect(this.s, this.header);
			Type t = oo.GetType();
			MethodInfo mi = t.GetMethod(this.reference(0));
			try
			{
				object o = mi.Invoke(oo, null);
				value = (string)o;
			}
			catch (NullReferenceException)
			{
			}
			return value;
		}
		public string OnChoiceSelectEx()
		{
			string value = "";
			OnChoiceSelectEx oo = new OnChoiceSelectEx(this.s, this.header);
			Type t = oo.GetType();
			MethodInfo mi = t.GetMethod(this.reference(1));
			try
			{
				object o = mi.Invoke(oo, null);
				value = (string)o;
			}
			catch (NullReferenceException)
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
				OnAnchorSelect oo = new OnAnchorSelect(this.s, this.header);
				Type t = oo.GetType();
				MethodInfo mi = t.GetMethod(this.reference(0));
				try
				{
					object o = mi.Invoke(oo, null);
					value = (string)o;
				}
				catch (NullReferenceException)
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
			OnMouseDoubleClick oo = new OnMouseDoubleClick(this.s, this.header);
			Type t = oo.GetType();
			MethodInfo mi;
			object o;
			mi = t.GetMethod("MouseDoubleClick" + this.reference(3) + this.reference(4));
			try
			{
				o = mi.Invoke(oo, null);
				value = (string)o;
			}
			catch (NullReferenceException)
			{
				mi = t.GetMethod("MouseDoubleClick" + this.reference(3));
				try
				{
					o = mi.Invoke(oo, null);
					value = (string)o;
				}
				catch (NullReferenceException)
				{
				}
			}
			return value;
		}
		public string OnMouseWheel()
		{
			if (this.referenceInt(3) != 0)
			{
				return "";
			}
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
					OnMouseMove oo = new OnMouseMove(this.s, this.header);
					Type t = oo.GetType();
					MethodInfo mi;
					object o;
					mi = t.GetMethod("MouseMove" + this.reference(3) + this.reference(4));
					try
					{
						o = mi.Invoke(oo, null);
						value = (string)o;
					}
					catch (NullReferenceException)
					{
						mi = t.GetMethod("MouseMove" + this.reference(3));
						try
						{
							o = mi.Invoke(oo, null);
							value = (string)o;
						}
						catch (NullReferenceException)
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
			string url = "http://www.google.com/images?q=" + Uri.EscapeUriString(this.reference(0));
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
			if (now.Hour % 2 == 0)
			{
				switch (now.Minute)
				{
					case 0:
						this.s.AiTalkCount = 0;
						value = @"\1\s[100]\0\s[0]" + now.Hour + @"時だ。\_w[500]巡回にいってくるね。\_w[500]\s[999]\_w[500]\1\s[105]いってらっしゃい。\e";
						break;
					case 3:
						string headlinename = "偽SiReFaSo";
						if (this.s.installedheadlinelist.Contains(headlinename))
						{
							value = @"\1\s[100]\0\s[0]更新状況だよ。\_w[500]\![execute,headline," + headlinename + @"]\e";
						}
						else
						{
							value = @"\1\s[100]\0\s[0]%username、\_w[500]\s[5]ボクのフィードを購読してみない？\n\n[half]\_w[500]\_q"
								+ AYATemplate.MenuItem("購読する", "InstallRSS", "https://nikolat.github.io/sirefaso/rss2.xml") + @"\n"
								+ AYATemplate.MenuItem("遠慮しとく", "Menu_CANCEL") + @"\e";
						}
						break;
					default:
						break;
				}
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
			t.Add(@"\1\s[100]\0\s[2]お姉ちゃん、\_w[500]このアクセスログみてみて。\_w[1000]\1\s[102]何これ、\_w[500]全部同じ所からじゃないの。\_w[1000]\0\s[5]\n\n[half]ボクのファンかな？\_w[1000]\1\s[104]\n\n[half]…攻撃受けてるわよ。\_w[1000]\0\s[2]\n\n[half]ええーーー！？\e");
			t.Add(@"\0\s[0]\1\s[103]うーん…\_w[500]…\_w[500]、\_w[500]ダメね。\_w[1000]\0\s[0]お姉ちゃん、\_w[500]ZIP開かないの？\_w[1000]\s[5]貸して。\_w[1000]\1\s[102]\n\n[half]%selfname。\_w[1000]\0\n\n[half]（パキッ）\_w[500]はい。\_w[1000]\1\s[101]\n\n[half]あ、\_w[500]ありがと…。\e");
			t.Add(@"\1\s[100]\0\s[5]ごめんくださーい！\_w[500]\nMozilla/4.0ですけどー！\_w[1000]\1\s[104]ウソはいけないわ。\e");
			t.Add(@"\1\s[100]\0\s[0]お姉ちゃん、\_w[500]NARが届いてるよ。\_w[1000]\1\s[102]…\_w[500]…\_w[500]！\_w[500]これは……。\_w[1000]\0\s[2]\n\n[half]カレンダープラグイン…？\_w[1000]\s[0]\nどうやって使うのこれ？\_w[1000]\1\s[103]\n\n[half]…見なかったことにしましょう。\_w[1000]\0\s[2]\n\n[half]え、\_w[500]何で！？\_w[1000]\nお姉ちゃん、\_w[500]カレンダーって何なの！？\e");
			t.Add(@"\1\s[100]\0\s[5]今月の検索ワードの集計が出たよー。\_w[1000]\1\s[105]どんな検索ワードが多いのかしら？\_w[1000]\0\s[1]\n\n[half]…\_w[500]…\_w[500]…\_w[500]。\_w[1000]\1\s[101]\n\n[half]…\_w[500]…\_w[500]…\_w[500]。\_w[1000]\0\s[3]\n\n[half]た、\_w[500]たくさんアクセスあって良かったね。\_w[1000]\1\s[104]\n\n[half]エッチなフレーズばっかり…。\e");
			t.Add(@"\1\s[100]\0\s[0]お姉ちゃん、\_w[500]クラウドって何？\_w[1000]\1\s[105]…雲よ。\_w[1000]\0\s[3]\n\n[half]そうじゃなくて\1\s[106]\n\n[half]雲なのよ。\e");
			t.Add(@"\0\s[0]\1\s[105]うふふ…、\_w[500]可愛いわね。\_w[1000]\0\s[0]お姉ちゃん、\_w[500]何見てるの？\_w[1000]\1\n\n[half]%selfnameが初めて書いたHTML覚えてる？\_w[1000]\0\s[7]\n\n[half]ちょ、\_w[500]ちょっと！\_w[1000]\n人のキャッシュ勝手に見ないで！\e");
			t.Add(@"\0\s[0]\1\s[107]%selfname！\_w[500]使ってないインスタンスは消しなさいって何度言えばわかるの！\_w[1000]\0\s[3]えー、\_w[500]そこまで節電しなくても…。\e");
			t.Add(@"\1\s[100]\0\s[5]あ、\_w[500]お姉ちゃん、\_w[500]脆弱性みーっけ！\_w[1000]\1\s[102]%selfname！\_w[1000]\s[101]\n%usernameの前で恥ずかしいからやめて…。\e");
			t.Add(@"\1\s[100]\0\s[0]お姉ちゃんの好きなタイプは？\_w[1000]\1\s[102]え、\_w[500]\s[101]急に言われても…。\_w[1000]\n%selfnameはどうなの？\_w[1000]\0\s[5]\n\n[half]ボクはやっぱりwebkitが好きだなー。\w[1000]\nレンダリングが綺麗だし。\_w[1000]\1\s[104]\n\n[half]何の話なの？\e");
			t.Add(@"\1\s[100]\0\s[3]あれー？\_w[500]引き出しが開かないよ…。\_w[1000]\1\s[100]DataStoreの障害みたいね。\_w[1000]\s[105]\nしばらく待ちましょう。\_w[1000]\0\s[7]\n\n[half]ダメだよ、\_w[500]みんな待たせてるのに！\w[1000]\n(バキッ)\w[1000]\s[2]\nあーーーーー！！！\_w[1000]\n取っ手が壊れたーーーーー！！！\_w[1000]\1\s[104]\n\n[half](何て馬鹿力なの…。)\e");
			t.Add(@"\1\s[100]\0\s[3]もっとダイエットしなきゃ…。\_w[1000]\1\s[102]%selfnameは十分細いじゃない。\_w[1000]\0\s[4]\n\n[half]スマートフォンに入りきらないんだよ…。\_w[1000]\1\s[104]\n\n[half]…厳しい時代よね。\e");
			t.Add(@"\0\s[0]\1\s[100]%selfnameは将来、\_w[500]どんなサイトになりたいの？\_w[1000]\0\s[2]え？\_w[500]えっと…、\_w[500]\s[8]た、たくさんの人のお役に立てるサイトになりたいな！\_w[1000]\1\s[105]\n\n[half]%selfnameならきっとなれるわ。\_w[1000]\nがんばってね。\_w[1000]\0\s[4]\n\n[half]（今のボクじゃまだまだダメってことですか…。）\e");
			t.Add(@"\0\s[0]\1\s[100]今月は転送量が厳しいわね…。\_w[1000]\0\s[2]あ、\_w[500]新しいサイト発見！\_w[1000]\s[5]\nどれどれ…。\_w[1000]\1\s[107]\n\n[half]そこ！\_w[1000]\n開けたら閉める！\_w[1000]\0\s[3]\n\n[half]ふえ！？\e");
			t.Add(@"\1\s[100]\0\s[4]こないだのスパム、\_w[500]またウロウロしてるよ…。\_w[1000]\1\s[106]隙を見せてはダメよ。\_w[1000]\s[107]\n特に%selfnameはセキュリティ意識が…。\_w[500]\0\s[2]\n\n[half]あれ？\_w[500]お姉ちゃん、\_w[500]背中に変な落書きが…。\_w[1000]\1\s[102]\n\n[half]キャー！\_w[500]何これ！\_w[500]消して！\_w[500]早く！\e");
			return t[(new Random()).Next(t.Count)];
		}
	}
}
