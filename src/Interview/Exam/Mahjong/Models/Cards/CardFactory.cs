// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Interview.Exam.Mahjong
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Collections;
    using Models.Cards;

    public sealed class CardFactory
    {
        internal CardFactory()
        {
            this.Init();
        }

        private RandomSet _cards;

        public RandomSet Cards => this._cards;

        public static IEnumerable<Card> Order(IEnumerable<Card> cards)
        {
            return cards.OrderBy(x => x.Weight);
        }

        /// <summary>
        /// 初始化牌庫(新局時)
        /// </summary>
        public void Init()
        {
            var cards = new List<Card>(144);
            int gid = 0;

            // generate all cards
            foreach (CardType type in Enum.GetValues(typeof(CardType)))
            {
                switch (type)
                {
                    case CardType.萬:
                    case CardType.索:
                    case CardType.筒:
                        for (int value = 1; value <= 9; value++)
                            for (int count = 0; count < 4; count++)
                                cards.Add(new NCard(gid++, type, value));
                        break;

                    case CardType.風向及花牌:

                        //風
                        for (int value = 1; value <= 7; value++)
                            for (int count = 0; count < 4; count++)
                                cards.Add(new SCard(gid++, value));

                        //花
                        for (int value = 11; value <= 18; value++)
                            cards.Add(new SCard(gid++, value));
                        break;

                    default:
                        throw new NotSupportedException();
                }
            }

            this._cards = new RandomSet(cards);
        }

    }
}