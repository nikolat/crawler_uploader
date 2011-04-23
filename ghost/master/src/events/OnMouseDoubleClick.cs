using System;
using System.Collections.Generic;

namespace Ukagaka.NET.Events
{
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
			t.Add(@"\1\s[100]\0\s[7]そこはボタンじゃないから！\e");
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
			t.Add(@"\1\s[100]\0\s[2]わわ、\_w[500]何するんだ！\_w[1000]\1\s[108]ボタンクリック時のエフェクトを確認してるんですよね。\_w[1000]\n\n[half]\0\s[7]\n\n[half]そういう問題じゃないから！\e");
			t.Add(@"\1\s[100]\0\s[1]な…、\_w[500]何？\_w[1000]\1\s[105]クリック率を上げる施策の効果じゃない？\_w[1000]\0\s[7]\n\n[half]そんな施策いらないから！\e");
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
}
