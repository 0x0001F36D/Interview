﻿// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Interview.Exam.Mahjong.Collections
{
    using System.Collections;
    using System.Collections.Generic;
    using Models.Cards;

    public class MatchSet : IReadOnlyCollection<Card>
    {
        #region Constructors

        internal MatchSet(IReadOnlyCollection<Card> cardSet)
        {
            this._cardSet = cardSet;
        }

        #endregion Constructors

        #region Fields

        private readonly IReadOnlyCollection<Card> _cardSet;

        #endregion Fields

        #region Properties

        public int Count => this._cardSet.Count;

        #endregion Properties

        #region Methods

        IEnumerator<Card> IEnumerable<Card>.GetEnumerator() => this._cardSet.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this._cardSet.GetEnumerator();

        #endregion Methods

        public string DebugString => string.Join(", ", this._cardSet);


        public Card this[uint index]
        {
            get
            {
                var enumerator = this._cardSet.GetEnumerator();
                enumerator.Reset();
                var i = 0;
                while (enumerator.MoveNext())
                {
                    if(i++ == index)
                    {
                        return enumerator.Current;
                    }
                }


                return default(Card);
            }

        }
    }
}