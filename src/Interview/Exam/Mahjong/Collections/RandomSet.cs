// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Interview.Exam.Mahjong.Collections
{
    using Models.Cards;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class RandomSet
    {
        public IEnumerable<Card> Order()
        {
            return this._cards.OrderBy(x => x.Weight);
        }

        #region Constructors

        public RandomSet(IList<Card> cards)
        {
            if (cards.Count != MAX)
                throw new ArgumentException();

            var temp = this.Generate(cards);
            this._cards = new LinkedList<Card>(temp);
        }

        #endregion Constructors

        #region Fields

        internal const int MAX = 144;
        private readonly LinkedList<Card> _cards;

        #endregion Fields

        #region Properties

        public int Count => this._cards.Count;

        #endregion Properties

        #region Methods

        public IEnumerable<Card> Take_16()
        {
            return this.Take_N(16);
        }

        public IEnumerable<Card> Take_4()
        {
            return this.Take_N(4);
        }

        public IEnumerable<Card> Take_N(int count)
        {
            var list = new List<Card>(count);
            for (int i = 0; i < count; i++)
                list.Add(this.TakeHead());
            return list;
        }

        public Card TakeTail()
        {
            var current = this._cards.Last.Value;
            this._cards.RemoveLast();
            return current;
        }

        private IList<Card> Generate(IList<Card> cards)
        {
            var list = new List<Card>();

            for (int n = 1, max = MAX - 1; n <= MAX; n++, max--)
            {
                var rand = this.Rand(max);

                var current = cards[rand];
                cards.RemoveAt(rand);

                list.Add(current);
            }

            return list;
        }

        private int Rand(int max)
        {
            if (max > MAX)
                throw new ArgumentOutOfRangeException();

            var rand = new Random(Guid.NewGuid().GetHashCode());

            return rand.Next(max);
        }

        private Card TakeHead()
        {
            var current = this._cards.First.Value;
            this._cards.RemoveFirst();
            return current;
        }

        #endregion Methods
    }
}