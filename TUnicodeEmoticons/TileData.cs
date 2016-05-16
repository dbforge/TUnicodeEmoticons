using System.Collections.Generic;
using TUnicodeEmoticons.Infrastructure;

namespace TUnicodeEmoticons
{
    public class TileData : PropertyChangedBase
    {
        public TileData(string text, string toolTip)
        {
            Text = text;
            ToolTip = toolTip;
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        private string _toolTip;
        public string ToolTip
        {
            get { return _toolTip; }
            set
            {
                _toolTip = value;
                OnPropertyChanged();
            }
        }

        public static IEnumerable<TileData> Default
        {
            get
            {
                var tileDataList = new List<TileData>
                {
                    new TileData(@"◕‿◕", "smiling"),
                    new TileData(@"｡◕‿◕｡", "surprised and smiling"),
                    new TileData(@"｡◕‿‿◕｡", "smiling catface"),
                    new TileData(@"^̮^", "happy"),
                    new TileData(@"(◕‿◕)", "smiling"),
                    new TileData(@"(｡◕‿◕｡)", "surprised and smiling"),
                    new TileData(@"(｡◕‿‿◕｡)", "smiling catface"),
                    new TileData(@"(^̮^)", "happy"),
                    new TileData(@"ʘ‿ʘ", "smiling"),
                    new TileData(@"ಠ_ಠ", "[meme] look of disapproval"),
                    new TileData(@"ಠ⌣ಠ", "devious smile"),
                    new TileData(@"ಠ‿ಠ", "devious face"),
                    new TileData(@"(ʘ‿ʘ)", "smiling"),
                    new TileData(@"(ಠ_ಠ)", "look of disapproval"),
                    new TileData(@"(ಠ⌣ಠ)", "devious smile"),
                    new TileData(@"(ಠ‿ಠ)", "devious face"),
                    new TileData(@"♥‿♥", "enamored"),
                    new TileData(@"◔̯◔", "eye roll"),
                    new TileData(@"٩◔̯◔۶", "eye roll with hands up"),
                    new TileData(@"⊙﹏⊙", "worried"),
                    new TileData(@"Ƹ̵̡Ӝ̵̨̄Ʒ", "butterfly"),
                    new TileData(@"(･.◤)", "emo"),
                    new TileData(@"◕‿↼", "[japanese] wink"),
                    new TileData(@"(ಥ﹏ಥ)", "crying"),
                    new TileData(@"ლ(ಠ益ಠლ)", "raging"),
                    new TileData(@"﴾͡๏̯͡๏﴿ O'RLY?", "[meme] o'rly owl"),
                    new TileData(@"(ﾉ◕ヮ◕)ﾉ*:･ﾟ✧", "[japanese] throwing sparkles / gratz"),
                    new TileData(@"ლ,ᔑ•ﺪ͟͠•ᔐ.ლ", "angry mom / woman"),
                    new TileData(@"[̲̅$̲̅(̲̅5̲̅)̲̅$̲̅]", "money"),
                    new TileData(@"(づ｡◕‿‿◕｡)づ", "[japanese] hey / cheer up"),
                    new TileData(@"▄︻̷̿┻̿═━一", "sniper rifle"),
                    new TileData(@"(╯°□°）╯︵ ┻━┻", "[meme] angry, flipping the table"),
                    new TileData(@"┻━┻ ︵ヽ(`Д´)ﾉ︵ ┻━┻", "[meme] double table flip"),
                    new TileData(@"┬──┬ ノ( ゜-゜ノ)", "[meme] put table back"),
                    new TileData(@"(ノಠ益ಠ)ノ彡┻━┻", "[meme] raging, flipping the table"),
                    new TileData(@"（╯°□°）╯︵(\ .o.)\", "[meme] flip person"),
                    new TileData(@"┬─┬︵ /(.□. \）", "[meme] In Soviet Russia, table flips you"),
                    new TileData(@"╭∩╮(-_-)╭∩╮", "double middle finger"),
                    new TileData(@"凸(-_-)凸", "double middle finger"),
                    new TileData(@" ̿ ̿ ̿'̿'\̵͇̿̿\з=(•_•)=ε/̵͇̿̿/'̿'̿ ̿ ", "dual pistols"),
                    new TileData(@"⌐╦╦═─", "submachine gun"),
                    new TileData(@"(´・ω・)っ由", "here is a gift from me"),
                    new TileData(@"（´・ω・ `）", "[meme] [japanese] face with eyebrows"),
                    new TileData(@"(͡° ͜ʖ ͡°)", "[meme] le lenny face"),
                    new TileData(@"¯\_(ツ)_/¯", "[meme] shrug / smiling"),
                    new TileData(@"͡° ͜ʖ ͡°", "[meme] le meme face"),
                    new TileData(@"¯\(°_o)/¯", "[meme] shrug"),
                    new TileData(@"( ﾟヮﾟ)", "[japanese] happy / open mouth"),
                    new TileData(@"ヽ༼ຈل͜ຈ༽ﾉ", "raise your dongers!"),
                    new TileData(@"(︺︹︺)", "no smile"),
                    new TileData(@"(¬_¬)", "[japanese] tired / annoyed"),
                    new TileData(@"(；一_一)", "[japanese] shame"),
                    new TileData(@"(¬‿¬)", "[japanese] happy / dreaming"),
                    new TileData(@"(づ￣ ³￣)づ", "[japanese] want to kiss"),
                    new TileData(@"ب_ب", "serious / frown face"),
                    new TileData(@"(ಥ_ಥ)", "crying"),
                    new TileData(@"ʕ•ᴥ•ʔ", "bear"),
                    new TileData(@"°Д°", "[japanese] loud"),
                    new TileData(@"(ᵔᴥᵔ)", "[japanese] happy animal face"),
                    new TileData(@"(•ω•)", "[japanese] animal"),
                    new TileData(@"☜(⌒▽⌒)☞", "[japanese] angel"),
                    new TileData(@"〆(・∀・＠)", "[japanese] taking a memo"),
                    new TileData(@"◔ ⌣ ◔", "smiling eye roll"),
                    new TileData(@"ლ(´ڡ`ლ)", "very happy, licking lips"),
                    new TileData(@"ᕙ(⇀‸↼‶)ᕗ", "mighty"),
                    new TileData(@"ᄽὁȍ ̪ őὀᄿ", "spider")
                };
                return tileDataList;
            }
        }
    }
}