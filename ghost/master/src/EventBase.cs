using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections;

namespace Ukagaka.NET
{
	class EventBase
	{
		protected Dictionary<string, string> header;
		protected List<string> _reference;
		protected Shiori s;

		public EventBase(Shiori s, Dictionary<string, string> header)
		{
			this.s = s;
			this.header = header;
			int i = 0;
			this._reference = new List<string>();
			while (header.ContainsKey("Reference" + i.ToString()))
			{
				this._reference.Add(header["Reference" + i.ToString()]);
				i++;
			}
		}

		protected string reference(int i)
		{
			string v = "";
			if (this._reference.Count > i)
			{
				v = this._reference[i];
			}
			return v;
		}

		protected string sReference(int i)
		{
			return SHIORI3FW.EscapeAllTags(this.reference(i));
		}

		protected int referenceInt(int i)
		{
			int v;
			string r = this.reference(i);
			if (!int.TryParse(r, out v))
			{
				v = -1;
			}
			return v;
		}

		protected int referenceCount()
		{
			return this._reference.Count;
		}
	}

	class AYATemplate
	{
		private static int MENU_TEXT_WIDTH = 46;

		public static string MenuItem(string text, params string[] args)
		{
			string r = @"\![*]\__q[";
			int i = 0;
			foreach (string arg in args)
			{
				if (i > 0) r += ",";
				r += AYATemplate.EscapeText(arg);
				i++;
			}
			r += "]" + AYATemplate.MakeJustText(text, MENU_TEXT_WIDTH) + @"\__q";
			return r;
		}

		public static string EscapeText(string text)
		{
			string r = text;
			if (Regex.IsMatch(text, @"[""\[\]]"))
			{
				r = "\"" + text.Replace("\"", "\"\"") + "\"";
			}
			return r;
		}

		public static string MakeLongText(string text, int size)
		{
			string r = text;
			int len = size - System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(text);
			if (len > 0)
			{
				r = text + "".PadRight(len / 2, '　') + "".PadRight(len % 2, ' ');
			}
			return r;
		}

		public static string MakeShortText(string text, int size)
		{
			int num = size / 2;
			int len = text.Length;
			if (num >= len)
			{
				return text;
			}
			int lendiff;
			string _text;
			while (true)
			{
				_text = text.Substring(0, num);
				lendiff = System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(_text) - size + 1;
				if (lendiff >= 0)
				{
					break;
				}
				num++;
				if (num >= len)
				{
					break;
				}
			}
			if (num >= len)
			{
				return text;
			}
			else
			{
				_text = text.Substring(0, num - 1);
				if (lendiff > 0)
				{
					_text += "..";
				}
				else
				{
					_text += "...";
				}
				return _text;
			}
		}

		public static string MakeJustText(string text, int size)
		{
			string _text = AYATemplate.MakeLongText(text, size);
			if (_text.CompareTo(text) != 0)
			{
				return _text;
			}
			return AYATemplate.MakeShortText(text, size);
		}

		public static string SNTPCompare_StrForm(string text)
		{
			string r = "";
			Regex reg = new Regex(@"^(\d+),(\d+),(\d+),(\d+),(\d+),(\d+),", RegexOptions.IgnoreCase | RegexOptions.Singleline);
			MatchCollection mc = reg.Matches(text);
			foreach (Match m in mc)
			{
				r = m.Groups[1].Value.PadLeft(4, '0') + "-"
					+ m.Groups[2].Value.PadLeft(2, '0') + "-"
					+ m.Groups[3].Value.PadLeft(2, '0') + " "
					+ m.Groups[4].Value.PadLeft(2, '0') + ":"
					+ m.Groups[5].Value.PadLeft(2, '0') + ":"
					+ m.Groups[6].Value.PadLeft(2, '0');
			}
			return r;
		}
	}

	class SHIORI3FW
	{
		public static string EscapeAllTags(string text)
		{
			const string ESCAPE_TAG1 = "\x03\x03";
			const string ESCAPE_TAG2 = "\x04\x04";
			string r = text;
			r = r.Replace(@"\\", ESCAPE_TAG1);
			r = r.Replace(@"\%", ESCAPE_TAG2);
			r = r.Replace(@"\", @"\\");
			r = r.Replace(@"%", @"\%");
			r = r.Replace(ESCAPE_TAG2, @"\%");
			r = r.Replace(ESCAPE_TAG1, @"\\");
			return r;
		}
	}
}
