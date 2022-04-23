using System;
using System.Collections.Generic;

namespace Ukagaka.NET.Events
{
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
			t.Add(@"\1\s[100]\0\s[9]ちょっと！\_w[500]データは見るだけにしてくれないかな！\e");
			t.Add(@"\1\s[100]\0\s[9]な、\_w[200]なんかマウスさばきがいやらしいよ、\_w[500]%username！\e");
			t.Add(@"\1\s[100]\0\s[3]期待してるページは無いと思うよ？\e");
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
			t.Add(@"\0\s[0]\1\s[103]…もう少し大きいほうがアクセシビリティ的によろしいでしょうか。\_w[1000]\0\s[7]そんな必要ないから！\e");
			t.Add(@"\0\s[0]\1\s[101]…ダウンロードしますか？\_w[1000]\0\s[2]何を！？\e");
			t.Add(@"\0\s[0]\1\s[101]こういった操作がお好きなのですか？\e");
			t.Add(@"\0\s[0]\1\s[103]他所のサイトでも同じ事を？\e");
			t.Add(@"\0\s[0]\1\s[101]ここから先は、\_w[500]秘密のパスワードを…\e");
			return t[(new Random()).Next(t.Count)];
		}
	}
}
