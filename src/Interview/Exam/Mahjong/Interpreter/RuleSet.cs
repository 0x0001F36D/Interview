// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Interview.Exam.Mahjong.Interpreter
{
    using System.Collections.Generic;
    using System.Linq;
    using Mahjong.Collections;
    using Mahjong.Models.Cards;

    public abstract class RuleSet
    {
        #region Constructors

        public RuleSet()
        {
            this.MatchName = this.GetType().Name;
            this._internalLock = false;
        }

        #endregion Constructors

        #region Properties

        public abstract int Weight { get; }

        #endregion Properties



        #region Properties

        public virtual string MatchName { get; }

        #endregion Properties

        #region Methods

        private bool _internalLock;

        public bool IsMatch { get; private set; }

        public IList<MatchSet> Matches { get; private set; }

        public void Evalute(IOrderedEnumerable<Card> cardSet)
        {
            if (this._internalLock)
                return;
            this.IsMatch = this.MatchEvaluateImpl(cardSet, out var ms);
            this.Matches = ms;
            this._internalLock = true;
        }

        public RuleSet Revoke()
        {
            this._internalLock = false;
            return this;
        }

        protected abstract bool MatchEvaluateImpl(IOrderedEnumerable<Card> cardSet, out IList<MatchSet> matches);

        #endregion Methods
    }
}