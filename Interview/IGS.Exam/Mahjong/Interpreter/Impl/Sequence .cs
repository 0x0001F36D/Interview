// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Interview.IGS.Exam.Mahjong.Interpreter.Impl
{
    using System.Collections.Generic;
    using System.Linq;
    using Collections;
    using Models.Cards;

    internal class Sequence : RuleSet
    {
        #region Properties

        public override string MatchName => "順子";

        public override int Weight => 0;

        #endregion Properties

        #region Methods

        protected override bool MatchEvaluateImpl(IOrderedEnumerable<Card> cardSet, out IList<MatchSet> matches)
        {
            var ordered = new List<NCard>();
            foreach (var card in cardSet)
            {
                if (card.Weight > 10 && card.Weight < 50)
                    ordered.Add(card as NCard);
            }

            matches = new List<MatchSet>();
            bool f = false;
            NCard n, v, m;
            for (int k = 0; k < ordered.Count; k++)
            {
                n = ordered[k];
                for (int j = k + 1; j < ordered.Count; j++)
                {
                    v = ordered[j];
                    for (int i = j + 1; i < ordered.Count; i++)
                    {
                        m = ordered[i];

                        if (isMatch(n, v, m, out var cards))
                        {
                            matches.Add(new MatchSet(cards));
                            f = true;
                        }
                    }
                }
            }
            return f;

            bool isMatch(Card a, Card b, Card c, out Card[] cards)
            {
                cards = null;
                if ((a.Weight + 1).Equals(b.Weight) && (b.Weight + 1).Equals(c.Weight))
                {
                    cards = new Card[3] { a, b, c };
                    return true;
                }
                return false;
            }
        }

        #endregion Methods
    }
}