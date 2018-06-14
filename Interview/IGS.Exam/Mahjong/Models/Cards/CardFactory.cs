// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Interview.IGS.Exam.Mahjong
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interview.IGS.Exam.Mahjong.Collections;
    using Interview.IGS.Exam.Mahjong.Models.Cards;

    internal sealed class CardFactory
    {
        #region Constructors

        internal CardFactory()
        {
            this.Init();
        }

        #endregion Constructors

        #region Fields

        private RandomSet _cards;

        #endregion Fields

        #region Properties

        public RandomSet Cards => this._cards;

        #endregion Properties

        #region Methods

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

        #endregion Methods
    }
}