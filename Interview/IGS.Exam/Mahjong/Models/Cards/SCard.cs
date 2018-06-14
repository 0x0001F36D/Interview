// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D
namespace Interview.IGS.Exam.Mahjong.Models.Cards
{
    using System.Collections.Generic;

    internal class SCard : Card
    {
        #region Constructors

        internal SCard(int gid, int value) : base(gid, CardType.風向及花牌, value)
        {
        }

        #endregion Constructors

        #region Fields

        protected override IReadOnlyDictionary<int, string> RelationMap { get; } = new Dictionary<int, string>
        {
            [1] = "東風",
            [2] = "南風",
            [3] = "西風",
            [4] = "北風",
            [5] = "紅中",
            [6] = "青發",
            [7] = "白板",

            [11] = "梅",
            [12] = "蘭",
            [13] = "竹",
            [14] = "菊",
            [15] = "春",
            [16] = "夏",
            [17] = "秋",
            [18] = "冬"
        };

        #endregion Fields

        #region Methods

        protected override string ToDisplayName(CardType type, int value) => $"{RelationMap[value]}";

        #endregion Methods
    }
}