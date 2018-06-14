// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D
using System;
using System.Collections.Generic;

namespace Interview.IGS.Exam.Mahjong.Models.Cards
{
    internal abstract class Card : IEquatable<Card>
    {
        #region Constructors

        protected Card(int gid, CardType type, int value)
        {
            this.Gid = gid;
            this.Type = type;
            this.Value = value;
            this.DisplayName = this.ToDisplayName(type, value);
            this.Weight = (int)type * 10 + value;
        }

        #endregion Constructors

        #region Properties

        public static CardFactory Factory { get; } = new CardFactory();

        public string DebugString => $"[{Gid.ToString().PadLeft(3)}]: {this}";

        public string DisplayName { get; }

        public int Gid { get; }

        public CardType Type { get; }

        public int Value { get; }

        public int Weight { get; }

        #endregion Properties

        #region Methods

        protected abstract IReadOnlyDictionary<int, string> RelationMap { get; }

        public bool CompareByGid(Card other)
        {
            return this.Gid == other.Gid;
        }

        public bool Equals(Card other)
        {
            if (other is null)
                return false;

            return this.Weight == other.Weight;
        }

        public override bool Equals(object obj) => this.Equals(obj as Card);

        public override int GetHashCode() => this.Weight.GetHashCode();

        public override string ToString() => this.DisplayName;

        protected abstract string ToDisplayName(CardType type, int value);

        #endregion Methods
    }
}