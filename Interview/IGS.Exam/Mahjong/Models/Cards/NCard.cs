// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D
using System.Collections.Generic;

namespace Interview.IGS.Exam.Mahjong.Models.Cards
{
    internal class NCard : Card
    {
        #region Constructors

        internal NCard(int id, CardType type, int value) : base(id, type, value)
        {
        }

        #endregion Constructors

        #region Methods

        protected override IReadOnlyDictionary<int, string> RelationMap { get; } = new Dictionary<int, string>
        {
            [1] = "一",
            [2] = "二",
            [3] = "三",
            [4] = "四",
            [5] = "五",
            [6] = "六",
            [7] = "七",
            [8] = "八",
            [9] = "九",
        };

        protected override string ToDisplayName(CardType type, int value) => $"{RelationMap[value]}{type}";

        #endregion Methods
    }
}